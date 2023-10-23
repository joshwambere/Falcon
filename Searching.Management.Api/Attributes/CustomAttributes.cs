namespace Searching.Management.Api.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class ScoppedServiceAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class SingletonServiceAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class AppMiddleWareAttribute : Attribute
{
}