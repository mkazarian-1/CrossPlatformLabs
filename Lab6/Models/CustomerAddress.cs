using System.ComponentModel.DataAnnotations;

namespace Lab6.Models;

public class CustomerAddress
{
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int AddressId { get; set; }
    public Address? Address { get; set; }

    public int RefAddressTypeId { get; set; }
    public RefAddressType? RefAddressType { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }
}