/*using System.Collections.Generic;
using System.Linq;
using EntranceTestCore6.Data;
using Microsoft.EntityFrameworkCore;

public class ApplicationUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ApplicationUserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<ApplicationUser> GetAll()
    {
        return _dbContext.ApplicationUsers.ToList();
    }

    public ApplicationUser GetById(string id)
    {
        return _dbContext.ApplicationUsers.FirstOrDefault(u => u.Id == id);
    }

    public void Add(ApplicationUser user)
    {
        _dbContext.ApplicationUsers.Add(user);
        _dbContext.SaveChanges();
    }

    public void Update(ApplicationUser user)
    {
        _dbContext.Entry(user).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void Delete(string id)
    {
        var user = GetById(id);
        if (user != null)
        {
            _dbContext.ApplicationUsers.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}*/