using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Repositories;

public interface ICountryRepository 
{
    Task<List<Country>> GetAllCountries();
    
    Task<Country?> GetCountryId(int id);
}