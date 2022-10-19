using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema.Classes
{
    public static class GenerateHTML
    {
        public static string CreateHtml(List<Report> list, DateTime from, DateTime till)
        {
            string result = "<h1>Emploees passing between " + from.ToString("yyyy/MM/dd") + " and " + till.ToString("yyyy/MM/dd") + "</h1>";
            result += "<table style =\"width:100%\"><tr style=\"background-color: #BFBFBF\"><th>Full name</th><th>Departament</th><th>Passing date/time</th><th>Access</th></tr>";
            foreach (Report report in list)
            {
                result += FormatTableRow(report);
            }
            result += "</table>";
            return result;
        }
        private static string FormatTableRow(Report report)
        {
            string color = report.Passed.Equals("Access granted") ? "#009933" : "#FF0000";
            string result = string.Format("<tr style=\"background-color: {0}\"><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>", color, report.FullName, report.Department, report.WasPassing, report.Passed);
            return result;
        }
    }
}
