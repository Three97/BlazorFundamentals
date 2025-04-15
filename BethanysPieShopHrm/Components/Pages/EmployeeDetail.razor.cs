using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components.Pages;

public partial class EmployeeDetail
{
    [Parameter]
    public int EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();

    [Inject]
    public IEmployeeDataService EmployeeDataService { get; set; }
        
    protected override async Task OnInitializedAsync()
    {
        Employee = await EmployeeDataService.GetEmployeeById(EmployeeId);
    }

    private void ChangeHolidayState()
    {
        Employee.IsOnHoliday = !Employee.IsOnHoliday;
    }
}