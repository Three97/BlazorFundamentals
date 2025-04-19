using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services;

public interface IEmployeeDataService
{
    Task<IEnumerable<Employee?>> GetEmployees();
    
    Task<Employee?> GetEmployeeById(int id);
    
    Task<Employee> AddEmployee(Employee employee);
    
    Task<Employee?> UpdateEmployee(Employee employee);
    
    Task DeleteEmployee(int id);
}