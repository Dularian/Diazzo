namespace Diazzo.Domain;

public class Course
{
    public string id { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
    public string city { get; set; } = string.Empty;
    public string state { get; set; } = string.Empty;
    public int zip { get; set; }
    public int holeCount { get; set; }
    public string rating { get; set; } = string.Empty;
    public double latitude { get; set; }
    public double longitude { get; set; }
}
