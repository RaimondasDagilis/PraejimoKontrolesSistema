using PraejimoKontrolesSistema.Classes;

namespace PraejimoKontrolesSistema.Repositories
{
    public class EmploeeRepository
    {
        private List<Emploee> emploees;
        private string fileName;
        public EmploeeRepository()
        {
            emploees = new List<Emploee>();
            fileName = "emploees.xml";
            if (DataWriter.CheckFile(fileName, "emploees"))
            {
                DataReader.GetDataFromFile(emploees);
            }
        }
        public List<Emploee> GetEmploees()
        {
            return emploees;
        }
        public Emploee GetEmploees(int id)
        {
            return emploees.FirstOrDefault(x => x.Id == id);
        }
        public int AddEmploee(string name, string surname, string departament)
        {
            int id = NextId();
            Emploee emploee = new Emploee(id, name, surname, departament);
            emploees.Add(emploee);
            DataWriter.PushDataToFile(emploee, fileName);
            return id;
        }
        private int NextId()
        {
            if (emploees.Count == 0)
            {
                return 1;
            }
            return emploees.Max(emploee => emploee.Id) + 1;
        }
    }
}
