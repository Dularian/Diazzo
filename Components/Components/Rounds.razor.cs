namespace Diazzo.Components.Components;

public partial class Rounds : ComponentBase
{
    [Inject] RoundDatabase RoundDatabase {  get; set; }


    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }
}
