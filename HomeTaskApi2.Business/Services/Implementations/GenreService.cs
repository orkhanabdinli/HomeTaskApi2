using HomeTaskApi2.Business.DTOs.GenreDTOs;
using HomeTaskApi2.Business.Services.Interfaces;
using HomeTaskApi2.Core.Entities;
using HomeTaskApi2.Core.Repositories;
using HomeTaskApi2.Data.Contexts;

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

    public async Task Create(GenrePostDTO genrePostDTO)
    {
        Genre genre = new Genre()
        {
            Name = genrePostDTO.Name,
            IsDeleted = genrePostDTO.IsDeleted,
            CreatedDate = DateTime.UtcNow.AddHours(4),
            UpdatedDate = DateTime.UtcNow.AddHours(4)
        };
        await _genreRepository.InsertAsync(genre);
        await _genreRepository.CommitAsync();
    }
    public async Task Update(int id, GenrePutDTO genrePutDTO)
    {
        var genre = await _genreRepository.GetByIdAsync(id);
        if (genre is null) 
            throw new Exception("");

        genre.Name = genrePutDTO.Name;
        genre.IsDeleted = genrePutDTO.IsDeleted;
        genre.UpdatedDate = DateTime.UtcNow.AddHours(4);

        await _genreRepository.CommitAsync();
    }
    public async Task Delete(int id)
    {
        var genre = await _genreRepository.GetByIdAsync(id);
        if (genre is null) 
            throw new Exception("");

        _genreRepository.Delete(genre);
        await _genreRepository.CommitAsync();
    }
}
