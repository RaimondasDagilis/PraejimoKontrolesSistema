
namespace PraejimoKontrolesSistema
{
    public class Emploee
    {
        private int id;
        public int Id { get { return id; } }
        private string name;
        public string Name { get { return name; } }
        private string surname;        
        public string Surname { get { return surname; } }
        public string FullName { get { return name + " " + surname; } }
        private string department;
        public string Department { get { return department; } }
        
        public Emploee(int id, string name, string surname, string department)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.department = department;
        }        
    }
}
