using System.ComponentModel.DataAnnotations;
namespace Domain.Dtos;

public class UpdateTutorDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please, fill the Tutor Full Name")]
    public string? FullName { get; set; }
    [Required(ErrorMessage = "Please, fill the Experience")]
    public int Experience { get; set; }
    [Required(ErrorMessage = "Please, post the Image")]
    public string? Image { get; set; }
    [Required(ErrorMessage = "Please, upload Background Image")]
    public string? BackgroundImage { get; set; }
    [Required(ErrorMessage = "Please, ndicate the Position")]
    public string? Position { get; set; }
}
