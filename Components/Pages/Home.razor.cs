namespace Diazzo.Components.Pages;

public partial class Home() 
{

    protected override async Task OnInitializedAsync()
    {
        await RoundDatabase.Init();
    }
}
