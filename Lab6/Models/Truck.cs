using System.ComponentModel.DataAnnotations;

namespace Lab6.Models;

public class Truck
{
    public int TruckId { get; set; }

    [Required]
    public string? TruckLicenceNumber { get; set; }

    public string? TruckDetails { get; set; }

    public ICollection<Delivery>? Deliveries { get; set; } = new List<Delivery>();
}