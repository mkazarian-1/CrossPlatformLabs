namespace Lab6.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime DateBecameCustomer { get; set; }
    public string OtherCustomerDetails { get; set; }

    public ICollection<CustomerAddress> CustomerAddresses { get; set; }
}