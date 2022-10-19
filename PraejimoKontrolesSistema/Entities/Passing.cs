using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema
{
    public class Passing
    {
        private int id;
        public int Id { get { return id; } }
        private int emploeesID;
        public int EmploeesID { get { return emploeesID; } }
        private DateTime wasPassing;
        public DateTime WasPassing { get { return wasPassing; } }
        private bool passed;
        public bool Passed { get { return passed; } }

        public Passing(int id, int emploeesID, DateTime waspassing, bool passed)
        {
            this.id = id;
            this.emploeesID = emploeesID;
            this.wasPassing = waspassing;
            this.passed = passed;
        }        
    }
}
