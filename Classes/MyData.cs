using System;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyLIB.Misc;

namespace MyDownloader
{
    public class MyData
    {
        public List<Download> Queue = new List<Download>();
        public List<Download> PreQueue = new List<Download>();

        public MyData()
        {

        }

        public void CopyFromTM()
        {
            Queue.Clear();
            PreQueue.Clear();
            foreach (var d in TopManager.st.Queue)
                Queue.Add(d.Copy());
            foreach (var d in TopManager.st.PreQueue)
                PreQueue.Add(d.Copy());
        }

        public void CopyToTM()
        {
            TopManager.st.Queue.Clear();
            TopManager.st.PreQueue.Clear();
            foreach (var d in Queue)
                TopManager.st.Queue.Add(d.Copy());
            foreach (var d in PreQueue)
                TopManager.st.PreQueue.Add(d.Copy());
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) return true;
            if (Queue.Count != TopManager.st.Queue.Count) return false;
            if (PreQueue.Count != TopManager.st.PreQueue.Count) return false;
            for (int i = 0; i < Queue.Count; i++)
                if (!Queue[i].Equals(TopManager.st.Queue[i])) return false;
            for (int i = 0; i < PreQueue.Count; i++)
                if (!PreQueue[i].Equals(TopManager.st.PreQueue[i])) return false;
            return true;
        }
    }
}
