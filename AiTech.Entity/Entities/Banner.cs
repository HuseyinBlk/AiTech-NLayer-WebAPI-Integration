using AiTech.Entity.Entities.Common;

namespace AiTech.Entity.Entities;

public class Banner : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string LButtonText { get; set; }
    public string LButtonUrl { get; set; }
    public string RButtonText { get; set; }
    public string RButtonUrl { get; set; }
    public string ImageUrl { get; set; }
    public bool IsActive { get; set; }
    
}