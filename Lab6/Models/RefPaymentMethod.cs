using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefPaymentMethod
    {
        [Key]
        public int RefPaymentMethodId { get; set; }

        public string? RefPaymentMethodDescription { get; set; }

        public ICollection<Customer>? Customers { get; set; } = new List<Customer>();
    }
}
