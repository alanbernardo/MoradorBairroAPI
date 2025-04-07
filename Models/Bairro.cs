using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoradorBairroAPI.Models
{
    public class Bairro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // Agora é anulável, não é mais exigido no POST

        [BsonElement("nome")]
        public string Nome { get; set; } = null!;

        [BsonElement("zona")]
        public string Zona { get; set; } = null!; // Ex: Norte, Sul, Leste, Oeste
    }
}
