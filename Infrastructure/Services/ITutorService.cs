using Domain.Dtos;

namespace Infrastructure.Services;

public interface ITutorService
{
    Task<AddTutorDto> CreateTutor(AddTutorDto tutorDto);
    Task<bool> DeleteTutor(int id);
    Task<UpdateTutorDto> EditTutor(UpdateTutorDto tutorDto);
    Task<UpdateTutorDto> GetTutorById(int id);
    Task<List<GetTutorDto>> GetTutors();
}
