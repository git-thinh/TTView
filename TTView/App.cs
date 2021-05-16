using Salar.Bois;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace TTView
{
    class App
    {
        static App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (se, ev) =>
            {
                Assembly asm = null;
                string comName = ev.Name.Split(',')[0];
                string resourceName = @"DLL\" + comName + ".dll";
                var assembly = Assembly.GetExecutingAssembly();
                resourceName = typeof(App).Namespace + "." + resourceName.Replace(" ", "_").Replace("\\", ".").Replace("/", ".");
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        //Debug.WriteLine(resourceName);
                    }
                    else
                    {
                        byte[] buffer = new byte[stream.Length];
                        using (MemoryStream ms = new MemoryStream())
                        {
                            int read;
                            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                                ms.Write(buffer, 0, read);
                            buffer = ms.ToArray();
                        }
                        asm = Assembly.Load(buffer);
                    }
                }
                return asm;
            };
        }

        static bool __running = true;
        static bool __pending = true;
        static Thread __threadQueue = null;
        static ConcurrentQueue<NetPacket> __replies = new ConcurrentQueue<NetPacket>() { };
        static AutoResetEvent __signal = new AutoResetEvent(false);
        static void __processQueueReceive()
        {
            __threadQueue = new Thread(new ParameterizedThreadStart((o) =>
            {
                var qs = o as ConcurrentQueue<NetPacket>;
                while (__running)
                {
                    if (__pending || qs.Count == 0)
                        __signal.WaitOne();
                    NetPacket packet;
                    qs.TryDequeue(out packet);
                    if (packet != null) {
                        var reader = new NetPacketReader(packet);
                        var cmd = reader.Read<COMMANDS>();
                        var requestId = reader.ReadRequestId();
                        var input = reader.Read<string>();
                        var data = reader.Read<Dictionary<string, object>>();
                        main._requestReply(requestId, cmd, input, data);
                    }                        
                }
            }));
            __threadQueue.Start(__replies);
        }
        public static string Send(COMMANDS cmd, string input, Dictionary<string, object> data = null)
        {
            string requestId = Guid.NewGuid().ToString();
            var packet = new NetPacket(cmd, requestId, input, data);
            client.Send(packet);
            return requestId;
        }

        public static Bitmap GetBitmap(long docId, int page)
            => redis.HGET_BITMAP(docId, page);

        static RedisBase redis;
        static NetClient subcribe;
        static NetClient client;
        static IMain main;
        [STAThread]
        static void Main(string[] args)
        {
            try
            {                
                __processQueueReceive();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var app = loadSetting();
                var m = new fMain(app);
                main = (IMain)m;

                subcribe = new NetClient(__CONFIG.UDP_HOST, __CONFIG.UDP_PORT);
                subcribe.OnRecieve += (packet) =>
                {
                    __pending = true;
                    __replies.Enqueue(packet);
                    __pending = false;
                    __signal.Set();
                };
                subcribe.Subcribe();
                Thread threadSucribe = new Thread(subcribe.Listen);
                threadSucribe.Start();
                client = new NetClient(__CONFIG.UDP_HOST, __CONFIG.UDP_PORT);

                redis = new RedisBase(new RedisSetting(REDIS_TYPE.ONLY_READ, __CONFIG.REDIS_PORT_READ));

                Application.Run(m);
                app.Top = m.Top;
                app.Left = m.Left;
                app.Height = m.Height;
                app.Width = m.Width;
                writeSetting(app);

                client.Stop();
                subcribe.Stop();
                threadSucribe.Abort();
                __threadQueue.Abort();

                __running = false;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch(Exception ex) {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        static oApp loadSetting()
        {
            if (File.Exists("setting.bin"))
            {
                var boisSerializer = new BoisSerializer();
                using (var file = new FileStream("setting.bin", FileMode.Open))
                {
                    var app = boisSerializer.Deserialize<oApp>(file);
                    return app;
                }
            }
            return new oApp();
        }

        static void writeSetting(oApp app)
        {
            var boisSerializer = new BoisSerializer();
            using (var file = new FileStream("setting.bin", FileMode.OpenOrCreate))
                boisSerializer.Serialize<oApp>(app, file);
        }
    }

}
