using System;
using System.IO;
using System.Linq;

namespace _03.DirectoriesTree
{
    class Program
    {        
        static void Main(string[] args)
        {
            string rootFolderPath = @"C:\Windows\";
            string rootFolderName = Path.GetDirectoryName(rootFolderPath);
            FolderNode rootFolder = new FolderNode(rootFolderName);
            rootFolder.GetFilesAndChildFolders();
            Console.WriteLine(rootFolder.FolderSize + " bytes");
            var folder = rootFolder.GetChildFolder(@"C:\Windows\Fonts");
            if (folder == null)
            {
                Console.WriteLine("Folder not found");
            }
            else
            {
                Console.WriteLine(folder.FolderSize + " bytes");
            }
        }
    }
}
