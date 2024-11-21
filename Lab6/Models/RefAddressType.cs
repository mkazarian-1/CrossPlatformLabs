using System.ComponentModel.DataAnnotations;

namespace Lab6.Models;

public class RefAddressType
{
    [Key]
    public int RefAddressTypeId { get; set; }
    public string? RefAddressTypeDescription { get; set; }

    public ICollection<CustomerAddress>? CustomerAddresses { get; set; } = new List<CustomerAddress>();
}