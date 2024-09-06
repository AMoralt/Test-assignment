namespace Test_assignment;

public interface IExchangeRateProvider
{
    decimal GetExchangeRate(string fromCurrency, string toCurrency);
}