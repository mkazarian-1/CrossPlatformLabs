namespace Lab6.Models;

public class RegularOrder
{
    public int RegularOrderId { get; set; }

    public int DistributorId { get; set; }
    public Customer? Distributor { get; set; }

    public string? OrderDetails { get; set; }

    public ICollection<RegularOrderProduct> RegularOrderProducts { get; set; } = new List<RegularOrderProduct>();

}