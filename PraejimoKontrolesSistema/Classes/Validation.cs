using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema.Classes
{
    public static class Validation
    {
        public static int ValidateInteger(string input)
        {
            int result;
            if (int.TryParse(input, out result))
            { 
                return result;
            }
            return 0;
        }
        public static DateOnly ValidateDateOnly(string input)
        { 
            DateOnly result;
            DateOnly.TryParse(input, out result);
            return result;
        }
        public static DateTime ValidateDateTime(string input)
        {
            DateTime result;
            DateTime.TryParse(input, out result);
            return result;            
        }
        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.WriteLine("Press any key to continue.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();            
        }
    }    
}
