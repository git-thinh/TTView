using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TTView
{
    public class App
    {
        public static void Close() {
            main.Close();
        }

        static bool __running = true;
        static void _subcribeTask(IMain main)
        {
            var redis = new RedisBase(new RedisSetting(REDIS_TYPE.ONLY_SUBCRIBE, 1001));
            redis.PSUBSCRIBE("*");
            var bs = new List<byte>();
            while (__running)
            {
                if (!redis.m_stream.DataAvailable)
                {
                    if (bs.Count > 0)
                    {
                        var data = redis.__getBodyPublish(bs.ToArray());
                        bs.Clear();
                        main._requestResponse(data);
                    }
                    Thread.Sleep(100);
                    continue;
                }
                byte b = (byte)redis.m_stream.ReadByte();
                bs.Add((byte)b);
            }
        }
        static fMain main;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            main = new fMain();
            //var t = new Thread(new ParameterizedThreadStart((p) => _subcribeTask((IMain)p)));
            //t.Start(main);
            Application.Run(main);
            __running = false;
            //t.Abort();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    public interface IMain
    {
        void _requestResponse(Tuple<string, byte[]> data);
    }

}
