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

    public async Task<Employee> AddEmployee(Employee employee)
    {
        var addedEntity = await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
        
        return addedEntity.Entity;
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var foundEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

        if (foundEmployee == null) return null;
        
        foundEmployee.CountryId = employee.CountryId;
        foundEmployee.MaritalStatus = employee.MaritalStatus;
        foundEmployee.BirthDate = employee.BirthDate;
        foundEmployee.City = employee.City;
        foundEmployee.Email = employee.Email;
        foundEmployee.FirstName = employee.FirstName;
        foundEmployee.LastName = employee.LastName;
        foundEmployee.Gender = employee.Gender;
        foundEmployee.PhoneNumber = employee.PhoneNumber;
        foundEmployee.Smoker = employee.Smoker;
        foundEmployee.Street = employee.Street;
        foundEmployee.Zip = employee.Zip;
        foundEmployee.JobCategoryId = employee.JobCategoryId;
        foundEmployee.Comment = employee.Comment;
        foundEmployee.ExitDate = employee.ExitDate;
        foundEmployee.JoinedDate = employee.JoinedDate;
        foundEmployee.ImageContent = employee.ImageContent;
        foundEmployee.ImageName = employee.ImageName;

        await _dbContext.SaveChangesAsync();

        return foundEmployee;
    }

    public async Task DeleteEmployee(int id)
    {
        var foundEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        if (foundEmployee == null) return;

        _dbContext.Employees.Remove(foundEmployee);
        
        await _dbContext.SaveChangesAsync();
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