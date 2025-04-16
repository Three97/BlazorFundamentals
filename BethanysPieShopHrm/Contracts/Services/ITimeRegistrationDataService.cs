using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services;

public interface ITimeRegistrationService
{
    Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId);
    
    Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start);
    
    Task<int> GetTimeRegistrationCountForEmployee(int employeeId);
}