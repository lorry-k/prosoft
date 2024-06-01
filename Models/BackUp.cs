using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySave_V3._0.Models
{
    public class BackUp
    {
        public string name { get; set; }
        public string source;
        public string destination;
        public string type;
        public DateTime lastSave;
        public string totalSize;
        public int duration;
        public long durationEncrypt=0;
        public int totalFiles = 0;
        public int curFiles = 0;
        public long progression { get; set; } = 0;
        public long totalSizeByte;
        public long curSizeByte;
        public string currentStatus;
        public bool finalStatus;

        public BackUp(){ }

        public BackUp(string name, string source, string destination, string type)
        {
            this.name = name;
            this.source = source;
            this.destination = destination;
            this.type = type;

        }
    }
}
