namespace Diazzo.Domain;

[Table("Course")]
public class Course : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public int Zip { get; set; }
    public int HoleCount { get; set; }
    public string Rating { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
