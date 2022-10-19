namespace Searching.Management.Api.interfaces;

public interface ILibrary
{
    public string _id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public string[] tags { get; set; }
}