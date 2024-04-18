using HomeTaskApi2.Business.DTOs.GenreDTOs;

namespace HomeTaskApi2.Business.Services.Interfaces;

public interface IGenreService
{
    Task<IEnumerable<GenreGetDTO>> GetAllAsync();
    Task<GenreGetDTO> GetById(int id);
    Task Create(GenrePostDTO genrePostDTO);
    Task Update(int id, GenrePutDTO genrePutDTO);
    Task Delete(int id);
}
