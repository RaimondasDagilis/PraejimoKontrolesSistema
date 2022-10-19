using IronPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraejimoKontrolesSistema.Classes
{
    public static class CreatePDF
    {
        public static void CreatePdfFromHtml(string input, string fileName)
        {
            var render = new ChromePdfRenderer();
            var pdf = render.RenderHtmlAsPdf(input);
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), fileName));

            ProcessStartInfo pi = new ProcessStartInfo(fileName);
            pi.Arguments = Path.GetFileName(fileName);
            pi.UseShellExecute = true;
            pi.WorkingDirectory = Path.GetDirectoryName(fileName);
            pi.FileName = fileName;
            pi.Verb = "OPEN";
            Process.Start(pi);
        }
    }
}
