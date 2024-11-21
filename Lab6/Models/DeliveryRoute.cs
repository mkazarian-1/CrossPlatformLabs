namespace Lab6.Models;

public class DeliveryRoute
{
    public int DeliveryRouteId { get; set; }
    public string? DeliveryRouteName { get; set; }
    public string? OtherDeliveryRouteDetails { get; set; }

    public ICollection<DeliveryRouteLocation>? DeliveryRouteLocations { get; set; } = new List<DeliveryRouteLocation>();
}