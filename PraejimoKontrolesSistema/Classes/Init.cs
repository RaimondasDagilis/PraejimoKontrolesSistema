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
                        Console.WriteLine("Generate report.");
                        DateTime from = new DateTime(1, 1, 1);
                        DateTime till = new DateTime(1, 1, 1);
                        while (from.ToString("yyyy/MM/dd").Equals("0001/01/01"))
                        {
                            Console.Write("Enter date from :");
                            from = Validation.ValidateDateTime(Console.ReadLine());
                            from += new TimeSpan(0, 0, 0);
                            if (from.ToString("yyyy/MM/dd").Equals("0001/01/01"))
                            {
                                Validation.Error("Entered wrong date. Try again.");
                            }
                        }
                        while (till.ToString("yyyy/MM/dd").Equals("0001/01/01"))
                        {
                            Console.Write("Enter date till :");
                            till = Validation.ValidateDateTime(Console.ReadLine());
                            till += new TimeSpan(23, 59, 59);
                            if (till.ToString("yyyy/MM/dd").Equals("0001/01/01"))
                            {
                                Validation.Error("Entered wrong date. Try again.");
                            }
                        }
                        List<Report> reportList = reportGenerator.GenerateReport(from, till);
                        string html = GenerateHTML.CreateHtml(reportList, from, till);
                        CreatePDF.CreatePdfFromHtml(html, "Report.pdf");
                        break;
                    case "3":
                        administration.Init();
                        break;
                    default:
                        Validation.Error("Entered non valid menu option. Try again!");
                        break;
                }
            }

        }
    }
}
