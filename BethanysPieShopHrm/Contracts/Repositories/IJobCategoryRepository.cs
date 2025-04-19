using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Repositories;

public interface IJobCategoryRepository
{
    Task<List<JobCategory>> GetAllJobCategories();
    
    Task<JobCategory?> GetJobCategoryById(int id);
}