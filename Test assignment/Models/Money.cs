namespace Test_assignment;

public class Money
{
    public decimal Amount { get; }
    public string CurrencyCode { get; }

    public Money(decimal amount, string currencyCode)
    {
        Amount = amount;
        CurrencyCode = currencyCode;
    }
}