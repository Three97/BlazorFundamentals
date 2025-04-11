using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Components.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;
        private Employee? _selectedEmployee;

        protected async override Task OnInitializedAsync()
        {
            // await Task.Delay(2000);
            Employees = MockDataService.Employees;
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
        }
    }
}
