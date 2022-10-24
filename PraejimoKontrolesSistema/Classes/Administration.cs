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
            while (!menu.Equals("q"))
            {
                Console.Clear();
                Console.Write("[1]Extend permit [2]Search for emploee by name [3]Delete emploee info [4]Add new emploee [Q]Back to Main menu : ");
                menu = Console.ReadLine().ToLower();
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
                    case "q":
                        break;
                    default:
                        Validation.Error("Entered not existing menu option.");
                        break;
                }
            }
        }
        public void AddEmploee()
        {
            string validFrom = "";
            string validTill = "";
            bool validated = false;
            Console.WriteLine("Creating new emploee.");
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Surname : ");
            string surname = Console.ReadLine();
            Console.Write("Departament : ");
            string departament = Console.ReadLine();
            while (!validated)
            {
                Console.Write("Permit start date : ");            
                validFrom = Console.ReadLine();
                if (Validation.ValidateDateOnly(validFrom).ToString("yyyy/MM/dd").Equals("0001/01/01"))
                {
                    Validation.Error("Wrong date format.Try yyyy/MM/dd");
                }
                else
                { 
                    validated = true;
                }
            }
            validated = false;
            while (!validated)
            {
                Console.Write("Permit end date : ");
                validTill = Console.ReadLine();
                if (Validation.ValidateDateOnly(validTill).ToString("yyyy/MM/dd").Equals("0001/01/01"))
                {
                    Validation.Error("Wrong date format.Try yyyy/MM/dd");
                }
                else
                {
                    validated = true;
                }
            }            
            int id = emploeeRepository.AddEmploee(name, surname, departament);
            permissionRepository.AddPermition(id, validFrom, validTill);
            PrintEmploeeInfo(emploeeRepository.GetEmploees(id));
            Console.WriteLine("Emploee created. Press any key to continue.");
            Console.ReadKey();
        }
        public void DeleteEmploeeInfo()
        {
            int id = 0;
            while (id == 0)
            {
                Console.Write("Enter emploees ID : ");
                id = Validation.ValidateInteger(Console.ReadLine());
                if (id == 0)
                {                    
                    Validation.Error("Entered wrong ID. Try again.");                 
                }
            }
            Emploee emploee = emploeeRepository.GetEmploees(id);
            if (emploee == null)
            {
                Validation.Error("Emploee with this ID was not found!");
            }
            else
            {
                PrintEmploeeInfo(emploee);
                Console.Write("Are you sure you want to delete this emploee and all records that belongs to it?[y/n] : ");
                string confirm = Console.ReadLine();
                if (confirm.ToLower().Equals("y"))
                {
                    emploeeRepository.GetEmploees().RemoveAll(x => x.Id == id);
                    permissionRepository.GetPermitions().RemoveAll(x => x.EmploeeID == id);
                    passingRepository.GetPassings().RemoveAll(x => x.EmploeesID == id);                    
                    DataWriter.PushWholeListToFile(emploeeRepository.GetEmploees());
                    DataWriter.PushWholeListToFile(permissionRepository.GetPermitions());
                    DataWriter.PushWholeListToFile(passingRepository.GetPassings());
                    Console.WriteLine("Records deleted. Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Operation cancelled.");
                    Console.ReadKey();
                }
            }
        }
        private void PrintEmploeeInfo(Emploee emploee)
        {
            Console.WriteLine($"Emploee ID : {emploee.Id} Emploee : {emploee.FullName} Departament {emploee.Department}");
            Console.WriteLine("Permit ID : {0} Permit valid from : {1} till {2}", permissionRepository.GetPermitionsByEmploeeId(emploee.Id).Id, permissionRepository.GetPermitionsByEmploeeId(emploee.Id).ValidFrom.ToString("yyyy/MM/dd"), permissionRepository.GetPermitionsByEmploeeId(emploee.Id).ValidTill.ToString("yyyy/MM/dd"));
        }
        private void ListEmploeesByNameGiven()
        {
            int recordsFound = 0;
            Console.Write("Enter fragment of full name of Emploee : ");
            string name = Console.ReadLine().ToLower();
            List<Emploee> list = emploeeRepository.GetEmploees();
            foreach (Emploee emploee in list)
            {
                if (emploee.FullName.ToLower().Contains(name))
                {
                    PrintEmploeeInfo(emploee);
                    Console.WriteLine("");
                    recordsFound++;
                }
            }
            if (recordsFound == 0)
            {
                Console.WriteLine("No records found");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void ExtendPermit()
        {
            string menu = "";
            while (!menu.ToLower().Equals("q"))
            {
                Console.Clear();
                Console.Write("Select permit by [1]Permit ID [2]Emploee ID [Q]Back to Admin menu : ");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        ExtendPermit(1);
                        break;
                    case "2":
                        ExtendPermit(2);
                        break;
                    default:
                        break;
                }
            }
        }
        private void ExtendPermit(int option)
        {            
            int id = 0;
            DateOnly validTill = new DateOnly(1, 1, 1);
            Permition permition;
            Console.WriteLine("Select permit by ID");
            while (id == 0)
            {
                Console.Write("Enter ID : ");
                id = Validation.ValidateInteger(Console.ReadLine());
                if (id == 0)
                {
                    Validation.Error("Entered wrong ID. Try again.");
                }
            }
            if (option == 1)
            {
                permition = permissionRepository.GetPermitions(id);
            }
            else 
            {
                permition = permissionRepository.GetPermitionsByEmploeeId(id);
            }
            if (permition == null)
            {
                Validation.Error("Permition does not exist.");
            }
            else
            {
                PrintEmploeeInfo(emploeeRepository.GetEmploees(permition.EmploeeID));
                while (validTill.ToString("yyyy/MM/dd").CompareTo("0001/01/01") == 0)
                {
                    Console.Write("Enter permision end date : ");
                    validTill = Validation.ValidateDateOnly(Console.ReadLine());
                    if (validTill.ToString("yyyy/MM/dd").CompareTo("0001/01/01") == 0)
                    {
                        Validation.Error("Entered wrong date.");                        
                    }
                    else
                    {
                        permition.ValidTill = validTill;
                        DataWriter.PushWholeListToFile(permissionRepository.GetPermitions());
                    }
                }
            }
        }
    }
}
