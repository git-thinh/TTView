using System.Collections.Generic;
using System.IO;

namespace TTView
{
    public interface IMain
    {
        void _requestReply(string requestId, COMMANDS cmd, string input, Dictionary<string, object> data);
    }

    public class oWindow
    {
        public int Top { set; get; }
        public int Left { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
    }

    public class oRedis
    {
        public string Host { set; get; }
        public int Port { set; get; }
        public int Db { set; get; }
        public oRedis() {
            Host = "127.0.0.1";
            Port = 1000;
            Db = 0;
        }
    }

    public class oFile
    {
        public long Id { set; get; }
        public string File { set; get; }
        public int PageCurrent { set; get; }
        public int PageTotal { set; get; }
    }

    public class oSetting
    {
        public string PathStoreFileRaw { set; get; }
        public string PathStoreFilePublish { set; get; }

        public int OcrLanguage { set; get; }
        public int OcrLevel { set; get; }
        public int OcrEngine { set; get; }

        public int ImageDpiX { set; get; }
        public int ImageDpiY { set; get; }
        public int ImageQuantity { set; get; }
        public int ImageMinWidth { set; get; }

        public bool HideToolbar { set; get; }
        public bool Only10PageFirstlyOrAll { set; get; }
        public bool DrawSelectionImageWord { set; get; }
        public bool ViewModeNoBorder { set; get; }
        public bool ViewModePublish { set; get; }
        public bool ViewModeResponsiveMobile { set; get; }
    }

    public class oApp
    {
        public oFile FileCurrent { set; get; }
        public oSetting Setting { set; get; }
        public oWindow Window { set; get; }
        public oRedis Redis { set; get; }
        public oApp()
        {
            this.FileCurrent = new oFile();
            this.Setting = new oSetting();
            this.Window = new oWindow();
            this.Redis = new oRedis();
        }

        public void WriteFile()
        {
            var boisSerializer = new Salar.Bois.BoisSerializer();
            using (var file = new FileStream("setting.bin", FileMode.OpenOrCreate))
                boisSerializer.Serialize<oApp>(this, file);
        }
    }
}
