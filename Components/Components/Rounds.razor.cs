namespace Diazzo.Components.Components;

public partial class Rounds : ComponentBase
{

    private List<Round>? RoundList {  get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        try
        {
            RoundList = await RoundDatabase.GetRoundsAsync()! ?? [];
            await base.OnInitializedAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
