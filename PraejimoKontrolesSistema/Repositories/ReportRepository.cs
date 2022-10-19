using PraejimoKontrolesSistema.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PraejimoKontrolesSistema.Repositories
{
    public class ReportRepository
    {
        private List<Report> reports;
        private string FileName;
        public ReportRepository()
        {
            reports = new List<Report>();
            FileName = "reports.xml";
            CheckFile();
        }
        public List<Report> GetReports()
        { 
            return reports;
        }
        public Report GetReports(int id)
        {
            return null;
        }
        private int NextId()
        {
            if (reports.Count == 0)
            {
                return 1;
            }
            return reports.Max(report => report.Id) + 1; 
        }
        public void AddReport(int emploeesID, DateTime waspassing, bool passed)
        {
            Report report = new Report(NextId(), emploeesID, waspassing, passed);
            reports.Add(report);
            PushReportToFile(report);
        }
        private void CheckFile()
        {
            if (!File.Exists(FileName))
            {
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    writer.WriteLine("<?xml version='1.0' encoding='UTF-8'?>");
                    writer.WriteLine("<reports>");
                    writer.WriteLine("</reports>");
                }
            }
            else
            {
                DataReader.GetDataFromFile(reports);
            }
        }
        private void PushReportToFile(Report report)
        {
            string data = $"<report><id>{report.Id}</id><emploeesID>{report.EmploeesID}</emploeesID><wasPassing>";
            data += report.WasPassing.ToString("yyyy/MM/dd HH:mm:ss");
            data += $"</wasPassing><passed>{report.Passed}</passed></report>";
            var allLines = File.ReadAllLines(FileName).ToList();
            allLines.Insert(allLines.Count - 1, data);
            File.WriteAllLines(FileName, allLines.ToArray());
        }
    }
}
