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
        private string fileName;
        public ReportRepository()
        {
            reports = new List<Report>();
            fileName = "reports.xml";
            CheckFile();
        }
        public List<Report> GetReports()
        { 
            return reports;
        }
        public Report GetReports(int id)
        {
            return reports.FirstOrDefault(x => x.Id == id);
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
            DataWriter.PushDataToFile(report, fileName);
        }
        private void CheckFile()
        {
            if (!File.Exists(fileName))
            {
                DataWriter.CreateEmptyFile(fileName, "reports");
            }
            else
            {
                DataReader.GetDataFromFile(reports);
            }
        }        
    }
}
