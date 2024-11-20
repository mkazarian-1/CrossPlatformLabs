namespace Lab6.Models;

public class Truck
{
    public int TruckId { get; set; }
    public string TruckLicenceNumber { get; set; }
    public string TruckDetails { get; set; }

    public ICollection<Delivery> Deliveries { get; set; }
}