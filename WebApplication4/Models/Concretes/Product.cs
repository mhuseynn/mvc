using WebApplication4.Models.Abstracts;

namespace WebApplication4.Models.Concretes;

public class Product : BaseEntity
{
    public string Name { get; set; }


    public string Description { get; set; }


    public double? Price { get; set; }


    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public List<ProductImage> Images { get; set; }
}
