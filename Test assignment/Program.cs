using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Test_assignment;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);

var serviceProvider = serviceCollection.BuildServiceProvider();

var moneyOperations = serviceProvider.GetService<IMoneyOperations>();
var currencyConverter = serviceProvider.GetService<ICurrencyConverter>();

ConsoleInterface();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IExchangeRateFactory, ExchangeRateFactory>();

    services.AddTransient<IExchangeRateProvider, ExchangeRateProvider>();

    services.AddTransient<ICurrencyConverter, CurrencyConverter>();

    services.AddTransient<IMoneyOperations, MoneyOperations>();
}

void ConsoleInterface()
{
    var exit = false;

    while (!exit)
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Выйти из программы");
        Console.WriteLine("2. Провести конвертацию одной валюты в другую валюту");
        Console.WriteLine("3. Сложить валюты");
        Console.WriteLine("4. Вычесть валюты");

        var action = Console.ReadLine();

        switch (action)
        {
            case "1":
                exit = true;
                break;
            case "2":
                ConvertCurrency(currencyConverter);
                break;
            case "3":
                PerformOperation(moneyOperations, true);
                break;
            case "4":
                PerformOperation(moneyOperations, false);
                break;
            default:
                Console.WriteLine("Неверный выбор, пожалуйста, выберите действие от 1 до 4.");
                break;
        }
    }
}

void ConvertCurrency(ICurrencyConverter currencyConverter)
{
    try
    {
        Console.Write("Введите сумму: ");
        var amount = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Введите валюту исходной суммы (например, USD): ");
        var fromCurrency = Console.ReadLine().ToUpper();

        Console.Write("Введите валюту, в которую нужно конвертировать (например, EUR): ");
        var toCurrency = Console.ReadLine().ToUpper();

        var money = new Money(amount, fromCurrency);
        var result = currencyConverter.Convert(money, toCurrency);

        Console.WriteLine($"Конвертированная сумма: {result.Amount} {result.CurrencyCode}");
    }
    catch (NoExchangeRateException ex)
    {
        Console.WriteLine($"Данной валюты нет в списке курсов");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}

void PerformOperation(IMoneyOperations moneyOperations, bool isAddition)
{
    try
    {
        Console.Write("Введите сумму первой валюты: ");
        var amount1 = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Введите валюту первой суммы (например, USD): ");
        var currency1 = Console.ReadLine().ToUpper();

        Console.Write("Введите сумму второй валюты: ");
        var amount2 = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Введите валюту второй суммы (например, EUR): ");
        var currency2 = Console.ReadLine().ToUpper();

        var money1 = new Money(amount1, currency1);
        var money2 = new Money(amount2, currency2);

        Money result;

        if (isAddition)
            result = moneyOperations.Add(money1, money2);
        else
            result = moneyOperations.Subtract(money1, money2);

        Console.WriteLine($"Результат операции: {result.Amount} {result.CurrencyCode}");
    }
    catch (NoExchangeRateException ex)
    {
        Console.WriteLine($"Данной валюты нет в списке курсов");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}