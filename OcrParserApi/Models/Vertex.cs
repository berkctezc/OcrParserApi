namespace OcrParserApi.Models;

public class Vertex
{
    [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
    public int X { get; set; }

    [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
    public int Y { get; set; }
}

public record VerText(Vertex Vertex, string Text);
