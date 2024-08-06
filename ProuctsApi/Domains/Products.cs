using System.ComponentModel.DataAnnotations;

namespace ProuctsApi.Domains
{
    public class Products
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();
        public  string Name { get; set; }
        public Decimal Price { get; set; }
    }
}
