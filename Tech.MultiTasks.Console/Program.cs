using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.MultiTasks.Console
{
    internal class Program
    {
        class Ball
        {
            public int size;
            public string name;
        }
        static void Main(string[] args)
        {

            int[] arr = { 234, 2345, 34, 1, 2, 4, 3, 2, 3, 4, 3, 4, 3, 23, 2, 342, 34234, 3 };

            var q = from num in arr
                    where num > 5 && num < 800
                    orderby num
                    select num;

            var q1 = from num in arr
                     where num > 5 && num < 800
                     orderby num
                     select num*num + 10;


            List<Ball> list = new List<Ball>();
            list.Add(new Ball() { name = "Fifa", size = 5 });
            list.Add(new Ball() { name = "Fiba", size = 7 });
            list.Add(new Ball() { name = "Fifa", size = 7 });

            var q3 = from i in list
                     where i.size == 7
                     select i;


            var list3 =  q3.ToList<Ball>();
            
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
