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
        private PassingRepository passingRepository;
        private ReportGenerator reportGenerator;
        Administration administration;
        public Init()
        {
            emploeeRepository = new EmploeeRepository();
            permissionRepository = new PermissionRepository();
            passingRepository = new PassingRepository();
            entranceControl = new EntranceControl(emploeeRepository, permissionRepository, passingRepository);
            reportGenerator = new ReportGenerator(passingRepository, emploeeRepository);
            administration = new Administration(emploeeRepository, passingRepository, permissionRepository);
       }

        public void Start()
        {

            string menu = "";
            while (menu.ToLower().CompareTo("q") != 0)
            {
                Console.Clear();
                Console.Write("Select menu : [1] Control entrance. [2] Report. [3] Admin menu. [Q] Quit program : ");
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
                        DateTime from = ValidateDate("Enter date from :");
                        DateTime till = ValidateDate("Enter date till :");
                        List<Report> reportList = reportGenerator.GenerateReport(from, till);
                        string html = GenerateHTML.CreateHtml(reportList, from, till);
                        CreatePDF.CreatePdfFromHtml(html, "Report.pdf");
                        break;
                    case "3":
                        administration.Init();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entered non valid menu option. Try again!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }            
            
        }
        private DateTime ValidateDate(string input)
        {
            DateTime result;
            while (true)
            {
                Console.Write(input);
                string date = Console.ReadLine();
                if (DateTime.TryParse(date, out result))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entered wrong date. Try again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            return result;
        }
    }
}
