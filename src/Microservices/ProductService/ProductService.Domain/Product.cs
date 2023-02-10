using Common.Persistence.Entities;

namespace ProductService.Domain
{
    public class Product : Entity
    {
        public string ProductName { get; set; }
    }
}
