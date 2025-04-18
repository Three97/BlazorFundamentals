using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Services;

public class EmployeeDataDataService : IEmployeeDataService
{
    private IEmployeeRepository _employeeRepository;
    
    public EmployeeDataDataService(IEmployeeRepository employeeRepository)
    {
        this._employeeRepository = employeeRepository;
    }
    
    public async Task<IEnumerable<Employee?>> GetEmployees()
    {
        return await _employeeRepository.GetEmployees();
    }

    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await _employeeRepository.GetEmployeeById(id);
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        return await _employeeRepository.AddEmployee(employee);
    }

    public async Task<Employee?> UpdateEmployee(Employee employee)
    {
        return await _employeeRepository.UpdateEmployee(employee);
    }

    public async Task DeleteEmployee(int id)
    {
        await _employeeRepository.DeleteEmployee(id);
    }
}