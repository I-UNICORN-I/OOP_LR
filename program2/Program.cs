using System;

// 1. Інтерфейс Прототипу (Prototype)
public interface IPrototype
{
    IPrototype Clone();  // Метод для клонування об'єкта
}

// 2. Конкретний клас, що реалізує прототип
public class ConcretePrototype : IPrototype
{
    public string Name { get; set; }
    public int Value { get; set; }

    public ConcretePrototype(string name, int value)
    {
        Name = name;
        Value = value;
    }

    // Реалізація методу Clone() для створення копії
    public IPrototype Clone()
    {
        return new ConcretePrototype(this.Name, this.Value);
    }
}

// 3. Головна програма
class Program
{
    static void Main(string[] args)
    {
        // Створення першого об'єкта ConcretePrototype
        ConcretePrototype prototype1 = new ConcretePrototype("Prototype 1", 100);

        // Клонування об'єкта
        ConcretePrototype clone1 = (ConcretePrototype)prototype1.Clone();

        // Виведення результатів
        Console.WriteLine("Оригінальний об'єкт:");
        Console.WriteLine($"Name: {prototype1.Name}, Value: {prototype1.Value}");

        Console.WriteLine("\nКлонований об'єкт:");
        Console.WriteLine($"Name: {clone1.Name}, Value: {clone1.Value}");

        // Зміна значень в клоні та виведення
        clone1.Name = "Prototype 2";
        clone1.Value = 200;

        Console.WriteLine("\nПісля зміни значень клону:");
        Console.WriteLine($"Name: {clone1.Name}, Value: {clone1.Value}");

        Console.WriteLine("\nОригінальний об'єкт залишився незмінним:");
        Console.WriteLine($"Name: {prototype1.Name}, Value: {prototype1.Value}");

        Console.ReadLine();  // Затримка на екрані
    }
}
