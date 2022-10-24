using PraejimoKontrolesSistema.Classes;

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
            if (DataWriter.CheckFile(fileName, "passings"))
            {
                DataReader.GetDataFromFile(passings);
            }            
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
            return passings.Max(passing => passing.Id) + 1; 
        }
        public void AddPassing(int emploeesID, DateTime waspassing, bool passed)
        {
            Passing passing = new Passing(NextId(), emploeesID, waspassing, passed);
            passings.Add(passing);
            DataWriter.PushDataToFile(passing, fileName);
        }        
    }
}
