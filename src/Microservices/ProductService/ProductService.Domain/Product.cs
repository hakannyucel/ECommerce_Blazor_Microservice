using Common.Persistence.Entities;

namespace ProductService.Domain
{
    public class Product : Entity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int ReviewCount { get; set; }
        public List<string> Images { get; set; }
    }
}
