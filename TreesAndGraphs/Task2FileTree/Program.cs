using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task2FileTree
{
    class Program
    {
        // Task 2: Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders }
        // and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. Implement a
        // method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly.
        // Use recursive DFS traversal.

        static void Main(string[] args)
        {
            string path = @"C:\Windows\diagnostics\";
            Folder testFolder = new Folder(new DirectoryInfo(path));
            long folderSize = Folder.FolderSize(testFolder);
            
            if (folderSize == 3560356)
                Console.WriteLine("test passed");
            else
                Console.WriteLine("test failed");
        }
    }

    class File
    {
        private string name;
        private long size;

        public File(string name, long size)
        {
            this.name = name;
            this.size = size;
        }

        public long Size
        {
            get { return this.size; }
        }

        public string Name
        {
            get { return this.name; }
        }
    }

    class Folder
    {
        private string name;
        private File[] files;
        private Folder[] childFolders;

        public Folder(DirectoryInfo dir)
        {
            this.name = dir.FullName;
            AddFilesToDir(dir);
            AddChildFolders(dir);
        }

        public Folder(string path)
        {
            DirectoryInfo dir = null;
            try
            {
                dir = new DirectoryInfo(path);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid path.");
            }
            this.name = dir.FullName;
            AddFilesToDir(dir);
            AddChildFolders(dir);
        }

        public string Name
        {
            get { return this.name; }
        }

        public File[] GetFiles
        {
            get { return this.files; }
        }

        public Folder[] GetSubFolders
        {
            get { return this.childFolders; }
        }

        private void AddFilesToDir(DirectoryInfo dir)
        {
            try
            {
                FileInfo[] filesInDir = dir.GetFiles();
                this.files = new File[filesInDir.Length];
                for (int index = 0; index < filesInDir.Length; index++)
                {
                    this.files[index] = new File(filesInDir[index].Name, filesInDir[index].Length);
                }
            }
            catch (DirectoryNotFoundException)
            {
                this.files = null;
            }
        }

        private void AddChildFolders(DirectoryInfo dir)
        {
            try
            {
                DirectoryInfo[] subDirs = dir.GetDirectories();
                this.childFolders = new Folder[subDirs.Length];
                for (int index = 0; index < subDirs.Length; index++)
                {
                    this.childFolders[index] = new Folder(subDirs[index]);
                }
            }
            catch (UnauthorizedAccessException) //unauthorized to view folder contents, don't generate children for it then
            {
                this.childFolders = null;
            }
        }

        public static long FolderSize(Folder folder)
        {
            long result = folder.FilesSizes();
            if (folder.childFolders != null)
            {
                foreach (var subDir in folder.childFolders)
                {
                    result += FolderSize(subDir);
                }
            }
            return result;
        }

        private long FilesSizes()
        {
            if (this.files == null)
            {
                return 0;
            }

            long sum = 0;
            foreach (var file in this.files)
            {
                sum += file.Size;
            }
            return sum;
        }
    }
}
