namespace Test_assignment.Interfaces;

public interface IExchangeRateProvider
{
    decimal GetExchangeRate(string fromCurrency, string toCurrency);
}