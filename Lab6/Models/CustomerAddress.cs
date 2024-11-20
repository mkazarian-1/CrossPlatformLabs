namespace Lab6.Models;

public class CustomerAddress
{
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public int AddressTypeCode { get; set; }

    public Customer Customer { get; set; }
    public Address Address { get; set; }
    public RefAddressType AddressType { get; set; }
}