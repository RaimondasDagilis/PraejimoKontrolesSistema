using PraejimoKontrolesSistema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema.Classes
{
    public class Administration
    {
        private EmploeeRepository emploeeRepository;
        private PassingRepository passingRepository;
        private PermissionRepository permissionRepository;
        public Administration(EmploeeRepository emploeeRepository, PassingRepository passingRepository, PermissionRepository permissionRepository)
        {
            this.emploeeRepository = emploeeRepository;
            this.passingRepository = passingRepository;
            this.permissionRepository = permissionRepository;
        }
        public void Init()
        {
            string menu = "";
            while (!menu.ToLower().Equals("q"))
            {
                Console.Clear();
                Console.Write("[1] Extend permit [2] Search for emploee by name [3] Delete emploee info [Q] Back to Main menu : ");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        ExtendPermit();
                        break;
                    case "2":
                        break;
                    default:
                        break;
                }
            }
        }
        private void ExtendPermit()
        {
            string menu = "";
            int id;
            Permition permition;
            while (!menu.ToLower().Equals("q"))
            {
                Console.Clear();
                Console.Write("Select permit by [1] Permit ID [2] Emploee ID [Q] Back to Admin menu : ");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.Write("Enter permit ID : ");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            permition = permissionRepository.GetPermitions(id);
                            Console.Write("Enter permision end date : ");
                            permition.ValidTill = DateOnly.Parse(Console.ReadLine());
                            DataWriter.PushWholeListToFile(permissionRepository.GetPermitions());
                        }
                        else
                        { 
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Entered wrong ID");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    case "2":
                        Console.Write("Enter emploee ID : ");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
