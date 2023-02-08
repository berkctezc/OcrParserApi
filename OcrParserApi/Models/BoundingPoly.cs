namespace OcrParserApi.Models;

public class BoundingPoly
{
    [JsonProperty("vertices", NullValueHandling = NullValueHandling.Ignore)]
    public List<Vertex> Vertices { get; set; }
}