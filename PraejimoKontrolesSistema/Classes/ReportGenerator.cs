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
        private PassingRepository passingRepository;
        private EmploeeRepository emploeeRepository;
        private List<Report> reportList;
        public ReportGenerator(PassingRepository passingRepository, EmploeeRepository emploeeRepository)
        {
            this.passingRepository = passingRepository;
            this.emploeeRepository = emploeeRepository;
            reportList = new List<Report>();
        }
        public List<Report> GenerateReport()
        {
            List<Passing> data = passingRepository.GetPassings();
            DateTime From = ValidateDate("Enter date from :");
            DateTime Till = ValidateDate("Enter date till :");
            foreach (Passing passing in data)
            {
                if (passing.WasPassing >= From && passing.WasPassing <= Till)
                {
                    int id = GetNextId();
                    Emploee emploee = emploeeRepository.GetEmploees(passing.EmploeesID);
                    string name = emploee.Name;
                    string surname = emploee.Surname;
                    string department = emploee.Department;
                    DateTime waspassing = passing.WasPassing;
                    bool passed = passing.Passed;
                    reportList.Add(new Report(id, name, surname, department, waspassing, passed));
                }
            }
            return reportList;
        }
        private int GetNextId()
        {
            if (reportList.Count == 0)
            {
                return 0;
            }
            return reportList.Count + 1;
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
