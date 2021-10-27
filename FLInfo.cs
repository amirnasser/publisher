using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Publisher
{
    class FLInfo
    {
        public FLInfo() { }
        public FLInfo(string path)
        {
            FileInfo fi = new FileInfo(path);
            this.Filename = fi.Name;
            this.Path = fi.DirectoryName;
            this.CreationDate = fi.CreationTime;
            this.LastModifiedDate = fi.LastWriteTime;
        }

        public string Filename { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
