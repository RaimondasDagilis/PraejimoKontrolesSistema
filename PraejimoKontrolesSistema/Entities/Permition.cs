using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema
{
    public class Permition
    {
        private int id;
        public int Id { get { return id; } }
        private int emploeeID;
        public int EmploeeID { get { return emploeeID; } }
        private DateOnly validFrom;
        public DateOnly ValidFrom { get { return validFrom; } }
        private DateOnly validTill;
        public DateOnly ValidTill { get { return validTill; } }
        public Permition(int id, int emploeeID, string validFrom, string validTill)
        {
            this.id = id;
            this.emploeeID = emploeeID;
            this.validFrom = StringToDate(validFrom);
            this.validTill = StringToDate(validTill);
        }
        private DateOnly StringToDate(string dateString)
        {
            return DateOnly.FromDateTime(DateTime.Parse(dateString));
        }
        public bool IsValid()
        {
            int test = ValidTill.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber;
            return test > 0 ? true : false;
        }        
    }
}
