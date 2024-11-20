namespace Lab6.Models;

public class RefOrderStatus
{
    public int OrderStatusCode { get; set; }
    public string OrderStatusDescription { get; set; }

    public ICollection<ActualOrder> ActualOrders { get; set; }
}