namespace Searching.Infrastructure.Exceptions;


public abstract class DomainException: System.Exception
{
    public DomainException(string message) : base(message)
    {
    }
}

public class DomainNotFoundException : DomainException
{
    public DomainNotFoundException(string message) : base(message)
    {
    }
}

public class DomainBadRequestException : DomainException
{
    public DomainBadRequestException(string message) : base(message)
    {
    }
}

public class DomainUnauthorizedException : DomainException
{
    public DomainUnauthorizedException(string message) : base(message)
    {
    }
}

public class DomainForbiddenException : DomainException
{
    public DomainForbiddenException(string message) : base(message)
    {
    }
}

public class DomainConflictException : DomainException
{
    public DomainConflictException(string message) : base(message)
    {
    }
}
public class DomainInternalServerErrorException : DomainException
{
    public DomainInternalServerErrorException(string message) : base(message)
    {
    }
}

public class DomainRequestTimeoutException : DomainException
{
    public DomainRequestTimeoutException(string message) : base(message)
    {
    }
}
public class DomainExternalServiceException : DomainException
{
    public DomainExternalServiceException(string message) : base(message)
    {
    }
}