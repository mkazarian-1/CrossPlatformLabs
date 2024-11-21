using System.ComponentModel.DataAnnotations;

namespace Lab6.Models;

public class ActualOrder
{
    public int ActualOrderId { get; set; }

    public int RefOrderStatusId { get; set; }
    public RefOrderStatus? RefOrderStatus { get; set; }

    public DateTime ActualOrderDate { get; set; }
    public string? OrderDetails { get; set; }

    public ICollection<ActualOrderProduct>? ActualOrderProducts { get; set; } = new List<ActualOrderProduct>();
    public ICollection<Delivery>? Deliveries { get; set; } = new List<Delivery>();
}