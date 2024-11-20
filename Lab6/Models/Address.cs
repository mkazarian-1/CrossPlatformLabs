namespace Lab6.Models;

public class Address
{
    public int AddressId { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string Line3 { get; set; }
    public string Line4 { get; set; }
    public string ZipPostcode { get; set; }
    public string City { get; set; }
    public string StateProvinceCounty { get; set; }
    public string Country { get; set; }
    public string OtherAddressDetails { get; set; }

    public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    public ICollection<DeliveryRouteLocation> DeliveryRouteLocations { get; set; }
}