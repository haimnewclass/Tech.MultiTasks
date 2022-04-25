using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.MultiTask.UI
{
    public class FilePlay
    {
        private Random random = new Random();
        public string Folder { get; set; }
        public FilePlay(string folderName)
        {
            Folder = folderName;
        }
        
        protected string GenerateFileName()
        {
            return $"{Folder}{random.Next(1, 9)}.txt";
        }
        public Task CreateTask_Creation()
        {
            Task ret = Task.Factory.StartNew(() => {
                string fName = GenerateFileName();
                if (! System.IO.File.Exists(fName))
                {
                    System.IO.File.WriteAllText(fName, "*");
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
                    System.IO.File.Delete(fName);
                }

            });

            return ret;
        }
    }
}
