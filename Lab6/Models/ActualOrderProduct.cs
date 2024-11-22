namespace Lab6.Models;

public class ActualOrderProduct
{
    public int ActualOrderId { get; set; }
    public ActualOrder? ActualOrder { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}