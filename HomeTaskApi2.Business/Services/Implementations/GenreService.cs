using HomeTaskApi2.Business.DTOs.GenreDTOs;
using HomeTaskApi2.Business.Services.Interfaces;
using HomeTaskApi2.Core.Entities;
using HomeTaskApi2.Core.Repositories;

namespace HomeTaskApi2.Business.Services.Implementations;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<IEnumerable<GenreGetDTO>> GetAllAsync()
    {
        var genres = await _genreRepository.GetAllAsync();
        List<GenreGetDTO> genreGetDTOs = new List<GenreGetDTO>();
        foreach (var genre in genres)
        {
            GenreGetDTO genreGetDTO = new GenreGetDTO()
            {
                Id = genre.Id,
                Name = genre.Name
            };
            genreGetDTOs.Add(genreGetDTO);
        }
        return genreGetDTOs;
    }

    public async Task<GenreGetDTO> GetById(int id)
    {
        Genre? genre = await _genreRepository.GetByIdAsync(id);
        if (genre is null) throw new NullReferenceException("Genre is not found");
        GenreGetDTO genreGetDTO = new GenreGetDTO()
        {
            Id = genre.Id,
            Name = genre.Name
        };
        return genreGetDTO;
    }
}
