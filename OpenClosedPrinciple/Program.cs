#region OCP_Before

//class Product
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public decimal Price { get; set; }
//    public decimal Weight { get; set; }
//}


//class Order
//{
//    private List<Product> items;
//    private string shippingType;

//    public decimal GetTotal() => items.Sum(p => p.Price);
//    public decimal GetTotalWeight() => items.Sum(p => p.Weight);
//    public void SetShippingType(string type) => shippingType = type;

//    public decimal GetShippingCost()
//    {
//        if (shippingType == "ground")
//        {
//            // Free ground delivery on big orders
//            if (GetTotal() > 100)
//                return 0;

//            // $1.5 per kilogram, but $10 minimum
//            return Math.Max(10, GetTotalWeight() * 1.5M);
//        }
//        else
//        // shippingType == "air"
//        {
//            // $3 per kilogram, but $20 minimum
//            return Math.Max(20, GetTotalWeight() * 3);
//        }
//    }
//    public DateTime GetShippingDate()
//        => shippingType switch
//        {
//            "ground" => DateTime.Now.AddDays(7),
//            "air" => DateTime.Now.AddDays(2),
//            _ => throw new NullReferenceException()
//        };
//}


#endregion







#region OCP_After

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
}


interface IShipping
{
    decimal GetCost(Order order);
    DateTime GetDate(Order order);
}


class Ground : IShipping
{
    public decimal GetCost(Order order)
    {
        // Free ground delivery on big orders
        if (order.GetTotal() > 100)
            return 0;

        // $1.5 per kilogram, but $10 minimum
        return Math.Max(10, order.GetTotalWeight() * 1.5M);
    }

    public DateTime GetDate(Order order)
    {
        return DateTime.Now.AddDays(7);
    }
}

class Air : IShipping
{
    public decimal GetCost(Order order)
    {
        // $3 per kilogram, but $20 minimum
        return Math.Max(20, order.GetTotalWeight() * 3);
    }

    public DateTime GetDate(Order order)
    {
        return DateTime.Now.AddDays(2);
    }
}



class Order
{
    private List<Product> items = new();
    private IShipping shippingType;

    public decimal GetTotal() => items.Sum(p => p?.Price ?? 0);
    public decimal GetTotalWeight() => items.Sum(p => p?.Weight ?? 0);
    public void SetShippingType(IShipping type) => shippingType = type;
    public decimal GetShippingCost() => shippingType.GetCost(this);
    public DateTime GetShippingDate() => shippingType.GetDate(this);
}





class Program
{
    static void Main()
    {
        Order order = new();
        order.SetShippingType(new Ground());

        // var shippingCost = order.GetShippingCost();
        var shippingDate = order.GetShippingDate();

        Console.WriteLine(shippingDate);
    }
}


#endregion