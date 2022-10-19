using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema.Classes
{
    public static class DataWriter
    {
        public static void PushDataToFile(Report report, string fileName)
        {
            string data = $"<report><id>{report.Id}</id><emploeesID>{report.EmploeesID}</emploeesID><wasPassing>";
            data += report.WasPassing.ToString("yyyy/MM/dd HH:mm:ss");
            data += $"</wasPassing><passed>{report.Passed}</passed></report>";
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
    }    
}
