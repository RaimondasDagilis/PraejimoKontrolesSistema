using PraejimoKontrolesSistema.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PraejimoKontrolesSistema.Repositories
{
    public class PassingRepository
    {
        private List<Passing> passings;
        private string fileName;
        public PassingRepository()
        {
            passings = new List<Passing>();
            fileName = "passings.xml";
            CheckFile();
        }
        public List<Passing> GetPassings()
        { 
            return passings;
        }
        public Passing GetPassings(int id)
        {
            return passings.FirstOrDefault(x => x.Id == id);
        }
        private int NextId()
        {
            if (passings.Count == 0)
            {
                return 1;
            }
            return passings.Max(report => report.Id) + 1; 
        }
        public void AddPassing(int emploeesID, DateTime waspassing, bool passed)
        {
            Passing passing = new Passing(NextId(), emploeesID, waspassing, passed);
            passings.Add(passing);
            DataWriter.PushDataToFile(passing, fileName);
        }
        private void CheckFile()
        {
            if (!File.Exists(fileName))
            {
                DataWriter.CreateEmptyFile(fileName, "passings");
            }
            else
            {
                DataReader.GetDataFromFile(passings);
            }
        }        
    }
}
