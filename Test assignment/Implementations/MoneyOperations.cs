namespace Test_assignment;

public class MoneyOperations : IMoneyOperations
{
    private readonly ICurrencyConverter _currencyConverter;

    public MoneyOperations(ICurrencyConverter currencyConverter)
    {
        _currencyConverter = currencyConverter;
    }

    public Money Add(Money money1, Money money2)
    {
        if (money1.CurrencyCode != money2.CurrencyCode)
        {
            money2 = _currencyConverter.Convert(money2, money1.CurrencyCode);
        }
        return new Money(money1.Amount + money2.Amount, money1.CurrencyCode);
    }

    public Money Subtract(Money money1, Money money2)
    {
        if (money1.CurrencyCode != money2.CurrencyCode)
        {
            money2 = _currencyConverter.Convert(money2, money1.CurrencyCode);
        }
        return new Money(money1.Amount - money2.Amount, money1.CurrencyCode);
    }
}