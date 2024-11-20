namespace Lab6.Models;

public class RefAddressType
{
    public int AddressTypeCode { get; set; }
    public string AddressTypeDescription { get; set; }

    public ICollection<CustomerAddress> CustomerAddresses { get; set; }
}