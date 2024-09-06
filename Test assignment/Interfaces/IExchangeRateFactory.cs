namespace Test_assignment.Interfaces;

public interface IExchangeRateFactory
{
    IDictionary<string, decimal> CreateExchangeRates();
}