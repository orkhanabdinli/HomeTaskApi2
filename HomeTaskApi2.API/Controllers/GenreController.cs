using HomeTaskApi2.Business.DTOs.GenreDTOs;
using HomeTaskApi2.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeTaskApi2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _genreService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _genreService.GetById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(GenrePostDTO genrePostDTO)
    {
        try
        {
            await _genreService.Create(genrePostDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GenrePutDTO genrePutDTO)
    {
        try
        {
            await _genreService.Update(id, genrePutDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _genreService.Delete(id);
        }
        catch (Exception ex) 
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}
