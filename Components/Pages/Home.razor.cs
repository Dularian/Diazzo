namespace Diazzo.Components.Pages;

public partial class Home() 
{
    public bool IsRound { get; set; }
    public bool IsStats { get; set; } = true;

    protected override async Task OnInitializedAsync()
    {
        await RoundDatabase.Init();
    }

    protected void SetRound()
    {
        IsRound = true;
        IsStats = false;
        StateHasChanged();
    }

    protected void SetStats()
    {
        IsRound = false;
        IsStats = true;
        StateHasChanged();
    }

}
