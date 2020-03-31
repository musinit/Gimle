using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Slack.Client.Models.SlackApi;

namespace Gimle.Core.Utils
{
    public static class CommonHelper
    {
        private static ConcurrentDictionary<string, string[]> _cache = new ConcurrentDictionary<string, string[]>();
        
        public static Block[] DeserializeArray(string type, ReplaceValue[] replaceValues = null)
        {
            string[] cachedStrings;
            StringBuilder jsonResult = new StringBuilder();
            if (_cache.TryGetValue(type, out cachedStrings))
            {
                foreach (var line in cachedStrings)
                {
                    ProcessLine(line, replaceValues, jsonResult);
                }
            }
            else
            {
                var stringsForCache = new List<string>();
                using (StreamReader r = new StreamReader($"GimleBlocks/{type}.json"))
                {
                    if (replaceValues == null)
                    {
                        var strings = r.ReadToEnd().Split("\n");
                        stringsForCache.AddRange(strings);
                        jsonResult.Append(string.Join("\n", strings));
                    }
                    else
                    {
                        string line = r.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            stringsForCache.Add(line);
                            ProcessLine(line, replaceValues, jsonResult);
                            line = r.ReadLine();
                        }
                    }
                }
                _cache[type] = stringsForCache.ToArray();
            }
            var blocks  = JsonConvert.DeserializeObject<Block[]>(jsonResult.ToString());
            if (blocks == null || !blocks.Any()) throw new KeyNotFoundException("Cant find template of slack block");
            return blocks;
        }
        
        private static void ProcessLine(string line, ReplaceValue[] replaceValues, StringBuilder json)
        {
            if (string.IsNullOrEmpty(line) || line == "\n")
                return;
            
            if (replaceValues != null)
            {
                foreach (var replaceValue in replaceValues)
                {
                    if (replaceValue == null)
                        continue;
                    if (line.Contains(replaceValue.Value.Key))
                    {
                        var endOfArray = !line.Contains(",");
                        if (replaceValue.Value.Value != null)
                            line = line.Replace(replaceValue.Value.Key, replaceValue.Value.Value);
                        else line = "";
                        if (!endOfArray && !replaceValue.IsInline) line = line + ",";
                    }
                }
            }
            json.Append(line);
        }
        
        public static string SerializeBlockArray(ICollection<Block> values)
        {
            if (values == null || !values.Any())
                return null;
            var b = JsonConvert.SerializeObject(values);
            return b.Substring(1, b.Length - 2);
        }

        public static Block[] ReplaceVariables(this Block[] source, KeyValuePair<string, string>[] values)
        {
            if (source == null) return null;
            var blocksS = JsonConvert.SerializeObject(source);
            foreach (var val in values)
                blocksS = blocksS.Replace(val.Key, val.Value);

            return JsonConvert.DeserializeObject<Block[]>(blocksS);
        }
    }
}