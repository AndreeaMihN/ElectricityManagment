using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Management.Domain.Client
{
    [BsonIgnoreExtraElements]
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = String.Empty;
        [BsonElement("firstName")]
        public string FirstName { get; set; } = String.Empty;
        [BsonElement("lastName")]
        public string LastName { get; set; } = String.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;
        [BsonElement("personalIdentificationNumber")]
        public string PersonalIdentificationNumber { get; set; } = String.Empty;

        [BsonElement("status")]
        public Boolean IsActive { get; set; }

    }
}
