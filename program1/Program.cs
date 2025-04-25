using System;

// 1. Стратегія (Strategy) - інтерфейс для різних алгоритмів
public interface IStrategy
{
    void Execute();  // Абстрактний метод, який реалізують конкретні стратегії
}

// 2. Конкретні стратегії
public class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Виконання стратегії A");
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Виконання стратегії B");
    }
}

public class ConcreteStrategyC : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Виконання стратегії C");
    }
}

// 3. Контекст - клас, що використовує стратегію
public class Context
{
    private IStrategy _strategy;  // Поточна стратегія

    public Context(IStrategy strategy)
    {
        _strategy = strategy;  // Ініціалізація стратегії
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;  // Заміна стратегії
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();  // Виконання поточної стратегії
    }
}

// 4. Головна програма
class Program
{
    static void Main(string[] args)
    {
        // Створення контексту з початковою стратегією
        Context context = new Context(new ConcreteStrategyA());

        // Виконання стратегії A
        context.ExecuteStrategy();

        // Заміна стратегії на B
        context.SetStrategy(new ConcreteStrategyB());

        // Виконання стратегії B
        context.ExecuteStrategy();

        // Заміна стратегії на C
        context.SetStrategy(new ConcreteStrategyC());

        // Виконання стратегії C
        context.ExecuteStrategy();

        Console.ReadLine();  // Затримка на екрані
    }
}
