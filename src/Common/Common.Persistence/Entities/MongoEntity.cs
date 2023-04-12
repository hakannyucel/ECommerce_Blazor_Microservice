using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.Persistence.Entities
{
    public class MongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public MongoEntity()
        {
        }

        public MongoEntity(string id) : this()
        {
            Id = id;
        }
    }
}
