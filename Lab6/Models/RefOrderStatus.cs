using System.ComponentModel.DataAnnotations;

namespace Lab6.Models;

public class RefOrderStatus
{
    [Key]
    public int RefOrderStatusId { get; set; }
    public string? RefOrderStatusDescription { get; set; }

    public ICollection<ActualOrder>? ActualOrders { get; set; } = new List<ActualOrder>();
}