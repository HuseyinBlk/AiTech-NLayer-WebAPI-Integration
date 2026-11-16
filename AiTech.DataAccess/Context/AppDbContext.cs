using AiTech.Entity.Entities;
using AiTech.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace AiTech.DataAccess.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedDate = DateTime.UtcNow;
        
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedDate = DateTime.UtcNow;
                entry.Property(x => x.CreatedDate).IsModified = false; 
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    
    public DbSet<About> Abouts { get; set; }
    public DbSet<AboutItem> AboutItems { get; set; }
    public DbSet<Banner> Banners  { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Choose> Chooses { get; set; }
    public DbSet<FAQ> Faqs { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Social> Socials { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
}