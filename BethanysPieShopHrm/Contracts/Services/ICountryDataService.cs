using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services;

public interface ICountryDataService
{
    Task<List<Country>> GetAllCountries();
    
    Task<Country?> GetCountryId(int id);
}