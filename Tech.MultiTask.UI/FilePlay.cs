using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.MultiTask.UI
{
    public class FilePlay
    {
        private static string fileCritical = "*";
        public const int MultiCount = 100;
        private Random random = new Random();
        public string Folder { get; set; }
        public FilePlay(string folderName)
        {
            Folder = folderName;
        }
        
        public Task CreateMultiTask_Creation()
        {
            return Task.Factory.StartNew(() => {
                for (int i = 0; i < MultiCount; i++)
                {
                   CreateTask_Creation();
                }
            });
        }

        public Task CreateMultiTask_Delete()
        {
            return Task.Factory.StartNew(() => {
                for (int i = 0; i < MultiCount; i++)
                {
                    CreateTask_Delete();
                }
            });
        }


        protected string GenerateFileName()
        {
            return $"{Folder}{random.Next(1, 1000)}.txt";
        }
        public Task CreateTask_Creation()
        {
            Task ret = Task.Factory.StartNew(() => {
                string fName = GenerateFileName();
                
                if (!System.IO.File.Exists(fName))
                {
                    lock (fileCritical)
                    {
                        System.IO.File.WriteAllText(fName, "*");
                    }
                }
                

            });

            return ret;
        }

        public Task CreateTask_Delete()
        {
            Task ret = Task.Factory.StartNew(() => {
                string fName = GenerateFileName();

                if (System.IO.File.Exists(fName))
                {
                    lock(fileCritical)
                    { 
                        // criticat section
                        System.IO.File.Delete(fName);
                    }
                }
               

            });

            return ret;
        }
    }
}
