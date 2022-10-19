using PraejimoKontrolesSistema.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PraejimoKontrolesSistema.Repositories
{
    public class EmploeeRepository
    {
        private List<Emploee> emploees;
        public EmploeeRepository()
        {
            emploees = new List<Emploee>();
            DataReader.GetDataFromFile(emploees);
        }
        public List<Emploee> GetEmploees()
        {
            return emploees;
        }
        public Emploee GetEmploees(int id)
        {
            return emploees.FirstOrDefault(x => x.Id == id);
        }
    }
}
