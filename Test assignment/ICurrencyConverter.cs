namespace Test_assignment;

public interface ICurrencyConverter
{
    Money Convert(Money sourceMoney, string targetCurrencyCode);
}