using PraejimoKontrolesSistema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema.Classes
{
    public class Init
    {
        private EmploeeRepository emploeeRepository;
        private PermissionRepository permissionRepository;
        private EntranceControl entranceControl;
        private PassingRepository reportRepository;
        private ReportGenerator reportGenerator;
        public Init()
        {
            emploeeRepository = new EmploeeRepository();
            permissionRepository = new PermissionRepository();
            reportRepository = new PassingRepository();
            entranceControl = new EntranceControl(emploeeRepository, permissionRepository, reportRepository);
            reportGenerator = new ReportGenerator(reportRepository);
       }

        public void Start()
        {

            string menu = "";
            while (menu.ToLower().CompareTo("q") != 0)
            {
                Console.Clear();
                Console.Write("Select menu : [1] Control entrance. [2] Report. [Q] Quit program : ");
                menu = Console.ReadLine().ToLower();
                switch (menu)
                {
                    case "q":
                        Environment.Exit(0);
                        break;
                    case "1":                        
                        entranceControl.PassControl();
                        break;
                    case "2":
                        reportGenerator.GenerateReport();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entered non valid menu option. Try again!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }            
            
        }
    }
}
