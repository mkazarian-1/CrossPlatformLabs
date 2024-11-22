using System.ComponentModel.DataAnnotations;

namespace Lab6.Models;

public class Customer
{
    public int CustomerId { get; set; }
    [Required]
    public string? CustomerName { get; set; }
    [Phone]
    public string? CustomerPhone { get; set; }
    [EmailAddress]
    public string? CustomerEmail { get; set; }
    public DateTime DateBecameCustomer { get; set; }
    public string? OtherCustomerDetails { get; set; }

    public int RefPaymentMethodId {  get; set; }
    public RefPaymentMethod? RefPaymentMethod { get; set; }

    public ICollection<CustomerAddress>? CustomerAddresses { get; set; } = new List<CustomerAddress>();
    public ICollection<RegularOrder>? RegularOrders { get; set; } = new List<RegularOrder>();
}