using HomeTaskApi2.Business.DTOs.GenreDTOs;
using HomeTaskApi2.Core.Entities;

namespace HomeTaskApi2.Business.Services.Interfaces;

public interface IGenreService
{
    Task<IEnumerable<GenreGetDTO>> GetAllAsync();
    Task<GenreGetDTO> GetById(int id);
}
