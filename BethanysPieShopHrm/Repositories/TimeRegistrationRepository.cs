using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories;

public class TimeRegistrationRepository : ITimeRegistrationRepository, IDisposable
{
    private readonly AppDbContext _appDbContext;

    public TimeRegistrationRepository(IDbContextFactory<AppDbContext> factory)
    {
        _appDbContext = factory.CreateDbContext();
    }

    public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
    {
        return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).OrderBy(t => t.StartTime).ToListAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}