// See https://aka.ms/new-console-template for more information
Console.WriteLine("Shopping Time!\n");

Invoice invoice = new Invoice
{
    Customer = "John Doe",
    Items = new List<InvoiceItem>
    {
        new Grocery("Apples", 0.50m, 10),
        new Merchandise("Shoes", 50.00m, 1),
        new Grocery("Frozen Pizza", 5.00m, 3),
        new Merchandise("Jeans", 25.00m, 2)
    }
};

LineItemVisitor lineItemVisitor = new LineItemVisitor();
DiscountVisitor discountVisitor = new DiscountVisitor { Discount = 0.10m };
SalesTaxVisitor salesTaxVisitor = new SalesTaxVisitor { SalesTax = 0.0825m };
TotalsVisitor totalsVisitor = new TotalsVisitor();

invoice.Accept(lineItemVisitor);
invoice.Accept(discountVisitor);
invoice.Accept(salesTaxVisitor);
invoice.Accept(totalsVisitor);

Console.ReadLine();

