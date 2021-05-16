using System;
using System.Collections.Generic;
using System.Text;

namespace TTView
{

    public interface IMain
    {
        void _requestReply(string requestId, COMMANDS cmd, string input, Dictionary<string, object> data);
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
        public bool AutoResize { set; get; }
        public bool OpenAllOr10 { set; get; }
        public string Directory { set; get; }
        public bool HideToolbar { set; get; }
    }

    public class oApp
    {
        public oFile FileCurrent { set; get; }
        public List<oFile> Files { set; get; }
        public oSetting Setting { set; get; }
        public int Top { set; get; }
        public int Left { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public oApp()
        {
            this.FileCurrent = new oFile();
            this.Files = new List<oFile>();
            this.Setting = new oSetting();
        }
    }
}
