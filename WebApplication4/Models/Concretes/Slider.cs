using WebApplication4.Models.Abstracts;

namespace WebApplication4.Models.Concretes;

public class Slider : BaseEntity
{
    public string Faiz { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string ImgUrl { get; set; }
}
