using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories;

public class JobCategoryRepository : IJobCategoryRepository, IDisposable, IAsyncDisposable
{
    private readonly AppDbContext _context;

    public JobCategoryRepository(IDbContextFactory<AppDbContext> factory)
    {
        this._context = factory.CreateDbContext();
    }

    public async Task<List<JobCategory>> GetAllJobCategories()
    {
        return await _context.JobCategories.ToListAsync();
    }

    public async Task<JobCategory?> GetJobCategoryById(int id)
    {
        return await _context.JobCategories.FirstOrDefaultAsync(jc => jc.JobCategoryId == id);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}