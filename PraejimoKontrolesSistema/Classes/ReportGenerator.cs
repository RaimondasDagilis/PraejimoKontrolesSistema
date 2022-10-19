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
        public List<Report> GenerateReport(DateTime from, DateTime till)
        {
            List<Passing> data = passingRepository.GetPassings();            
            foreach (Passing passing in data)
            {
                if (passing.WasPassing >= from && passing.WasPassing <= till)
                {
                    int id = GetNextId();
                    Emploee emploee = emploeeRepository.GetEmploees(passing.EmploeesID);
                    int emploeesID = emploee.Id;
                    string name = emploee.Name;
                    string surname = emploee.Surname;
                    string department = emploee.Department;
                    DateTime waspassing = passing.WasPassing;
                    bool passed = passing.Passed;
                    reportList.Add(new Report(id, emploeesID, name, surname, department, waspassing, passed));
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
    }
}
