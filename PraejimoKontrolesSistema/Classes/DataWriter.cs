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
