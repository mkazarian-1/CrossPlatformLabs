namespace Lab6.Dto;

public class CustomerDto
{
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? CustomerEmail { get; set; }
    public DateTime DateBecameCustomer { get; set; }
    public string? OtherCustomerDetails { get; set; }
    public string? PaymentMethod { get; set; }
}
