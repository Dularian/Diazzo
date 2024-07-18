namespace Diazzo.Components.Pages;

public partial class Home() 
{

    [Inject] RoundDatabase? Database { get; set; }


    protected override async Task OnInitializedAsync()
    {
        await Database!.Init();
    }
}
