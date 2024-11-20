namespace Lab6.Models;

public class DeliveryRouteLocation
{
    public int LocationCode { get; set; }
    public int RouteId { get; set; }
    public int LocationAddressId { get; set; }
    public string LocationName { get; set; }
    public string OtherLocationDetails { get; set; }

    public DeliveryRoute Route { get; set; }
    public Address Address { get; set; }
}