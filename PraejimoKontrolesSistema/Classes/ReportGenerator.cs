using PraejimoKontrolesSistema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema.Classes
{
    public class ReportGenerator
    {
        private ReportRepository reportRepository;
        private List<Report> reportList;
        public ReportGenerator(ReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
            reportList = new List<Report>();
        }
        public List<Report> GenerateReport()
        {
            List<Report> data = reportRepository.GetReports();

            Console.WriteLine("Enter date from :");
            string dateFrom = Console.ReadLine();
            Console.WriteLine("Enter date till :");
            string dateTill = Console.ReadLine();
            DateTime From = DateTime.Parse(dateFrom);
            DateTime Till = DateTime.Parse(dateTill);
            foreach (Report report in data)
            {
                if (report.WasPassing >= From && report.WasPassing <= Till)
                {
                    reportList.Add(report);
                }
            }
            return reportList;
        }        
    }
}
