using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema
{
    public class Report
    {
        private int id;
        public int Id { get { return id; } }
        private int emploeesId;
        public int EmploeesId { get { return emploeesId; } }
        
        private string name;
        public string Name { get { return name; } }
        private string surname;
        public string Surname { get { return surname; } }
        public string FullName { get { return name + " " + surname; } }
        private string department;
        public string Department { get { return department; } }
        private DateTime wasPassing;
        public string WasPassing { get { return wasPassing.ToString("yyyy/MM/dd HH:mm:ss"); } }
        private string passed;
        public string Passed { get { return passed; } }
        public Report(int id, int emploeesId, string name, string surname, string department, DateTime wasPassing, bool passed)
        {
            this.id = id;
            this.emploeesId = emploeesId;
            this.name = name;
            this.surname = surname;
            this.department = department;
            this.wasPassing = wasPassing;
            this.passed = passed ? "Granted" : "Denied";
        }

    }
}
