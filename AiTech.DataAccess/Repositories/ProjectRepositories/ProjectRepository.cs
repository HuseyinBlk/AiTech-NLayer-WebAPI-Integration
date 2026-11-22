using AiTech.DataAccess.Context;
using AiTech.DataAccess.Repositories.GenericRepositories;
using AiTech.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace AiTech.DataAccess.Repositories.ProjectRepositories;

public class ProjectRepository(AppDbContext context) : GenericRepository<Project>(context), IProjectRepository
{
    public async Task<List<Project>> GetProjectsWithCategoryAsync()
    {
        return await DbSet.AsNoTracking().Include(x=>x.Category).ToListAsync();
    }
}