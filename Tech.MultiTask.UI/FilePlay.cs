using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Tech.MultiTask.UI
{
    public class FilePlay
    {
        private static string fileCritical = "*";
        private static string fileCritical1 = "*";
        public const int MultiCount = 100;
        private Random random = new Random();
        public string Folder { get; set; }
        public FilePlay(string folderName)
        {
            Folder = folderName;
            
        }

        public async Task<string> GetCityData(string cityname)
        {
            string str = "";
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://api.weatherapi.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync(@"/v1/current.json?key=b480e7a490374b44be472511222103&q=" + cityname + "&aqi=no%22");
                if (response.IsSuccessStatusCode)
                {
                    str = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

            }

            return str;
        }
        public  Task CreateTask_Weather(string city)
        {
            return Task.Factory.StartNew(async () => {
                string val = await GetCityData(city);

                string filename = $"{Folder}{Guid.NewGuid()}.txt";

                System.IO.File.WriteAllText(filename, val);
            });

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
            return $"{Folder}{random.Next(1, MultiCount)}.txt";
        }
        public Task CreateTask_Creation()
        {
            Task ret = Task.Factory.StartNew(() => {
                string fName = GenerateFileName();

                lock (fileLocks)
                {
                    if (!fileLocks.ContainsKey(fName))
                    {
                        fileLocks.Add(fName, "*");
                    }
                }

                if (!System.IO.File.Exists(fName))
                {
                    lock (fileLocks[fName])
                    {
                        System.IO.File.WriteAllText(fName, "*");
                      
                    }
                }
                

            });

            return ret;
        }
        System.Collections.Generic.Dictionary<string, string> fileLocks = new Dictionary<string, string>();

        public Task CreateTask_Delete()
        {
            Task ret = Task.Factory.StartNew(() => {
                string fName = GenerateFileName();

                if (System.IO.File.Exists(fName))
                {
                    lock(fileLocks)
                    {
                        if (!fileLocks.ContainsKey(fName))
                        {
                            fileLocks.Add(fName, "*");
                        }
                    }

                    lock (fileLocks[fName])
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
