using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddEmployeeDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "The email is required")]

    public string Email { get; set; }
    public string Phone { get; set; }
    public int DepartmentId { get; set; }
}