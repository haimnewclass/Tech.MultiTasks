using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.MultiTasks.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ite = 100;
            int currentFileCount = 0;
            DirectoryListener listener = new DirectoryListener(@"C:\Code\CSV\AccidentsReport\AccidentsUI\Data\");
            while(listener.IsRunning)
            {
                if(currentFileCount!= listener.NumberOfFiles)
                {
                   
                   // Console.WriteLine($"Files count has been changed to {listener.NumberOfFiles}");
                    currentFileCount = listener.NumberOfFiles;
                }
                System.Threading.Thread.Sleep(5000);
                ite--;
                if(ite==0)
                {
                    listener.IsRunning = false;
                }
            }

           // listener.IsRunning = false;
        }
    }
}
