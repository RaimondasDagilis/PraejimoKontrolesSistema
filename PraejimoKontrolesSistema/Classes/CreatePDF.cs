using IronPdf;
using System.Diagnostics;

namespace PraejimoKontrolesSistema.Classes
{
    public static class CreatePDF
    {
        public static void CreatePdfFromHtml(string input, string fileName)
        {
            var render = new ChromePdfRenderer();
            var pdf = render.RenderHtmlAsPdf(input);
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), fileName));            
        }
        public static void OpenFile(string fileName)
        {
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
