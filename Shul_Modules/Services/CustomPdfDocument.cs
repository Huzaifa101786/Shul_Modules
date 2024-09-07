using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

public class CustomPdfDocument : IDocument
{
    private readonly string userText;

    // Constructor to accept dynamic content like user input
    public CustomPdfDocument(string userText)
    {
        this.userText = userText;
    }

    // This method is responsible for defining the layout
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(40);
            page.Header().Text("PDF Document Title").FontSize(20).Bold();

            page.Content().Column(column =>
            {
                column.Spacing(10);
                column.Item().Text($"Dynamic Text from User: {userText}").FontSize(12);
            });

            page.Footer()
                .AlignCenter()
                .Text(x => x.CurrentPageNumber());
        });
    }

    // Optional metadata for the document
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
}
