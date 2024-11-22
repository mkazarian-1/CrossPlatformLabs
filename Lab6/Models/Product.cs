using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    public string? ProductName { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal ProductPrice { get; set; }

    public string? ProductDescription { get; set; }

    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public ICollection<RegularOrderProduct>? RegularOrderProducts { get; set; } = new List<RegularOrderProduct>();
    public ICollection<ActualOrderProduct>? ActualOrderProducts { get; set; } = new List<ActualOrderProduct>();
}