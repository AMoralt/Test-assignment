namespace Test_assignment;

public class ExchangeRateProvider : IExchangeRateProvider
{
    private readonly IDictionary<string, decimal> _exchangeRateDictionary;

    public ExchangeRateProvider(IExchangeRateFactory exchangeRateFactory)
    {
        _exchangeRateDictionary = exchangeRateFactory.CreateExchangeRates();
    }

    public decimal GetExchangeRate(string fromCurrency, string toCurrency)
    {
        string directConversionKey = $"{fromCurrency}->{toCurrency}";

        if (_exchangeRateDictionary.TryGetValue(directConversionKey, out var rate))
        {
            return rate;
        }

        // Попытка кросс-курса через USD
        string conversionViaUsdKey1 = $"{fromCurrency}->USD";
        string conversionViaUsdKey2 = $"USD->{toCurrency}";

        if (_exchangeRateDictionary.TryGetValue(conversionViaUsdKey1, out var rateToUsd)
            && _exchangeRateDictionary.TryGetValue(conversionViaUsdKey2, out var rateFromUsdToTarget))
        {
            return rateToUsd * rateFromUsdToTarget;
        }

        throw new Exception("Курс валюты не найден.");
    }
}
