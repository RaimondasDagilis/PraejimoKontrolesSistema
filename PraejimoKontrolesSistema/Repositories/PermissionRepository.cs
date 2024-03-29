﻿using PraejimoKontrolesSistema.Classes;

namespace PraejimoKontrolesSistema.Repositories
{
    public class PermissionRepository
    {
        private List<Permition> permitions;
        private string fileName;
        public PermissionRepository()
        {
            permitions = new List<Permition>();
            fileName = "permissions.xml";
            if (DataWriter.CheckFile(fileName, "permissions"))
            {
                DataReader.GetDataFromFile(permitions);
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
        public Permition GetPermitionsByEmploeeId(int id)
        {
            return permitions.FirstOrDefault(x => x.EmploeeID == id);
        }
        public void AddPermition(int id, string validFrom, string validTill)
        {            
            Permition permition = new Permition(NextId(), id, validFrom, validTill);
            permitions.Add(permition);
            DataWriter.PushDataToFile(permition, fileName);            
        }        
        private int NextId()
        {
            if (permitions.Count == 0)
            {
                return 1;
            }
            return permitions.Max(permition => permition.Id) + 1;
        }
    }
}
