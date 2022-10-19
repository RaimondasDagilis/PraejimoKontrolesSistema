using PraejimoKontrolesSistema.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PraejimoKontrolesSistema.Repositories
{
    public class PermissionRepository
    {
        private List<Permition> permitions;
        public PermissionRepository()
        {
            permitions = new List<Permition>();
            DataReader.GetDataFromFile(permitions);            
        }
        /*private void GetPermissionsFromFile()
        {
            var maps = from c in XElement.Load("permissions.xml").Elements("permission")
                       select c;
            foreach (var item in maps)
            {
                Permitions.Add(new Permition(int.Parse(item.Element("id").Value), int.Parse(item.Element("emploee_id").Value), item.Element("valid_from").Value, item.Element("valid_till").Value));
            }
        }*/
        private void Print()
        {
            foreach (var permition in permitions)
            {
                Console.WriteLine(permition.ValidFrom + " " + permition.ValidTill);
            }
        }
        public List<Permition> GetPermitions()
        { 
            return permitions;
        }
        public Permition GetPermitions(int id)
        {
            return permitions.FirstOrDefault(x => x.Id == id);
        }
    }
}
