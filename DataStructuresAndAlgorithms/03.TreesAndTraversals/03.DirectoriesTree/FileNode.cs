using System;
using System.Linq;

namespace _03.DirectoriesTree
{
    public class FileNode
    {
        public string Name { get; set; }
        public long Size { get; set; }

        public FileNode(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }
    }
}
