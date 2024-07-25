namespace Diazzo.Models;

public class Player : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public int Score { get; set; }
    public int HoleScore { get; set; }
}