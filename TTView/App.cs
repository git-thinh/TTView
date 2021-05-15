using Salar.Bois;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
        static KeySubscriber __subscriber;
        static Thread __threadQueue = null;
        static ConcurrentQueue<byte[]> __requests = new ConcurrentQueue<byte[]>() { };
        static AutoResetEvent __signal = new AutoResetEvent(false);
        static void __processQueueReceive()
        {
            __threadQueue = new Thread(new ParameterizedThreadStart((o) =>
            {
                var qs = o as ConcurrentQueue<byte[]>;
                while (__running)
                {
                    if (qs.Count == 0)
                        __signal.WaitOne();
                    byte[] buf;
                    qs.TryDequeue(out buf);
                    oRequestReply rp = oRequestReply.Load(buf);
                    if (rp != null)
                        main._requestReply(rp);
                }
            }));
            __threadQueue.Start(__requests);
        }

        static void _subcribeTask(IMain main)
        {
            __subscriber = new KeySubscriber((reply) =>
            {
                __requests.Enqueue(reply);
                __signal.Set();
            });
            __subscriber.Start();
        }

        static IMain main;
        [STAThread]
        static void Main(string[] args)
        {
            var tn = typeof(Dictionary<string, object>).Name;

            _init();
            __processQueueReceive();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var app = loadSetting();
            var m = new fMain(app);
            main = (IMain)m;
            var t = new Thread(new ParameterizedThreadStart((p) => _subcribeTask((IMain)p)));
            t.Start(main);
            Application.Run(m);

            __running = false;
            __subscriber.Stop();
            t.Abort();

            writeSetting(app);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        static void _init()
        {
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
