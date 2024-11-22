using System.ComponentModel.DataAnnotations;

namespace Lab6.Models;

public class RefDeliveryStatus
{
    [Key]
    public int RefDeliveryStatusId { get; set; }
    public string? RefDeliveryStatusDescription { get; set; }

    public ICollection<Delivery>? Deliveries { get; set; } = new List<Delivery>();
}