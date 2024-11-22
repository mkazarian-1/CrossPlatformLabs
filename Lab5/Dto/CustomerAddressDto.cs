namespace Lab5.Dto;

public class CustomerAddressDto
{
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
    public AddressDto? Address { get; set; }
    public int RefAddressTypeId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}