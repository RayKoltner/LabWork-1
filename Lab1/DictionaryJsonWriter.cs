using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab1
{
    internal class DictionaryJsonWriter : Lab1.@interface.IDictionaryJsonWriter
    {
        Encoding Encoding { get; set; }
        JsonSerializerOptions Options { get; set; }
        public DictionaryJsonWriter()
        {
            this.Encoding = Encoding.Unicode;
            this.Options = new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true };
        }
        public bool WriteToJson(DictionaryBaseType dictionary, string outputPath)
        {
            bool possiblePath = outputPath.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            if (!possiblePath)
            {
                return false;
            }
            string json = JsonSerializer.Serialize(dictionary, Options);
            if (!outputPath.EndsWith(".json"))
            {
                File.WriteAllText(outputPath + ".json", json);
            }
            else
            {
                File.WriteAllText(outputPath, json, Encoding);
            }
            return true;
        }

        public bool WriteManyToJson(List<DictionaryBaseType> dictionaries, string outputPath)
        {
            bool possiblePath = outputPath.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            if (!possiblePath)
            {
                return false;
            }
            string json = JsonSerializer.Serialize(dictionaries, Options);
            if (!outputPath.EndsWith(".json"))
            {
                File.WriteAllText(outputPath + "/N018.json", json);
            }
            else
            {
                File.WriteAllText(outputPath, json, Encoding);
            }
            return true;
        }
    }
}
