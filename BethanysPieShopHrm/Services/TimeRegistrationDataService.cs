using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Services;

public class TimeRegistrationService : ITimeRegistrationService
{
    private readonly ITimeRegistrationRepository _timeRegistrationRepository;

    public TimeRegistrationService(ITimeRegistrationRepository timeRegistrationRepository)
    {
        _timeRegistrationRepository = timeRegistrationRepository;
    }

    public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
    {
        return await _timeRegistrationRepository.GetTimeRegistrationsForEmployee(employeeId);
    }
}