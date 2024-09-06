namespace Test_assignment;

public class NoExchangeRateException : Exception
{
    public NoExchangeRateException() {  }

    public NoExchangeRateException(string message)
        : base(message)
    {

    }
}