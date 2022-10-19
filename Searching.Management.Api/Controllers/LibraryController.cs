using Microsoft.AspNetCore.Mvc;
using Searching.Management.Api.DTOs;
using Searching.Management.Api.Services;

namespace Searching.Management.Api.Controllers;

[ApiController]
[Route("api/library")]
public class LibraryController: ControllerBase
{
    private readonly LibraryService _libraryService;
    
    public  LibraryController(LibraryService libraryService)
    {
        _libraryService = libraryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _libraryService.GetAll();
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Post(LibraryRequest library)
    {
        var result = await _libraryService.Create(library);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _libraryService.GetById(id);
        return Ok(result);
    }
}