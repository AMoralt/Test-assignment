using Microsoft.Extensions.DependencyInjection;
using Test_assignment;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);

// Создание провайдера сервисов
var serviceProvider = serviceCollection.BuildServiceProvider();

// Использование сервисов
var moneyOperations = serviceProvider.GetService<IMoneyOperations>();

Money usdMoney = new Money(100, "USD");
Money eurMoney = new Money(85, "EUR");

if (moneyOperations != null)
{
    var result = moneyOperations.Add(usdMoney, eurMoney);
    Console.WriteLine($"{result.Amount} {result.CurrencyCode}");
}


void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IExchangeRateFactory, ExchangeRateFactory>();
        
    services.AddTransient<IExchangeRateProvider, ExchangeRateProvider>();
    
    services.AddTransient<ICurrencyConverter, CurrencyConverter>();
    
    services.AddTransient<IMoneyOperations, MoneyOperations>();
}