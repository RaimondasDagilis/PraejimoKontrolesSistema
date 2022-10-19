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
/*        private void GetEmploeesFromFile()
        {
            var maps = from c in XElement.Load("emploees.xml").Elements("emploee")
                       select c;
            foreach (var item in maps)
            {
                Emploees.Add(new Emploee(int.Parse(item.Element("id").Value), item.Element("first_name").Value, item.Element("last_name").Value, item.Element("departament").Value));
            }
        }        */
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
