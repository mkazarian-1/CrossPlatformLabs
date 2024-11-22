namespace Lab6.Models;

public class Supplier
{
    public int SupplierId { get; set; }
    public string? SupplierDetails { get; set; }

    public ICollection<Product>? Products { get; set; } = new List<Product>();
}