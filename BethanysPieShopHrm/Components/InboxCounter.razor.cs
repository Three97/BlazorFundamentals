using BethanysPieShopHRM.State;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components;

public partial class InboxCounter : ComponentBase
{
    private int MessageCount;
    
    [Inject]
    public ApplicationState ApplicationState { get; set; }

    protected override void OnInitialized()
    {
        MessageCount = new Random().Next(100);
        
        ApplicationState.NumberOfMessages = MessageCount;
    }
}