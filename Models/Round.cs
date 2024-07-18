namespace Diazzo.Domain
{
    [Table("Round")]
    public class Round : EntityBase
    {
        public DateTime RoundDate { get; set; } = DateTime.Now;
        public int Ace { get; set; }
        public int Eagles { get; set; }
        public int Birdies { get; set; }
        public int Pars { get; set; }
        public int Bogeys { get; set; }
        public int DoubleBogeys { get; set; }
        public int TripleBogeys { get; set; }
        public int Score { get; set; }

        //Distances array
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Round))]
        public string CourseName { get; set; } = string.Empty;

    }

}
