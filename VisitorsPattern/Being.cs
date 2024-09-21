
using System;
using System.Diagnostics.Contracts;

public class ManInBlack: Being, IVisitor
{
    public ManInBlack(string name) : base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);

    public void Visit(Human human)
    {
        Console.WriteLine("ManInBlack visits human");
    }

    public void Visit(Animal animal)
    {
        Console.WriteLine("ManInBlack visits animal");
    }
    
    public void Visit(Being being)
    {
        Console.WriteLine("ManInBlack visits unknown entity");
    }
}

public class ExtraTerrestrial: Being, IVisitor
{
    public ExtraTerrestrial(string name) : base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);

    public void Visit(Human human)
    {
        Console.WriteLine("ExtraTerrestrial visits human");
    }

    public void Visit(Animal animal)
    {
        Console.WriteLine("ExtraTerrestrial visits animal");
    }

    public void Visit(Being being)
    {
        Console.WriteLine("ExtraTerrestrial visits unknown entity");
    }
}

public abstract class Being
{
    public string Name { get; set; } = "Being";

    public Being(string name) => Name = name;

    public abstract void Accept(IVisitor visitor);
}

public interface IVisitor
{
    void Visit(Being being);
    void Visit(Human human);
    void Visit(Animal animal);
}

public class Animal: Being
{
    public Animal(string name): base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class Human: Being
{
    public Human(string name) : base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}