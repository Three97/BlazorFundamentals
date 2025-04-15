using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services;

public interface IEmployeeDataService
{
    Task<IEnumerable<Employee?>> GetEmployees();
    
    Task<Employee?> GetEmployeeById(int id);
}