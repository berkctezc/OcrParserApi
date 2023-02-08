namespace OcrParserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OcrParserController : ControllerBase
{
    [HttpPost("parse")]
    public FileContentResult Parse(List<OcrData> ocr)
    {
        var pointsInSpace = new List<VerText>();
        var bounds = ocr[0].BoundingPoly.Vertices;

        var height = (int) Math.Sqrt(Math.Pow(bounds[0].X - bounds[3].X, 2) + Math.Pow(bounds[0].Y - bounds[3].Y, 2));
        var width = (int) Math.Sqrt(Math.Pow(bounds[3].X - bounds[2].X, 2) + Math.Pow(bounds[3].Y - bounds[2].Y, 2));

        ocr.Remove(ocr[0]);
        ocr.ForEach(o => pointsInSpace.Add(new VerText(
            new Vertex
            {
                X = o.BoundingPoly.Vertices[3].X,
                Y = o.BoundingPoly.Vertices[3].Y
            }, o.Description)));

        var image = new Image<Rgba32>(width + 24, height + 150);
        var font = new Font(SystemFonts.Families.First(x => x.Name == "Arial"), 16);

        foreach (var p in pointsInSpace)
            image.Mutate(x => x.DrawText(p.Text, font, Color.White, new PointF(p.Vertex.X, p.Vertex.Y)));

        using var memStream = new MemoryStream();
        image.Save(memStream, new JpegEncoder());
        var file = memStream.ToArray();

        return new FileContentResult(file, "application/octet-stream")
        {
            FileDownloadName = "output.jpg"
        };
    }
}