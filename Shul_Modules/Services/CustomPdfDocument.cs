using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

public class CustomPdfDocument : IDocument
{
    private readonly string header;
    private readonly string paragraph1;
    private readonly string paragraph2;
    private readonly bool isParagraph1Bold;
    private readonly bool isParagraph1Italic;
    private readonly int paragraph1FontSize;
    private readonly bool isParagraph2Bold;
    private readonly bool isParagraph2Italic;
    private readonly int paragraph2FontSize;

    public CustomPdfDocument(string header, string paragraph1, string paragraph2, bool isParagraph1Bold, bool isParagraph1Italic, int paragraph1FontSize, bool isParagraph2Bold, bool isParagraph2Italic, int paragraph2FontSize)
    {
        this.header = header;
        this.paragraph1 = paragraph1;
        this.paragraph2 = paragraph2;
        this.isParagraph1Bold = isParagraph1Bold;
        this.isParagraph1Italic = isParagraph1Italic;
        this.paragraph1FontSize = paragraph1FontSize;
        this.isParagraph2Bold = isParagraph2Bold;
        this.isParagraph2Italic = isParagraph2Italic;
        this.paragraph2FontSize = paragraph2FontSize;
    }

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(40);
            page.Header().Text(header).FontSize(20).Bold();

            page.Content().Column(column =>
            {
                column.Spacing(10);

                // Paragraph 1
                var paragraph1Text = column.Item().Text(paragraph1).FontSize(paragraph1FontSize);
                if (isParagraph1Bold)
                {
                    paragraph1Text.Bold();
                }
                if (isParagraph1Italic)
                {
                    paragraph1Text.Italic();
                }

                // Paragraph 2
                var paragraph2Text = column.Item().Text(paragraph2).FontSize(paragraph2FontSize);
                if (isParagraph2Bold)
                {
                    paragraph2Text.Bold();
                }
                if (isParagraph2Italic)
                {
                    paragraph2Text.Italic();
                }
            });

            page.Footer()
                .AlignCenter()
                .Text(x => x.CurrentPageNumber());
        });
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
}
