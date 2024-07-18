namespace Diazzo.Components.Pages;

public partial class Home() 
{
    public bool IsHome { get; set; } = true;
    public bool IsRound { get; set; }
    public bool IsStats { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await RoundDatabase.Init();
    }

    protected void SetRound()
    {
        IsHome = false;
        IsRound = true;
        IsStats = false;
    }

    protected void SetHome()
    {
        IsHome = true;
        IsRound = false;
        IsStats = false;
    }

    protected void SetStats()
    {
        IsHome = false;
        IsRound = false;
        IsStats = true;
    }

}
