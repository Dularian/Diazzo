namespace Diazzo.Domain;

[Table("Course")]
public class Course : EntityBase
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonIgnore]
    [JsonPropertyName("zip")]
    public int Zip { get; set; }

    [JsonPropertyName("holeCount")]
    public int HoleCount { get; set; }

    [JsonIgnore]
    [JsonPropertyName("rating")]
    public string Rating { get; set; } = string.Empty;

    [JsonIgnore]
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonIgnore]
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}
