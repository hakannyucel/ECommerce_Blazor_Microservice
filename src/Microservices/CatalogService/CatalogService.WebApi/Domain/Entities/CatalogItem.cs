using Common.Persistence.Entities;

namespace CatalogService.WebApi.Domain.Entities
{
    public class CatalogItem : Entity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
