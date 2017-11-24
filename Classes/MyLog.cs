using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDownloader
{
    public class MyLogMsg
    {
        public string Msg { get; set; } = null;
        public DateTime TimeStamp { get; set; }

        public string GetAsString()
        {
            return $"[{TimeStamp:dd.MM.yy HH:mm}]\n{Msg}";
        }
    }

    public class MyLog : BindingList<MyLogMsg>
    {
        public void Add(string msg)
        {
            var logmsg = new MyLogMsg()
            {
                Msg = msg,
                TimeStamp = DateTime.Now
            };
            this.Add(logmsg);
        }

        public string GetAsString()
        {
            var sb = new StringBuilder();
            foreach(var it in this)
            {
                sb.AppendLine(it.GetAsString());
            }
            return sb.ToString();
        }
    }
}
