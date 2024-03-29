﻿using PraejimoKontrolesSistema.Repositories;

namespace PraejimoKontrolesSistema.Classes
{
    public class EntranceControl
    {
        EmploeeRepository emploeeRepository;
        PermissionRepository permissionRepository;
        PassingRepository reportRepository;
        public EntranceControl(EmploeeRepository emploeeRepository, PermissionRepository permissionRepository, PassingRepository reportRepository)
        {
            this.emploeeRepository = emploeeRepository;
            this.permissionRepository = permissionRepository;
            this.reportRepository = reportRepository;
        }

        public void PassControl()
        {
            string userinput;
            int id;
            Console.Clear();
            while (true)
            {
                Console.Write("Enter your ID or [Q] to quit : ");
                userinput = Console.ReadLine().ToLower();
                if (userinput.CompareTo("q") == 0)
                {
                    break;
                }                
                if (int.TryParse(userinput, out id))
                {
                    Permition permition = permissionRepository.GetPermitions(id);
                    if (permition != null && permition.IsValid())
                    {
                        Console.Write("Welcome " + emploeeRepository.GetEmploees(permition.EmploeeID).Name + " " + emploeeRepository.GetEmploees(permition.EmploeeID).Surname + ". ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You can pass.");
                        reportRepository.AddPassing(permition.EmploeeID, DateTime.Now, true);
                    }
                    else if (permition == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your permit ID was not found");
                    }
                    else
                    {
                        Console.Write("Welcome " + emploeeRepository.GetEmploees(permition.EmploeeID).Name + " " + emploeeRepository.GetEmploees(permition.EmploeeID).Surname + ". ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You don't have permition to pass.");
                        reportRepository.AddPassing(permition.EmploeeID, DateTime.Now, false);
                    }                    
                }
                else
                {                    
                    Validation.Error("Entered not valid ID number format. Try again.");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
