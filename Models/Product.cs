// Product.cs
public class Product
{
    public int id { get; set; }                         // product id
    public string name { get; set; } = string.Empty;    // product name 
    public List<string> color { get; set; }             // list of product colors
    public List<Detail> details  { get; set; }          // list of product details
}

public class Detail
{
    // this detail is setup like a dictionary
    // has keys (name)
    // has values (value)
    // has a selection mechanism (order)
    public string name { get; set; } = string.Empty;    // name of detail
    public int order { get; set; }                      // place in the order of details
    public string value { get; set; } = string.Empty;   // value of the detail
}