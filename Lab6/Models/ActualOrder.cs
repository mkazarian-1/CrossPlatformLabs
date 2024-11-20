namespace Lab6.Models;

public class ActualOrder
{
    public int ActualOrderId { get; set; }
    public int RegularOrderId { get; set; }
    public int OrderStatusCode { get; set; }
    public DateTime ActualOrderDate { get; set; }
    public string OrderDetails { get; set; }

    public RegularOrder RegularOrder { get; set; }
    public RefOrderStatus OrderStatus { get; set; }
    public ICollection<ActualOrderProduct> ActualOrderProducts { get; set; }
    public Delivery Delivery { get; set; }
}