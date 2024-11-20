namespace Lab6.Models;

public class DeliveryRoute
{
    public int RouteId { get; set; }
    public string RouteName { get; set; }
    public string OtherRouteDetails { get; set; }

    public ICollection<DeliveryRouteLocation> DeliveryRouteLocations { get; set; }
}