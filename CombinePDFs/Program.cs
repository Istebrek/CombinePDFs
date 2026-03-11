using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

string root = Directory.GetCurrentDirectory();

string[] pdfFiles = Directory.GetFiles(root, "*.pdf");

// For specifically ordered files (CTRL + K, CTRL + U to uncomment): 
/*
List<string> pdfFiles = new List<string>
{
    "FirstFileName.pdf",
    "SecondFileName.pdf",
    "ThirdFileName.pdf"
};
*/

PdfDocument combinedDocument = new PdfDocument();

if (pdfFiles != null && pdfFiles.Any().Equals(""))
{
    foreach (var file in pdfFiles)
    {
        PdfDocument currentFile = PdfReader.Open(file, PdfDocumentOpenMode.Import);

        for (int i = 0; i < currentFile.PageCount; i++)
        {
            combinedDocument.AddPage(currentFile.Pages[i]);
        }   
    }

    combinedDocument.Save("CombinedFileName.pdf");
}