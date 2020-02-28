using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using ConsoleApp3.Model;
using Nancy.Json;

namespace ConsoleApp3
{
    class Configure
    {
        private string jsonConfig = "";
        private ConfigModel parsedJsonConfig;
        private static Configure instance = null;
        private static readonly object padlock = new object();
        private Configure()
        {
            
            using (FileStream fs = File.OpenRead("config.json"))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                jsonConfig = Encoding.Default.GetString(array);
            }

               parsedJsonConfig = new JavaScriptSerializer().Deserialize<ConfigModel>(jsonConfig);
        }

        public static Configure Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Configure();
                    }
                    return instance;
                }
            }
        }

        public ConfigModel GetConfig()
        {
            return this.parsedJsonConfig;
        }
       
    }
   
}
