using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace _03.DirectoriesTree
{
    public class FolderNode
    {
        // Fields
        private string name;
        private string directoryPath;
        private HashSet<FileNode> files;
        private Dictionary<string, FolderNode> childFolders;

        // Constructor
        public FolderNode(string name)
        {
            this.Name = name;
            this.DirectoryPath = this.Name + "\\";
            this.files = new HashSet<FileNode>();
            this.childFolders = new Dictionary<string, FolderNode>();
        }

        // Properties
        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.Equals(value, null))
                {
                    throw new ArgumentNullException("Name can't be null");
                }
                else if (string.Equals(value, string.Empty))
                {
                    throw new ArgumentException("Name can't be empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public string DirectoryPath
        {
            get
            {
                return this.directoryPath;
            }

            private set
            {
                this.directoryPath = value;
            }
        }

        public Dictionary<string, FolderNode> ChildFolders
        {
            get
            {
                return this.childFolders;
            }

            private set
            {
                this.childFolders = value;
            }
        }

        public HashSet<FileNode> Files 
        {
            get
            {
                return this.files;
            }

            private set
            {
                this.files = value;
            }
        }

        public BigInteger FolderSize
        {
            get
            {
                return this.CalculateFolderSize();
            }
        }

        // Public methods
        public void AddFile(FileNode file)
        {
            this.Files.Add(file);
        }

        public void AddFolder(FolderNode folder)
        {
            this.ChildFolders.Add(folder.Name, folder);
        }

        public FolderNode GetChildFolder(string name)
        {
            FolderNode currentFolder = this;
            Dictionary<string, FolderNode> currentChilds = currentFolder.ChildFolders;

            if (currentChilds.ContainsKey(name))
            {
                return currentChilds[name];
            }
            else
            {
                foreach (var childFolder in currentChilds.Values)
                {
                    FolderNode result = childFolder.GetChildFolder(name);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        public void GetFilesAndChildFolders()
        {
            try
            {
                FolderNode currentFolder = this;
                string currentFolderPath = this.DirectoryPath;
                foreach (var filePath in Directory.GetFiles(currentFolderPath))
                {
                    FileInfo currentFileInfo = new FileInfo(filePath);
                    FileNode currentFile = new FileNode(currentFileInfo.Name, currentFileInfo.Length);
                    currentFolder.AddFile(currentFile);
                }

                foreach (var folderPath in Directory.GetDirectories(currentFolderPath))
                {
                    string subFolderName = Path.GetDirectoryName(folderPath + "\\");
                    FolderNode subFolder = new FolderNode(subFolderName);
                    currentFolder.AddFolder(subFolder);
                    subFolder.GetFilesAndChildFolders();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Private methods
        private BigInteger CalculateFolderSize()
        {
            FolderNode currentFolder = this;
            Dictionary<string, FolderNode> currentChilds = currentFolder.ChildFolders;
            BigInteger currentFolderSize = 0;            if (currentChilds.Keys.Count == 0)
            {
                foreach (var file in currentFolder.Files)
                {
                    currentFolderSize += file.Size;
                }
            }
            else
            {
                foreach (var file in currentFolder.Files)
                {
                    currentFolderSize += file.Size;
                }

                foreach (var childFolder in currentChilds.Values)
                {
                    currentFolderSize += childFolder.FolderSize;
                }
            }

            return currentFolderSize;
        }
    }
}
