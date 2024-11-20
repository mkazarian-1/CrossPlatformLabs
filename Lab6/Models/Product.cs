namespace Lab6.Models;

public class Product
{
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductDescription { get; set; }

    public Supplier Supplier { get; set; }
    public ICollection<RegularOrderProduct> RegularOrderProducts { get; set; }
    public ICollection<ActualOrderProduct> ActualOrderProducts { get; set; }
}