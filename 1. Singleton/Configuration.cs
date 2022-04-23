using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Configuration
{
    public sealed class Configuration
    {
        // Singleton 객체
        public static Configuration Settings { get; } = new Configuration();

        private Dictionary<string, object> dict = new Dictionary<string, object>();

        private Configuration()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            bool b = File.Exists("Config.json");
            var str = File.ReadAllText("Config.json");
            JObject jo = JObject.Parse(str);

            foreach (var kv in jo)
            {
                dict.Add(kv.Key, kv.Value);
            }
        }

        // 인덱서, Singleton 객체를 통해 dict에 접근
        public object this[string key] => dict[key];
    }

    class Clent
    {
        public static void _Main()
        {
            var user = Configuration.Settings["Username"];
            var server = Configuration.Settings["Server"];
            Console.WriteLine($"{server}, {user}");
        }
    }
}
