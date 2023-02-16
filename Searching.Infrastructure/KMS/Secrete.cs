namespace Searching.Infrastructure.KMS;

public class Secrete<T>
{
    public T Data { get; set; }
    public string Lease_duration { get; set; }
    public string Lease_id { get; set; }
    public bool Renewable { get; set; }
}