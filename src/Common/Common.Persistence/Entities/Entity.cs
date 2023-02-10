using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Common.Persistence.Entities
{
    public class Entity
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]

        public Guid Id { get; set; }

        public Entity()
        {
        }

        public Entity(Guid id) : this()
        {
            Id = id;
        }
    }
}
