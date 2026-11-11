using AiTech.Entity.Entities.Common;

namespace AiTech.Entity.Entities;

public class Project : BaseEntity
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}