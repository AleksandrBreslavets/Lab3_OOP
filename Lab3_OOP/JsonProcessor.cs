using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace Lab3_OOP
{
    internal class JsonProcessor
    {
        public static void Serialize(string path, ObservableCollection<ScientificWork> results)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            using (FileStream fstream = new FileStream(path, FileMode.Create))
            {

                JsonSerializer.Serialize(fstream, results, options);
            }
        }

        public static ObservableCollection<ScientificWork> Deserialize(string path)
        {
            ObservableCollection<ScientificWork> results = new ObservableCollection<ScientificWork>();
            using (FileStream fstream = new FileStream(path, FileMode.Open))
            {
                var works = JsonSerializer.Deserialize<List<ScientificWork>>(fstream);

                foreach (ScientificWork work in works)
                {
                    results.Add(work);
                }

                return results;
            }
        }
    }
}
