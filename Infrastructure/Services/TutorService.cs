using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TutorService : ITutorService
{
    private readonly DataContext _context;

    public TutorService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GetTutorDto>> GetTutors()
    {
        var tutors = await _context.Tutors
            .Select(tu => new GetTutorDto
            {
                Id = tu.Id,
                FullName = tu.FullName,
                Experience = tu.Experience,
                Image = tu.Image,
                BackgroundImage = tu.BackgroundImage,
                Position = tu.Position
            })
            .ToListAsync();

        return tutors;
    }

    public async Task<UpdateTutorDto> GetTutorById(int id)
    {
        var tutor = await _context.Tutors
            .Select(tu => new UpdateTutorDto
            {
                Id = tu.Id,
                FullName = tu.FullName,
                Experience = tu.Experience,
                Image = tu.Image,
                BackgroundImage = tu.BackgroundImage,
                Position = tu.Position
            })
            .FirstOrDefaultAsync(tu => tu.Id == id);

        return tutor;
    }

    public async Task<AddTutorDto> CreateTutor(AddTutorDto tutorDto)
    {
        var tutor = new Tutor
        {
            FullName = tutorDto.FullName,
            Experience = tutorDto.Experience,
            Image = tutorDto.Image,
            BackgroundImage = tutorDto.BackgroundImage,
            Position = tutorDto.Position
        };

        await _context.Tutors.AddAsync(tutor);
        await _context.SaveChangesAsync();

        tutorDto.Id = tutor.Id;
        return tutorDto;
    }

    public async Task<UpdateTutorDto> EditTutor(UpdateTutorDto tutorDto)
    {
        var tutor = await _context.Tutors.FirstOrDefaultAsync(tu => tu.Id == tutorDto.Id);

        if (tutor == null)
        {
            return null;
        }

        tutor.FullName = tutorDto.FullName;
        tutor.Experience = tutorDto.Experience;
        tutor.Image = tutorDto.Image;
        tutor.BackgroundImage = tutorDto.BackgroundImage;
        tutor.Position = tutorDto.Position;

        await _context.SaveChangesAsync();

        var tutorEdited = await GetTutorById(tutor.Id);
        return tutorEdited;
    }

    public async Task<bool> DeleteTutor(int id)
    {
        var tutor = await _context.Tutors.FirstOrDefaultAsync(tu => tu.Id == id);

        if (tutor == null)
        {
            return false;
        }

        _context.Tutors.Remove(tutor);
        await _context.SaveChangesAsync();

        return true;
    }
}
