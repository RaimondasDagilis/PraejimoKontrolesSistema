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
