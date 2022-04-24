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


            Commands cmd = new Commands(@"C:\Code\CSV\AccidentsReport\AccidentsUI\Data\commands.txt");

            while(cmd.runTask)
            {
                for (int i = 0; i < cmd.FileContent; i++)
                {
                    System.Console.WriteLine("Shalom");
                }
                System.Threading.Thread.Sleep(5000);
                if(cmd.FileContent == 0)
                {
                    cmd.runTask = false;
                }
            }


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
