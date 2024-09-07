using QuestPDF.Fluent;

/*public class PdfService
{
    public byte[] GeneratePdf(string userText)
    {
        var document = new CustomPdfDocument(userText);
        // Generate the PDF and return it as a byte array
        return document.GeneratePdf();
    }
}*/

public class PdfService
{
    public byte[] GeneratePdf(string header, string paragraph1, string paragraph2, bool isParagraph1Bold, bool isParagraph1Italic, int paragraph1FontSize, bool isParagraph2Bold, bool isParagraph2Italic, int paragraph2FontSize)
    {
        var document = new CustomPdfDocument(header, paragraph1, paragraph2, isParagraph1Bold, isParagraph1Italic, paragraph1FontSize, isParagraph2Bold, isParagraph2Italic, paragraph2FontSize);

        // Generate the PDF and return as a byte array
        return document.GeneratePdf();
    }
}
