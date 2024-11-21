namespace Lab6.Models;

public class RegularOrderProduct
{
    public int RegularOrderId { get; set; }
    public RegularOrder? RegularOrder { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}