namespace Lab5.Dto;

public class ProductFullDto
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string? ProductDescription { get; set; }
    public SupplierDto? Supplier { get; set; }
    
    public List<RegularOrderProductDto>? RegularOrderProducts { get; set; } = new List<RegularOrderProductDto>();
    public List<ActualOrderProductDto>? ActualOrderProducts { get; set; } = new List<ActualOrderProductDto>();
}

public class RegularOrderProductDto
{
    public int RegularOrderId { get; set; }
    public int ProductId { get; set; }
}

public class ActualOrderProductDto
{
    public int ActualOrderId { get; set; }
    public int ProductId { get; set; }
}

public class SupplierDto
{
    public int SupplierId { get; set; }
    public string? SupplierDetails { get; set; }
}