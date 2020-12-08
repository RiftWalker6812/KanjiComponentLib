using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace KanjiComponentLib
{

    public static class KanjiTranslator
    {

        //static string path = @"\kanjiaapi_full.json";


        //public static string GetCount()
        //{
        //    return reader.ReadToEnd().Count().ToString();
        //}

        public static kanjisObj K_Collection;
        private const ushort size = 13027;
        public static void ReadKanji()
        {

            string[] SuperStrs = new string[2];
            SuperStrs[0] = @"C:\Users\studentam\Documents\Joshua Hernandez Work\2020-2021\STC Online\Projects\KanjiComponentLib\kanjiapi_full.json";                    

            StreamReader reader = new StreamReader(SuperStrs[0]);

            SuperStrs[1] = reader.ReadToEnd();
            //kanjisObj K_Collection;
            K_Collection = JsonConvert.DeserializeObject<kanjisObj>(SuperStrs[1]);
            SuperStrs = null;
            reader.Dispose();
        }

        public static Dictionary<string, string> GetKtoE()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(size);
            foreach (KeyValuePair<string, kanjiStruct> k in K_Collection.kanjis)
            {
                keyValuePairs.Add(k.Key, k.Value.heisig_en);               
            }           
            K_Collection.kanjis.Clear();
            
            return keyValuePairs;
        }

        //static IEnumerable<T> DeserializeObjects<T>(string input)
        //{
        //    JsonSerializer serializer = new JsonSerializer();
        //    using (var strreader = new StringReader(input))
        //    using (var jsonreader = new JsonTextReader(strreader))
        //    {
        //        //you should use this line
        //        jsonreader.SupportMultipleContent = true;

        //        while (jsonreader.Read())
        //        {
        //            yield return serializer.Deserialize<T>(jsonreader);
        //        }

        //    }
        //}

        public class kanjisObj
        {
            [JsonProperty]
            public IDictionary<string, kanjiStruct> kanjis = new Dictionary<string, kanjiStruct>(size);

        }

        public struct kanjiStruct
        {
            [JsonProperty]
            public string kanji { get; set; } //read this Call
            [JsonProperty]
            int? grade { get; set; }
            [JsonProperty]
            int stroke_count { get; set; }
            [JsonProperty]
            string[] meanings { get; set; }
            [JsonProperty]
            public string heisig_en { get; set; } //read this Return
            [JsonProperty]
            string[] kun_readings { get; set; }
            [JsonProperty]
            string[] on_readings { get; set; }
            [JsonProperty]
            string[] name_readings { get; set; }
            [JsonProperty]
            int? jlpt { get; set; }
            [JsonProperty]
            public string unicode { get; set; }
        }
    }
}
