using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BethanysPieShopHRM.Repositories;

public class EmployeeRepository : IEmployeeRepository, IDisposable, IAsyncDisposable
{
    private AppDbContext _dbContext;
    
    public EmployeeRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }
    
    public async Task<IEnumerable<Employee?>> GetEmployees()
    {
        return await _dbContext.Employees
            .ToListAsync();
    }

    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await _dbContext.Employees
            .SingleOrDefaultAsync(e => e.EmployeeId == id);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
    }
}