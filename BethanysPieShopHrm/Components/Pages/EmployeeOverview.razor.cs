using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;
        private Employee? _selectedEmployee;

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        
        protected async override Task OnInitializedAsync()
        {
            // await Task.Delay(2000);
            Employees = (await EmployeeDataService.GetEmployees()).ToList();
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
        }
    }
}
