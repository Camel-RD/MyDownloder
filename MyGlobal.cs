using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDownloader
{
    public delegate void ProgressEventHandler(object sender,ProgressEventArgs e);

    public class ProgressEventArgs:System.EventArgs
    {
        public int BytesPending = 0;
        public int BytesTotal = 0;
        public DownloadStatusEnum Status;
        public string Key;

        public ProgressEventArgs(int pending,int total,DownloadStatusEnum status,string key) 
        {
            BytesPending = pending;
            BytesTotal = total;
        }
    }

    static class MyGlobal
    {

    }
}
