using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BethanysPieShopHRM.Components.Pages;

public partial class EmployeeDetail
{
    [Parameter]
    public int EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();

    public List<TimeRegistration> TimeRegistrations { get; set; } = [];

    private float itemHeight = 50;
    
    [Inject]
    public IEmployeeDataService EmployeeDataService { get; set; }
    
    [Inject]
    public ITimeRegistrationService TimeRegistrationService { get; set; }
        
    protected override async Task OnInitializedAsync()
    {
        Employee = await EmployeeDataService.GetEmployeeById(EmployeeId);
        TimeRegistrations = await TimeRegistrationService.GetTimeRegistrationsForEmployee(EmployeeId);
    }
    
    public async ValueTask<ItemsProviderResult<TimeRegistration>> LoadTimeRegistrations(ItemsProviderRequest request)
    { 
        await Task.Delay(500);
        
        int totalNumberOfTimeRegistrations = await TimeRegistrationService.GetTimeRegistrationCountForEmployee(EmployeeId);

        var numberOfTimeRegistrations = Math.Min(request.Count, totalNumberOfTimeRegistrations - request.StartIndex);
        var listItems = await TimeRegistrationService.GetPagedTimeRegistrationsForEmployee(EmployeeId, numberOfTimeRegistrations, request.StartIndex);

        return new ItemsProviderResult<TimeRegistration>(listItems, totalNumberOfTimeRegistrations);
    }

    private void ChangeHolidayState()
    {
        Employee.IsOnHoliday = !Employee.IsOnHoliday;
    }
}