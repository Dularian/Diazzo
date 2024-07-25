namespace Diazzo.Domain
{
    [Table("Round")]
    public class Round : EntityBase
    {
        public DateTime RoundDate { get; set; } = DateTime.Now;
        public string Player { get; set; } = string.Empty;
        public int Score { get; set; }
        public string CourseName { get; set; }
        public string RoundGuid { get; set; } = string.Empty;

    }

}
