// Product.cs
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Color { get; set; }
    public List<Detail> Details  { get; set; } 
}

public class Detail
{
    public string Name { get; set; }
    public int Order { get; set; }
    public string Value { get; set; }
}