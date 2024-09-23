
using System;
using System.Diagnostics.Contracts;

public class ManInBlack: Being, IVisitor
{
    public ManInBlack(string name) : base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);

    public void Visit(Human human)
    {
        human.VisitResult = "ManInBlack visits human";
    }

    public void Visit(Animal animal)
    {
        animal.VisitResult = "ManInBlack visits animal";
    }
    
    public void Visit(Being being)
    {
        being.VisitResult = "ManInBlack visits unknown entity";
    }
}

public class ExtraTerrestrial: Being, IVisitor
{
    public ExtraTerrestrial(string name) : base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);

    public void Visit(Human human)
    {
        human.VisitResult = "ExtraTerrestrial visits human";
    }

    public void Visit(Animal animal)
    {
        animal.VisitResult = "ExtraTerrestrial visits animal";
    }

    public void Visit(Being being)
    {
        being.VisitResult = "ExtraTerrestrial visits unknown entity";
    }
}

public abstract class Being
{
    public string Name { get; set; } = "Being";

    public string VisitResult { get; set; } = string.Empty;

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