namespace Homework1.Application.Exceptions;

public class ClientNotFoundException : Exception
{
    public ClientNotFoundException(string message) : base(message)
    {
    }

}