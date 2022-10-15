namespace Domain.Dtos;

public class AddTutorDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public int Experience { get; set; }
    public string? Image { get; set; }
    public string? BackgroundImage { get; set; }
    public string? Position { get; set; }
}
