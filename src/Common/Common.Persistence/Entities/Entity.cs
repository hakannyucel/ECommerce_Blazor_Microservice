using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Common.Persistence.Entities
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Entity()
        {
        }

        public Entity(string id) : this()
        {
            Id = id;
        }
    }
}
