using HomeTaskApi2.Business.DTOs.GenreDTOs;
using HomeTaskApi2.Business.Services.Interfaces;
using HomeTaskApi2.Core.Entities;
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
}
