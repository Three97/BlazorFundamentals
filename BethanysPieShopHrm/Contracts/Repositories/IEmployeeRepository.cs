using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee?>> GetEmployees();
    
    Task<Employee?> GetEmployeeById(int id);
}