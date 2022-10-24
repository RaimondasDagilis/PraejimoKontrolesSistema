
namespace PraejimoKontrolesSistema.Classes
{
    public static class DataWriter
    {
        public static void PushDataToFile(Passing passing, string fileName)
        {            
            var allLines = File.ReadAllLines(fileName).ToList();
            allLines.Insert(allLines.Count - 1, FormatRow(passing));
            File.WriteAllLines(fileName, allLines.ToArray());
        }
        public static void PushDataToFile(Emploee emploee, string fileName)
        {            
            var allLines = File.ReadAllLines(fileName).ToList();            
            allLines.Insert(allLines.Count - 1, FormatRow(emploee));
            File.WriteAllLines(fileName, allLines.ToArray());
        }
        public static void PushDataToFile(Permition permition, string fileName)
        {            
            var allLines = File.ReadAllLines(fileName).ToList();
            allLines.Insert(allLines.Count - 1, FormatRow(permition));
            File.WriteAllLines(fileName, allLines.ToArray());
        }
        public static bool CheckFile(string fileName, string data)
        {
            if (!File.Exists(fileName))
            {
                CreateEmptyFile(fileName, data);
                return false;
            }
            return true;
        }
        private static void CreateEmptyFile(string fileName, string data)
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
                    writer.WriteLine(FormatRow(permition));
                }
                writer.WriteLine("</permissions>");
            }
        }
        public static void PushWholeListToFile(List<Emploee> list)
        {
            using (StreamWriter writer = new StreamWriter("emploees.xml"))
            {
                string row;
                writer.WriteLine("<?xml version='1.0' encoding='UTF-8'?>");
                writer.WriteLine("<emploees>");
                foreach (Emploee emploee in list)
                {
                    writer.WriteLine(FormatRow(emploee));
                }
                writer.WriteLine("</emploees>");
            }
        }
        public static void PushWholeListToFile(List<Passing> list)
        {
            using (StreamWriter writer = new StreamWriter("passings.xml"))
            {
                string row;
                writer.WriteLine("<?xml version='1.0' encoding='UTF-8'?>");
                writer.WriteLine("<passings>");
                foreach (Passing passing in list)
                {                    
                    writer.WriteLine(FormatRow(passing));
                }
                writer.WriteLine("</passings>");
            }
        }
        private static string FormatRow(Permition permition)
        {
            string row = $"<permission>\n<id>{permition.Id}</id>\n<emploee_id>{permition.EmploeeID}</emploee_id>\n<valid_from>";
            row += permition.ValidFrom.ToString("yyyy/MM/dd");
            row += "</valid_from>\n<valid_till>";
            row += permition.ValidTill.ToString("yyyy/MM/dd");
            row += "</valid_till>\n</permission>";
            return row;
        }
        private static string FormatRow(Emploee emploee)
        {
            string row = $"<emploee><id>{emploee.Id}</id><first_name>{emploee.Name}</first_name><last_name>{emploee.Surname}</last_name><departament>{emploee.Department}</departament></emploee>";
            return row;
        }
        private static string FormatRow(Passing passing)
        {
            string row = $"<passing><id>{passing.Id}</id><emploeesID>{passing.EmploeesID}</emploeesID><wasPassing>";
            row += passing.WasPassing.ToString("yyyy/MM/dd HH:mm:ss");
            row += $"</wasPassing><passed>{passing.Passed}</passed></passing>";
            return row;
        }        
    }
}
