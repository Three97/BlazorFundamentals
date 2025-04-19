using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services;

public interface IJobCategoryDataService
{
    Task<List<JobCategory>> GetAllJobCategories();
    
    Task<JobCategory?> GetJobCategoryById(int id);
}