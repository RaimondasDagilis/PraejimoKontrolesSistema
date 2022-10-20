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
                Console.Write("[1]Extend permit [2]Search for emploee by name [3]Delete emploee info [4]Add new emploee [Q]Back to Main menu : ");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        ExtendPermit();
                        break;
                    case "2":
                        ListEmploeesByNameGiven();
                        break;
                    case "3":
                        DeleteEmploeeInfo();
                        break;
                    case "4":
                        AddEmploee();
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddEmploee()
        {            
            Console.WriteLine("Creating new emploee.");
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Surname : ");
            string surname = Console.ReadLine();
            Console.Write("Departament : ");
            string departament = Console.ReadLine();
            Console.Write("Permit start date : ");
            string validFrom = Console.ReadLine();
            Console.Write("Permit end date : ");
            string validTill = Console.ReadLine();
            int id = emploeeRepository.AddEmploee(name, surname, departament);
            permissionRepository.AddPermition(id, validFrom, validTill);
            Console.WriteLine("Emploee created. Press any key to continue.");
            Console.ReadKey();
        }
        public void DeleteEmploeeInfo()
        {
            Console.Write("Enter emploees ID : ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine($"Emploee : {emploeeRepository.GetEmploees(id).FullName}");
            Console.WriteLine("Permit valid from : {0} till {1}", permissionRepository.GetPermitionsByEmploeeId(id).ValidFrom.ToString("yyyy/MM/dd"), permissionRepository.GetPermitionsByEmploeeId(id).ValidTill.ToString("yyyy/MM/dd"));
            Console.Write("Are you sure you want to delete this emploee and all records that belongs to it? [y/n] : ");
            string confirm = Console.ReadLine();
            if (confirm.ToLower().Equals("y"))
            {
                emploeeRepository.GetEmploees().RemoveAll(x => x.Id == id);
                permissionRepository.GetPermitions().RemoveAll(x => x.EmploeeID == id);
                passingRepository.GetPassings().RemoveAll(x => x.EmploeesID == id);
                Console.WriteLine("Records deleted. Press any key to continue");
                Console.ReadKey();
            }
            else 
            {
                Console.WriteLine("Operation cancelled.");
                Console.ReadKey();
            }
        }
        private void ListEmploeesByNameGiven()
        {
            Console.Write("Enter fragment of the name or surname of Emploee : ");
            string name = Console.ReadLine().ToLower();
            List<Emploee> list = emploeeRepository.GetEmploees();
            foreach (Emploee emploee in list)
            {
                if (emploee.FullName.ToLower().Contains(name))
                {
                    Console.WriteLine("ID : {0} Name : {1}", String.Format("{0,3}", emploee.Id), emploee.FullName);
                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
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
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            permition = permissionRepository.GetPermitionsByEmploeeId(id);
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
                    default:
                        break;
                }
            }
        }
    }
}
