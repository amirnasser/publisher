using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publisher
{
    class TreeNodeFile : System.Windows.Forms.TreeNode
    {
        public string Path;
        public FileType Filetype;
        public enum FileType { File, Directroy}
        public TreeNodeFile(string name , int image1, int image2, string path, FileType fileType):base(name,image1,image2)
        {
            this.Path = path;
            this.Filetype = fileType;
        }
    }
}
