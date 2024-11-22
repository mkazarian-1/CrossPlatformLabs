namespace Lab5.Dto;

public class CustomerFullDto
{
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? CustomerEmail { get; set; }
    public DateTime DateBecameCustomer { get; set; }
    public string? OtherCustomerDetails { get; set; }
    
    public int RefPaymentMethodId { get; set; }
    public RefPaymentMethodDto? RefPaymentMethod { get; set; }
    
    public List<CustomerAddressDto>? CustomerAddresses { get; set; } = new List<CustomerAddressDto>();
    public List<RegularOrderDto>? RegularOrders { get; set; } = new List<RegularOrderDto>();
}

