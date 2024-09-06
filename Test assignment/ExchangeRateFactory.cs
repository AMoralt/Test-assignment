using System.Collections.Concurrent;

namespace Test_assignment;

public class ExchangeRateFactory : IExchangeRateFactory
{
    public IDictionary<string, decimal> CreateExchangeRates()
    {
        //Тут условно было бы получение его откуда-то и передача
        return new Dictionary<string, decimal>
        {
            { "USD->EUR", 0.85m },
            { "EUR->USD", 1.18m },
            { "USD->JPY", 110m },
            { "JPY->USD", 0.0091m }
        };
    }
}