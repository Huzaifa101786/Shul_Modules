using QuestPDF.Fluent;

public class PdfService
{
    public byte[] GeneratePdf(string userText)
    {
        var document = new CustomPdfDocument(userText);
        // Generate the PDF and return it as a byte array
        return document.GeneratePdf();
    }
}
