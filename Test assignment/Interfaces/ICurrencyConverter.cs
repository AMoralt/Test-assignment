using Test_assignment.Models;

namespace Test_assignment.Interfaces;

public interface ICurrencyConverter
{
    Money Convert(Money sourceMoney, string targetCurrencyCode);
}