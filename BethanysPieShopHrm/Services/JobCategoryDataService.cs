using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Services;

public class JobCategoryDataService :  IJobCategoryDataService
{
    private readonly IJobCategoryRepository  _jobCategoryRepository;

    public JobCategoryDataService(IJobCategoryRepository jobCategoryRepository)
    {
        this._jobCategoryRepository = jobCategoryRepository;
    }
    
    public async Task<List<JobCategory>> GetAllJobCategories()
    {
        return await _jobCategoryRepository.GetAllJobCategories();
    }

    public async Task<JobCategory?> GetJobCategoryById(int id)
    {
        return await _jobCategoryRepository.GetJobCategoryById(id);
    }
}