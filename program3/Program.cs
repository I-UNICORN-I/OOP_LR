using System;
using System.Collections.Generic;

// 1. Патерн Стратегія (Strategy)
public interface IStrategy
{
    void Execute(string data);  // Метод виконання стратегії
}

public class ConcreteStrategyA : IStrategy
{
    public void Execute(string data)
    {
        Console.WriteLine("Виконання стратегії A з даними: " + data);
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Execute(string data)
    {
        Console.WriteLine("Виконання стратегії B з даними: " + data);
    }
}

// 2. Клас контексту, що використовує стратегію
public class Context
{
    private IStrategy _strategy;
    private List<IObserver> _observers = new List<IObserver>();

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
        NotifyObservers();  // Сповіщаємо спостерігачів про зміну стратегії
    }

    public void ExecuteStrategy(string data)
    {
        _strategy.Execute(data);
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_strategy.GetType().Name);  // Сповіщаємо кожного спостерігача
        }
    }
}

// 3. Патерн Спостерігач (Observer)
public interface IObserver
{
    void Update(string strategyName);  // Оновлення при зміні стратегії
}

public class ConcreteObserver : IObserver
{
    private string _observerName;

    public ConcreteObserver(string name)
    {
        _observerName = name;
    }

    public void Update(string strategyName)
    {
        Console.WriteLine($"{_observerName} отримав оновлення: стратегія змінилась на {strategyName}");
    }
}

// 4. Головна програма
class Program
{
    static void Main(string[] args)
    {
        // Створюємо контекст з початковою стратегією
        Context context = new Context(new ConcreteStrategyA());

        // Створюємо спостерігачів
        IObserver observer1 = new ConcreteObserver("Спостерігач 1");
        IObserver observer2 = new ConcreteObserver("Спостерігач 2");

        // Додаємо спостерігачів
        context.Attach(observer1);
        context.Attach(observer2);

        // Виконання стратегії A
        context.ExecuteStrategy("Дані для стратегії A");

        // Зміна стратегії на B
        context.SetStrategy(new ConcreteStrategyB());

        // Виконання стратегії B
        context.ExecuteStrategy("Дані для стратегії B");

        Console.ReadLine();  // Затримка на екрані
    }
}
