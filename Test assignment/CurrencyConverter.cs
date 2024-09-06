namespace Test_assignment;

public class CurrencyConverter : ICurrencyConverter
{
    private readonly IExchangeRateProvider _exchangeRateProvider;

    public CurrencyConverter(IExchangeRateProvider exchangeRateProvider)
    {
        _exchangeRateProvider = exchangeRateProvider;
    }

    public Money Convert(Money sourceMoney, string targetCurrencyCode)
    {
        if (sourceMoney.CurrencyCode == targetCurrencyCode)
        {
            return new Money(sourceMoney.Amount, sourceMoney.CurrencyCode);
        }

        decimal exchangeRate = _exchangeRateProvider.GetExchangeRate(sourceMoney.CurrencyCode, targetCurrencyCode);
        decimal convertedAmount = sourceMoney.Amount * exchangeRate;
        return new Money(convertedAmount, targetCurrencyCode);
    }
}