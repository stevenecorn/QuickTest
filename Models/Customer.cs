// Customer.cs
public class Customer
{
    public string id { get; set; } = string.Empty;          // customer id
    public string joined { get; set; } = string.Empty;      // date the customer joined
    public string firstName { get; set; } = string.Empty;   // first name of customer
    public string lastName { get; set; } = string.Empty;    // last name of customer
    public string middleName { get; set; } = string.Empty;  // middle name of customer
    public string dob { get; set; } = string.Empty;         // date the customer was born
    public string email { get; set; } = string.Empty;       // email of customer
    public string notes { get; set; } = string.Empty;       // notes about the customer
    public string status { get; set; } = string.Empty;      // status of the customer
    // (inactive or active)
}