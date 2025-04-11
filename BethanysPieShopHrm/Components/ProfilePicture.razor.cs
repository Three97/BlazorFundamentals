using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components;

public partial class ProfilePicture : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
}