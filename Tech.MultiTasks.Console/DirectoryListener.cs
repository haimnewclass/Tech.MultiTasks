using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.MultiTasks.Console
{
    internal class DirectoryListener
    {
        readonly string FolderName;
        public bool IsRunning = true;
        public DirectoryListener(string folderName)
        {
            FolderName = folderName;
            RunTask();
        }
        public int NumberOfFiles = 0;
        public Task RunTask()
        {
            Task task = Task.Factory.StartNew(() => { 
                
                while (IsRunning)
                {
                    
                    NumberOfFiles = System.IO.Directory.GetFiles(FolderName).Length;
                    System.Threading.Thread.Sleep(4000);
                    // run paralely
                }


            });

            return task;
        }
    }
}
