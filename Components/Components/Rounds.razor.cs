namespace Diazzo.Components.Components;

public partial class Rounds : ComponentBase
{

    private List<Round>? RoundList {  get; set; } = [];
    private List<IGrouping<string, Round>>? GroupedRounds { get; set; } = [];
    private List<Player> Players { get; set; } = [];
    private List<Course>? CourseList { get; set; } = [];
    private List<string>? PlayerNames { get; set; } = [];
    private List<string>? CourseNames { get; set; } = [];
    private List<string>? CourseCities { get; set; } = [];
    private List<string>? CourseStates { get; set; } = [];

    private string SelectedCity { get; set; } = string.Empty;
    private string SelectedState { get; set; } = "Alabama";
    private string SelectedCourse { get; set; } = string.Empty;

    private Player CurrentPlayer { get; set; } = new();
    private int CurrentHole { get; set; } = 1;
    private bool IsRoundStart { get; set; }
    private bool IsInGame { get; set; }
    private bool IsSetCourse { get; set; }
    private bool IsAddingPlayers { get; set; }
    private bool IsAddDisabled => Players.Count >= 5 || string.IsNullOrEmpty(CurrentPlayer.Name);

    protected override async Task OnInitializedAsync()
    {
        try
        {
            await base.OnInitializedAsync();

            IsRoundStart = false;
            RoundList = await RoundDatabase.GetRoundsAsync()! ?? [];
            CourseList = await RoundDatabase.GetCoursesAsync()! ?? [];
            GroupedRounds = RoundList.GroupBy(r => r.RoundGuid).ToList();

            // get players from DB foreach guid
            //PlayerNames = 

            CourseCities = CourseList!.Where(x => x.State == SelectedState).Select(c => c.City).Distinct().ToList();
            CourseStates = CourseList.OrderBy(x => x.State).Select(c => c.State).Distinct().ToList();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void StartAddingPlayers()
    {
        Players.Clear();
        IsRoundStart = true;
        IsAddingPlayers = true;
    }

    protected async Task FindCourse()
    {
        IsRoundStart = true;
        IsAddingPlayers = false;
        IsSetCourse = true;
    }

    protected void ExitRound()
    {
        Players.Clear();
        SelectedState = "Alabama";
        SelectedCity = string.Empty;
        SelectedCourse = string.Empty;
        CurrentPlayer = new();
        CurrentHole = 1;

        IsRoundStart = false;
        IsAddingPlayers = false;
        IsInGame = false;
        IsSetCourse = false;
    }

    protected void LoadCourses()
    {
        CourseNames = CourseList!.Where(x => x.City == SelectedCity && x.State == SelectedState).Select(x => x.Name).ToList()! ?? [];
        IsRoundStart = true;
        IsAddingPlayers = false;
        IsSetCourse = false;
    }

    protected void StartRound()
    {
        IsSetCourse = false;
        IsInGame = true;
    }

    protected void LoadCities(string state)
    {
        SelectedState = state;
        SelectedCity = string.Empty;
        CourseCities = CourseList!.Where(x => x.State == SelectedState).Select(c => c.City).Distinct().ToList();
    }

    protected void ChangeScore(Player player, bool add = false)
    {
        if (add)
        {
            player.HoleScore++;
        }
        else
        {
            player.HoleScore--;
        }
        
    }

    protected void OnNextHole()
    {
        foreach(Player player in Players)
        {
            player.Score = player.Score + player.HoleScore;
            player.HoleScore = 0;
        }

        if (CurrentHole == 18)
        {
            return;
        }
        CurrentHole++;
    }

    protected async Task CompleteRound()
    {
        OnNextHole();
        var newGuid = Guid.NewGuid().ToString();

        foreach (Player player in Players)
        {
            var round = new Round()
            {
                Score = player.Score,
                Player = player.Name,
                RoundDate = DateTime.Now,
                CourseName = SelectedCourse,
                RoundGuid = newGuid,
            };
            await RoundDatabase.SaveItemAsync(round);
        }
        RoundList = await RoundDatabase.GetRoundsAsync()! ?? [];
        GroupedRounds = RoundList.GroupBy(r => r.RoundGuid).ToList();
        ExitRound();
    }

    #region Player

    protected void AddPlayerToRound()
    {
        if (Players.Count >= 5)
        {
            return;
        }
        else
        {
            Players.Add(CurrentPlayer);
        }
        CurrentPlayer = new();
    }

    protected void UpdateName(string? name = null)
    {
        if (name == null)
        {
            CurrentPlayer.Name = string.Empty;
            return;
        }
        CurrentPlayer.Name = name;

    }

    protected void RemovePlayer(Player player)
    {
        Players.Remove(player);
    }

    #endregion

}
