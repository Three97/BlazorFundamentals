using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Services;

public class CountryDataService : ICountryDataService
{
    private readonly ICountryRepository _countryRepository;
    
    public CountryDataService(ICountryRepository countryRepository)
    {
        this._countryRepository = countryRepository;
    }
    
    public async Task<List<Country>> GetAllCountries()
    {
        return await _countryRepository.GetAllCountries();
    }

    public async Task<Country?> GetCountryId(int id)
    {
        return await _countryRepository.GetCountryId(id);
    }
}