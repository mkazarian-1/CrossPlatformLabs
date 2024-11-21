namespace Lab6.Models;

public class DeliveryRouteLocation
{
    public int DeliveryRouteLocationId { get; set; }
    public int DeliveryRouteId { get; set; }
    public DeliveryRoute? DeliveryRoute { get; set; }
    public int AddressId { get; set; }
    public Address? Address { get; set; }
    public string? LocationName { get; set; }
    public string? OtherLocationDetails { get; set; }

}