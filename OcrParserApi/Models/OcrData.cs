namespace OcrParserApi.Models;

public class OcrData
{
    [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)]
    public string? Locale { get; set; } = "tr";

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("boundingPoly", NullValueHandling = NullValueHandling.Ignore)]
    public BoundingPoly BoundingPoly { get; set; }
}