using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PraejimoKontrolesSistema.Classes
{
    public static class DataReader
    {
        public static void GetDataFromFile(List<Emploee> list)
        {
            var maps = from c in XElement.Load("emploees.xml").Elements("emploee")
                       select c;
            foreach (var item in maps)
            {
                list.Add(new Emploee(int.Parse(item.Element("id").Value), item.Element("first_name").Value, item.Element("last_name").Value, item.Element("departament").Value));
            }
        }
        public static void GetDataFromFile(List<Permition> list)
        {
            var maps = from c in XElement.Load("permissions.xml").Elements("permission")
                       select c;
            foreach (var item in maps)
            {
                list.Add(new Permition(int.Parse(item.Element("id").Value), int.Parse(item.Element("emploee_id").Value), item.Element("valid_from").Value, item.Element("valid_till").Value));
            }
        }
        public static void GetDataFromFile(List<Passing> list)
        {
            var maps = from c in XElement.Load("passings.xml").Elements("passing")
                       select c;
            foreach (var item in maps)
            {
                list.Add(new Passing(int.Parse(item.Element("id").Value), int.Parse(item.Element("emploeesID").Value), DateTime.Parse(item.Element("wasPassing").Value), bool.Parse(item.Element("passed").Value)));
            }
        }
    }
}
