using Searching.Management.Api.interfaces;

namespace Searching.Management.Api.DTOs;

public class LibraryResponse
{
    public ILibrary data;
}

public class LibraryRequest : ILibrary
{
    public string _id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public string[] tags { get; set; }
}