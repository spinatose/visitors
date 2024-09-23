
using System;
using System.Diagnostics.Contracts;

public class ManInBlack: Being, IVisitor
{
    public ManInBlack(string name = "Agent MIB") : base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);

    public void Visit(Human human)
    {
        human.VisitResult = $"{human.Name}'s mind has been wiped by {Name}";
    }

    public void Visit(Animal animal)
    {
        animal.VisitResult = $"{animal.Name} has provided radioactive hamburgers to {Name}";
    }
    
    public void Visit(Being being)
    {
        being.VisitResult = $"{Name} visits unknown entity";
    }
}

public class ExtraTerrestrial: Being, IVisitor
{
    public ExtraTerrestrial(string name = "ExtraTerrestrial") : base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);

    public void Visit(Human human)
    {
        human.VisitResult = $"{Name} injects {human.Name} with bio-electric tracking implant";
    }

    public void Visit(Animal animal)
    {
        animal.VisitResult = $"{Name} performs tissue sampling mutilation on {animal.Name}";
    }

    public void Visit(Being being)
    {
        being.VisitResult = $"{Name} abducts {being.Name}";
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
    public Animal(string name = "Creature"): base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class Human: Being
{
    public Human(string name = "Person of Interest") : base(name) { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}