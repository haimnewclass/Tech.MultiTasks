using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.MultiTasks.Console
{
    public interface ICommand
    {
        void ReadContent(int content);
    }
    public class Commands
    {
        public bool runTask = true;
        public int FileContent
        {
            get; set;
        }
        private readonly string _filePath;
        public Commands(string filePath)
        {
            _filePath = filePath;
            RunCheckFile();
        }
        
        public Task RunCheckFile()
        {
            Task task = Task.Factory.StartNew(() => { 
                while(runTask)
                {
                    FileContent = int.Parse( System.IO.File.ReadAllText(_filePath));
                    System.Threading.Thread.Sleep(10000);
                }
            });

            return task;
        }
    }
}
