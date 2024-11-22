using System.Text.Json.Serialization;

namespace Lab5.Dto;

public class CustomerDto
{
    [JsonPropertyName("customerId")] public int CustomerId { get; set; }
    [JsonPropertyName("customerName")] public string? CustomerName { get; set; }
    [JsonPropertyName("customerPhone")] public string? CustomerPhone { get; set; }
    [JsonPropertyName("customerEmail")] public string? CustomerEmail { get; set; }

    [JsonPropertyName("dateBecameCustomer")]
    public DateTime DateBecameCustomer { get; set; }

    [JsonPropertyName("otherCustomerDetails")]
    public string? OtherCustomerDetails { get; set; }
}