using WebApplication4.Models.Abstracts;

namespace WebApplication4.Models.Concretes;

public class Tag :  BaseEntity
{
    public string? Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}
