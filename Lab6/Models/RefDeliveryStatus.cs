namespace Lab6.Models;

public class RefDeliveryStatus
{
    public int DeliveryStatusCode { get; set; }
    public string DeliveryStatusDescription { get; set; }

    public ICollection<Delivery> Deliveries { get; set; }
}