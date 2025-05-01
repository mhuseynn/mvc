using WebApplication4.Models.Abstracts;

namespace WebApplication4.Models.Concretes;

public class ProductImage : BaseEntity
{


    public string ImageUrl { get; set; }

    public bool IsPrime { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }
}
