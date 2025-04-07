using MoradorBairroAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MoradorBairroAPI.Services
{
    public class MoradorService
    {
        private readonly IMongoCollection<Morador> _moradores;
        private readonly IMongoCollection<Bairro> _bairros;

        public MoradorService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("CidadeInteligenteDB");
            _moradores = database.GetCollection<Morador>("moradores");
            _bairros = database.GetCollection<Bairro>("bairros");
        }

        public List<Morador> Get() =>
            _moradores.Find(morador => true).ToList();

        public Morador Get(string id) =>
            _moradores.Find(morador => morador.Id == id).FirstOrDefault();

        public Morador Create(Morador morador)
        {
            _moradores.InsertOne(morador);
            return morador;
        }

        public void Update(string id, Morador moradorAtualizado) =>
            _moradores.ReplaceOne(morador => morador.Id == id, moradorAtualizado);

        public void Remove(string id) =>
            _moradores.DeleteOne(morador => morador.Id == id);

        // 🔥 Novo método com bairro incluso
        public List<MoradorComBairro> GetComBairro()
        {
            var pipeline = new[]
            {
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "bairros" },
                    { "localField", "BairroId" },
                    { "foreignField", "_id" },
                    { "as", "bairroInfo" }
                }),
                new BsonDocument("$unwind", "$bairroInfo"),
                new BsonDocument("$project", new BsonDocument
                {
                    { "Id", "$_id" },
                    { "Nome", 1 },
                    { "Idade", 1 },
                    { "BairroId", 1 },
                    { "BairroNome", "$bairroInfo.nome" },
                    { "BairroZona", "$bairroInfo.zona" }
                })
            };

            return _moradores
                .Aggregate<MoradorComBairro>(pipeline)
                .ToList();
        }
    }
}
