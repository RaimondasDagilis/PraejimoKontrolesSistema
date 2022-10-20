using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema.Classes
{
    public static class DataWriter
    {
        public static void PushDataToFile(Passing passing, string fileName)
        {
            string data = $"<passing><id>{passing.Id}</id><emploeesID>{passing.EmploeesID}</emploeesID><wasPassing>";
            data += passing.WasPassing.ToString("yyyy/MM/dd HH:mm:ss");
            data += $"</wasPassing><passed>{passing.Passed}</passed></passing>";
            var allLines = File.ReadAllLines(fileName).ToList();
            allLines.Insert(allLines.Count - 1, data);
            File.WriteAllLines(fileName, allLines.ToArray());
        }
        public static void PushDataToFile(Emploee emploee, string fileName)
        {
            string data = $"<emploee><id>{emploee.Id}</id><first_name>{emploee.Name}</first_name><last_name>{emploee.Surname}</last_name><department>{emploee.Department}</department></emploee>";
            var allLines = File.ReadAllLines(fileName).ToList();            
            allLines.Insert(allLines.Count - 1, data);
            File.WriteAllLines(fileName, allLines.ToArray());
        }
        public static void PushDataToFile(Permition permition, string fileName)
        {
            string data = $"<permition><id>{permition.Id}</id><emploee_id>{permition.EmploeeID}</emploee_id><valid_from>";
            data += permition.ValidFrom.ToString("yyyy/MM/dd");
            data += "</valid_from><valid_till>";
            data += permition.ValidTill.ToString("yyyy/MM/dd");
            data += "</valid_till></permission>";
            var allLines = File.ReadAllLines(fileName).ToList();
            allLines.Insert(allLines.Count - 1, data);
            File.WriteAllLines(fileName, allLines.ToArray());
        }
        public static void CreateEmptyFile(string fileName, string data)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("<?xml version='1.0' encoding='UTF-8'?>");
                writer.WriteLine("<{0}>", data);
                writer.WriteLine("</{0}>", data);
            }
        }
        public static void PushWholeListToFile(List<Permition> list)
        {
            using (StreamWriter writer = new StreamWriter("permissions.xml"))
            {
                string row;
                writer.WriteLine("<?xml version='1.0' encoding='UTF-8'?>");
                writer.WriteLine("<permissions>");
                foreach (Permition permition in list)
                {
                    row = string.Format($"<permission>\n<id>{permition.Id}</id>\n<emploee_id>{permition.EmploeeID}</emploee_id>\n<valid_from>");
                    row += permition.ValidFrom.ToString("yyyy/MM/dd");
                    row += "</valid_from>\n<valid_till>";
                    row += permition.ValidTill.ToString("yyyy/MM/dd");
                    row += "</valid_till>\n</permission>";
                    writer.WriteLine(row);
                }
                writer.WriteLine("</permissions>");
            }
        }
    }
}
