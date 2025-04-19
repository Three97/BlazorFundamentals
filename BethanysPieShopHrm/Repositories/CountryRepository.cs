using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories;

public class CountryRepository : ICountryRepository, IDisposable, IAsyncDisposable
{
    private AppDbContext _context;

    public CountryRepository(IDbContextFactory<AppDbContext> factory)
    {
        this._context = factory.CreateDbContext();
    }
    
    public void Dispose()
    {
        this._context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
    
    public async Task<List<Country>> GetAllCountries()
    {
        return await _context.Countries.ToListAsync(); 
    }

    public async Task<Country?> GetCountryId(int id)
    {
        return await _context.Countries.FirstOrDefaultAsync(c => c.CountryId == id);
    }
}