using Test_assignment.Models;

namespace Test_assignment.Interfaces;

public interface IMoneyOperations
{
    Money Add(Money money1, Money money2);
    Money Subtract(Money money1, Money money2);
}