namespace Lab6.Models;

public class RegularOrder
{
    public int RegularOrderId { get; set; }
    public string DistributerId { get; set; }
    public string OrderDetails { get; set; }

    public ICollection<ActualOrder> ActualOrders { get; set; }
    public ICollection<RegularOrderProduct> RegularOrderProducts { get; set; }
}