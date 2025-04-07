using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoradorBairroAPI.Models
{
    public class Morador
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore] // Isso faz com que o Id não seja exigido na requisição POST
        public string Id { get; set; } = null!;

        [BsonElement("nome")]
        [Required]
        public string Nome { get; set; } = null!;

        [BsonElement("idade")]
        [Required]
        public int Idade { get; set; }

        [BsonElement("bairroId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public string BairroId { get; set; } = null!;
    }
}
