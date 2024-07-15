namespace Diazzo.Domain
{
    [Table("Round")]
    public class Round : RoundEntityBase
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
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Round))]
        public string CourseName { get; set; } = string.Empty;

        public async Task EvaluateHole(int holescore)
        {
            switch(holescore)
            {
                case -3:
                    Ace++;
                    Score -= 3;
                    break;
                case -2:
                    Eagles++;
                    Score -= 2;
                    break;
                case -1:
                    Birdies++;
                    Score -= 1;
                    break;
                case 0:
                    Pars++;
                    break;
                case 1:
                    Bogeys++;
                    Score += 1;
                    break;
                case 2:
                    DoubleBogeys++;
                    Score += 2;
                    break;
                case 3:
                    TripleBogeys++;
                    Score += 3;
                    break;
                default:
                    break;
            }
            await Task.CompletedTask;

        }
    }

}
