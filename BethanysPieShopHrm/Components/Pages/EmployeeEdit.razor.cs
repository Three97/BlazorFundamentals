using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BethanysPieShopHRM.Components.Pages;

public partial class EmployeeEdit : ComponentBase
{
    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }
    
    [Inject]
    public ICountryDataService? CountryDataService { get; set; }
    
    [Inject]
    public IJobCategoryDataService? JobCategoryDataService { get; set; }
    
    [Inject]
    public NavigationManager? NavigationManager { get; set; }
    
    [Parameter]
    public int EmployeeId { get; set; }
    
    [SupplyParameterFromForm]
    public Employee Employee { get; set; } = new ();

    protected bool IsSaved { get; set; } = false;
    
    protected string Message { get; set; } = string.Empty;
    protected string StatusClass { get; set; } = string.Empty;
    
    public List<JobCategory> JobCategories { get; set; } = [];
    public List<Country> Countries { get; set; } = [];

    protected IBrowserFile? SelectedFile;
    
    protected override async Task OnInitializedAsync()
    {
        IsSaved = false;
        JobCategories = await JobCategoryDataService.GetAllJobCategories();
        Countries = await CountryDataService.GetAllCountries();
        
        Employee = await EmployeeDataService.GetEmployeeById(EmployeeId);
    }

    protected async Task HandleValidSubmit()
    {
        if (SelectedFile != null)
        {
            var file = SelectedFile;
            Stream stream = file.OpenReadStream();
            MemoryStream memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);

            Employee.ImageName = file.Name;
            Employee.ImageContent = memoryStream.ToArray();
        }
        
        await EmployeeDataService.UpdateEmployee(Employee);
        
        IsSaved = true;
        StatusClass = "alert-success";
        Message = "Employee updated successfully.";
    }

    protected void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected async Task DeleteEmployee()
    {
        await EmployeeDataService.DeleteEmployee(EmployeeId);
        
        StatusClass = "alert-success";
        Message = "Employee deleted successfully.";
        IsSaved = true;
    }

    protected async Task NavigateToOverview()
    {
        NavigationManager?.NavigateTo("/EmployeeOverview");
    }

    private void OnInputFileChange(InputFileChangeEventArgs obj)
    {
        SelectedFile = obj.File;
        StateHasChanged();
    }
}