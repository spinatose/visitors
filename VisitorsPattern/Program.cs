// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Planet Earth!");

Being farmer = new Human("Farmer Brown");
Being cow = new Animal("Bessie");
Being alien = new ExtraTerrestrial("ET");
Being manInBlack = new ManInBlack("Agent Al Ian");  

farmer.Accept((IVisitor)manInBlack);
cow.Accept((IVisitor)manInBlack);
farmer.Accept((IVisitor)alien);
cow.Accept((IVisitor)alien);

Console.ReadLine();

