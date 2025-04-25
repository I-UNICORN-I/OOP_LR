using System;
using System.Collections.Generic;

// 1. Патерн Макрокоманди (Macro Command)
public interface ICommand
{
    void Execute();  // Виконання команди
}

public class ConcreteCommandA : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Виконання команди A");
    }
}

public class ConcreteCommandB : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Виконання команди B");
    }
}

// 2. Макрокоманда
public class MacroCommand : ICommand
{
    private List<ICommand> _commands;

    public MacroCommand(List<ICommand> commands)
    {
        _commands = commands;
    }

    public void Execute()
    {
        foreach (var command in _commands)
        {
            command.Execute();  // Виконання кожної з команд
        }
    }
}

// 3. Патерн Шаблонний метод (Template Method)
public abstract class BaseTemplate
{
    // Шаблонний метод
    public void Execute()
    {
        StepOne();  // Крок 1
        StepTwo();  // Крок 2
        StepThree();  // Крок 3
    }

    protected abstract void StepOne();  // Абстрактний метод для кроку 1
    protected abstract void StepTwo();  // Абстрактний метод для кроку 2
    protected abstract void StepThree();  // Абстрактний метод для кроку 3
}

public class ConcreteTemplateA : BaseTemplate
{
    protected override void StepOne()
    {
        Console.WriteLine("ConcreteTemplateA: виконання кроку 1");
    }

    protected override void StepTwo()
    {
        Console.WriteLine("ConcreteTemplateA: виконання кроку 2");
    }

    protected override void StepThree()
    {
        Console.WriteLine("ConcreteTemplateA: виконання кроку 3");
    }
}

public class ConcreteTemplateB : BaseTemplate
{
    protected override void StepOne()
    {
        Console.WriteLine("ConcreteTemplateB: виконання кроку 1");
    }

    protected override void StepTwo()
    {
        Console.WriteLine("ConcreteTemplateB: виконання кроку 2");
    }

    protected override void StepThree()
    {
        Console.WriteLine("ConcreteTemplateB: виконання кроку 3");
    }
}

// 4. Головна програма
class Program
{
    static void Main(string[] args)
    {
        // Створення команд
        ICommand commandA = new ConcreteCommandA();
        ICommand commandB = new ConcreteCommandB();

        // Створення макрокоманди
        List<ICommand> commands = new List<ICommand> { commandA, commandB };
        ICommand macroCommand = new MacroCommand(commands);

        // Виконання макрокоманди
        Console.WriteLine("Виконання макрокоманди:");
        macroCommand.Execute();

        // Виконання шаблонних методів
        Console.WriteLine("\nВиконання шаблонних методів:");

        BaseTemplate templateA = new ConcreteTemplateA();
        templateA.Execute();

        BaseTemplate templateB = new ConcreteTemplateB();
        templateB.Execute();

        Console.ReadLine();  // Затримка на екрані
    }
}
