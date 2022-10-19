using Searching.Management.Api.Attributes;
using Searching.Management.Api.DTOs;

namespace Searching.Management.Api.Services;

[ScoppedService]
public class LibraryService
{
    public Task<LibraryResponse> GetAll()
    {
        return Task.FromResult(new LibraryResponse{});

    }
    
    public Task<LibraryResponse> GetById(int id)
    {
        return Task.FromResult(new LibraryResponse{});

    }
    
    public Task<LibraryResponse> Create(LibraryRequest request)
    {
        return Task.FromResult(new LibraryResponse{});

    }

}