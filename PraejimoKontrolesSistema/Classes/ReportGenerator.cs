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
        private PassingRepository reportRepository;
        private List<Passing> reportList;
        public ReportGenerator(PassingRepository reportRepository)
        {
            this.reportRepository = reportRepository;
            reportList = new List<Passing>();
        }
        public List<Passing> GenerateReport()
        {
            List<Passing> data = reportRepository.GetPassings();            
            DateTime From = ValidateDate("Enter date from :");
            DateTime Till = ValidateDate("Enter date till :");
            foreach (Passing report in data)
            {
                if (report.WasPassing >= From && report.WasPassing <= Till)
                {
                    reportList.Add(report);
                }
            }
            return reportList;
        }        
        private DateTime ValidateDate(string input)
        {
            DateTime result;
            while (true)
            { 
                Console.Write(input);
                string date = Console.ReadLine();
                if (DateTime.TryParse(date, out result))
                {
                    break;
                }
                else
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entered wrong date. Try again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }            
            return result;
        }
    }
}
