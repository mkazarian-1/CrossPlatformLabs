namespace Lab6.Models;

public class Delivery
{
    public int DeliveryId { get; set; }
    public int ActualOrderId { get; set; }
    public ActualOrder? ActualOrder { get; set; }
    public int DeliveryStatusId { get; set; }
    public RefDeliveryStatus? DeliveryStatus { get; set; }
    public int DriverEmployeeId { get; set; }
    public Employee? DriverEmployee { get; set; }
    public int TruckId { get; set; }
    public Truck? Truck { get; set; }
    public int DeliveryRouteLocationId { get; set; }
    public DeliveryRouteLocation? DeliveryRouteLocation { get; set; }

    public DateTime DeliveryDate { get; set; }
    public string? OtherDeliveryDetails { get; set; }
}