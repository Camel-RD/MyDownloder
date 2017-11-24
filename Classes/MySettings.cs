using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyDownloader
{
    public class MySettings
    {
        private string _downloadTo = "";
        private bool _shutdown = false;
        private int _fontSize = 12;
        private int _reconnectAfterError = 11;

        [XmlIgnore]
        public bool HasChanged = false;

        public string DownloadTo
        {
            get { return _downloadTo; }
            set
            {
                if (string.Compare(value, _downloadTo) == 0) return;
                _downloadTo = value;
                HasChanged = true;
            }
        }

        public bool ShutDown
        {
            get { return _shutdown; }
            set
            {
                if (value == _shutdown) return;
                _shutdown = value;
                HasChanged = true;
            }
        }

        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                if (value == _fontSize) return;
                _fontSize = value;
                HasChanged = true;
            }
        }

        public int ReconnectAfterError
        {
            get { return _reconnectAfterError; }
            set
            {
                if (value == _reconnectAfterError) return;
                _reconnectAfterError = value;
                HasChanged = true;
            }
        }

    }
}
