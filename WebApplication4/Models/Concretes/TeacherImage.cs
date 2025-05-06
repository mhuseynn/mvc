using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.Models.Abstracts;

namespace WebApplication4.Models.Concretes;

public class TeacherImage : BaseEntity
{
    public string? FullName { get; set; }

    public string? Designation {  get; set; }

    public string? ImgUrl { get; set; }



    [NotMapped]
    public IFormFile formFile { get; set; }

}
