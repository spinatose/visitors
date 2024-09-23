// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Planet Earth! Farmer Brown has visitors....");

Being farmer = new Human("Farmer Brown");
Being cow = new Animal("Bessie");
Being alien = new ExtraTerrestrial("EBE-1");
Being manInBlack = new ManInBlack("Agent Al Ian");

Console.WriteLine("Aliens make visit");
cow.Accept((IVisitor)alien);
Console.WriteLine($"\t{cow.Name} status: {cow.VisitResult}");
farmer.Accept((IVisitor)alien);
Console.WriteLine($"\t{farmer.Name} status: {farmer.VisitResult}");
Console.WriteLine();

Console.WriteLine("Man in black makes visit");
farmer.Accept((IVisitor)manInBlack);
Console.WriteLine($"\t{farmer.Name} status: {farmer.VisitResult}");
cow.Accept((IVisitor)manInBlack);
Console.WriteLine($"\t{cow.Name} status: {cow.VisitResult}");
Console.WriteLine();

Console.WriteLine("Aliens visit Man in black");
manInBlack.Accept((IVisitor)alien);
Console.WriteLine($"\t{manInBlack.Name} status: {manInBlack.VisitResult}");
Console.WriteLine();

Console.ReadLine();

