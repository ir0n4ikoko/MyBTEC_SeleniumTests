using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Words.Saving;

namespace Edi.Advance.BTEC.UiTests.Framework.AsposeFileReader
{
    internal class PdfReader
    {
        public PdfReader()
        {
            RegisterAsposeTotalPdf();
        }

        public static void RegisterAsposeTotalPdf()
        {
            var licensePdf = new License();
            licensePdf.SetLicense(@"Aspose.Total.lic");
        }

        protected bool ValidatePDF(Stream pdfStream, string searchText)
        {
            var pdfDocument = new Document(pdfStream);

            var textAbsorber = new TextAbsorber();

            pdfDocument.Pages.Accept(textAbsorber);

            return textAbsorber.Text.Contains(searchText);
        }

        protected IList<string> ValidatePDF(Stream pdfStream, string[] searchText)
        {
            var pdfDocument = new Document(pdfStream);

            var textAbsorber = new TextAbsorber();

            pdfDocument.Pages.Accept(textAbsorber);
            return searchText.Where(text => !textAbsorber.Text.Contains(text)).ToList();
        }

        protected bool CheckPermission(Stream pdfStream, PdfPermissions permission)
        {
            var pdfDocument = new Document(pdfStream);
            return ((PdfPermissions) pdfDocument.Permissions).HasFlag(permission);
        }
    }
}