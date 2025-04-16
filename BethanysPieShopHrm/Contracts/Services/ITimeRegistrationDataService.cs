using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services;

public interface ITimeRegistrationService
{
    Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId);
}