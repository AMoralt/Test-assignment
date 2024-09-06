namespace Test_assignment;

public interface IExchangeRateFactory
{
    IDictionary<string, decimal> CreateExchangeRates();
}