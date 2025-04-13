using BethanysPieShopHRM.Components.Widgets;

namespace BethanysPieShopHRM.Components.Pages;

public partial class Home
{
    public List<Type> Widgets = new List<Type>
    {
        typeof(EmployeeCountWidget),
        typeof(InboxWidget)
    };
}