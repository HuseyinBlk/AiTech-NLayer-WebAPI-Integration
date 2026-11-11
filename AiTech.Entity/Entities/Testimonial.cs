using AiTech.Entity.Entities.Common;

namespace AiTech.Entity.Entities;

public class Testimonial : BaseEntity
{
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
}