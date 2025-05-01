using WebApplication4.Models.Abstracts;

namespace WebApplication4.Models.Concretes;

public class Category :BaseEntity
{
    public string Name { get; set; }


    public List<Product> Products { get; set; }

}
