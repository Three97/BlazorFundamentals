using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Services;

public class EmployeeDataDataService : IEmployeeDataService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeDataDataService(IEmployeeRepository employeeRepository, 
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment webHostEnvironment)
    {
        this._employeeRepository = employeeRepository;
        this._httpContextAccessor = httpContextAccessor;
        this._webHostEnvironment = webHostEnvironment;
    }
    
    public async Task<IEnumerable<Employee?>> GetEmployees()
    {
        return await _employeeRepository.GetEmployees();
    }

    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await _employeeRepository.GetEmployeeById(id);
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        return await _employeeRepository.AddEmployee(employee);
    }

    public async Task<Employee?> UpdateEmployee(Employee employee)
    {
        if (employee.ImageContent != null)
        {
            string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            var path = $"{_webHostEnvironment.WebRootPath}/uploads/{employee.ImageName}";
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
            fileStream.Close();

            employee.ImageName = $"https://{currentUrl}/uploads/{employee.ImageName}";
        }
        
        return await _employeeRepository.UpdateEmployee(employee);
    }

    public async Task DeleteEmployee(int id)
    {
        await _employeeRepository.DeleteEmployee(id);
    }
}