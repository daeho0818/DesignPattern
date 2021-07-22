using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Configuration
{
    public sealed class Configuration
    {
        public static Configuration Settings { get; } = new Configuration();

        private Dictionary<string, object> dict = new Dictionary<string, object>();

        private Configuration()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            var str = File.ReadAllText("Config.json");
            JObject jo = JObject.Parse(str);

            foreach (var kv in jo)
            {
                dict.Add(kv.Key, kv.Value);
            }
        }

        public object this[string key] => dict[key];
    }

    class Clent
    {
        public static void HowToTest()
        {
            var user = Configuration.Settings["Username"];
            var server = Configuration.Settings["Server"];
            Console.WriteLine($"{server}, {user}");
        }
    }
}
