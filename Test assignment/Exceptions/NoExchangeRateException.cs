namespace Test_assignment.Exceptions;

public class NoExchangeRateException : Exception
{
    public NoExchangeRateException() {  }

    public NoExchangeRateException(string message)
        : base(message)
    {

    }
}