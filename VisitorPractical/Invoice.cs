public abstract class InvoiceItem {
    public string Name { get; set; } = "Item";
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public abstract void Accept(InvoiceVisitor visitor);

}

public class Grocery : InvoiceItem
{
    public Grocery(string itemName, decimal itemPrice, int itemQuantity)
    {
        Name = itemName;
        Price = itemPrice;
        Quantity = itemQuantity;
    }
    
    public override void Accept(InvoiceVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Merchandise : InvoiceItem
{
    public Merchandise(string itemName, decimal itemPrice, int itemQuantity)
    {
        Name = itemName;
        Price = itemPrice;
        Quantity = itemQuantity;
    }
    
    public override void Accept(InvoiceVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Invoice: InvoiceItem
{
    public string Customer { get; set; } = "Customer";
    public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

    public override void Accept(InvoiceVisitor visitor)
    {
        if (visitor.GetType() != typeof(TotalsVisitor))
        {
            visitor.Visit(this);
        }

        foreach (var item in Items)
        {
            item.Accept(visitor);
        }

        if (visitor.GetType() == typeof(TotalsVisitor))
        {
            visitor.Visit(this);
        }
    }
}

public interface InvoiceVisitor
{
    void Visit(Invoice invoice);
    void Visit(Grocery item);
    void Visit(Merchandise item);
}

public class DiscountVisitor : InvoiceVisitor
{
    public decimal Discount { get; set; }

    public void Visit(Invoice invoice)
    {
        Console.WriteLine($"\tCalculating {Math.Floor(Discount*100)}% discount for {invoice.Customer}");
    }

    public void Visit(Grocery invoiceItem)
    {
        ApplyDiscount(invoiceItem);
    }

    public void Visit(Merchandise invoiceItem)
    {
        ApplyDiscount(invoiceItem);
    }

    private void ApplyDiscount(InvoiceItem item)
    {
        item.Price *= (1 - Discount);
        Console.WriteLine($"\t\t{item.Name} price is now {item.Price:C}");
    }
}

public class SalesTaxVisitor : InvoiceVisitor
{
    public decimal SalesTax { get; set; }

    public void Visit(Invoice invoice)
    {
        Console.WriteLine($"\tCalculating {SalesTax * 100}% sales tax for {invoice.Customer}");
    }

    public void Visit(Grocery invoiceItem)
    {
        Console.WriteLine($"\t\t{invoiceItem.Name} is a grocery item and is not eligible for sales tax");
    }

    public void Visit(Merchandise item)
    {
        item.Price *= (1 + SalesTax);
        Console.WriteLine($"\t\t{item.Name} price is now {item.Price:C}");
    }
}

public class TotalsVisitor: InvoiceVisitor
{
    public decimal Total { get; set; }

    public void Visit(Invoice invoice)
    {
        Console.WriteLine($"\nTotaling items for {invoice.Customer}");
        foreach (var item in invoice.Items)
        {
            Total += item.Price * item.Quantity;
        }

        Console.WriteLine($"\tTotal is {Total:C}");
    }

    public void Visit(Grocery invoiceItem)
    {
        // do nothing
    }

    public void Visit(Merchandise invoiceItem)
    {
        // do nothing
    }
}

public class LineItemVisitor: InvoiceVisitor
{
    public void Visit(Invoice invoice)
    {
        Console.WriteLine($"Item List for {invoice.Customer}\n");

        foreach (var item in invoice.Items)
        {
            Console.WriteLine($"\t{item.Name} @ {item.Price:C} x {item.Quantity}");
        }

        Console.WriteLine();
    }

    public void Visit(Grocery invoiceItem)
    {
        // do nothing
    }

    public void Visit(Merchandise invoiceItem)
    {
        // do nothing
    }
}