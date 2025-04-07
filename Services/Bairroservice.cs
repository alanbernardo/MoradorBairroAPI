using MoradorBairroAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MoradorBairroAPI.Services
{
    public class BairroService
    {
        private readonly IMongoCollection<Bairro> _bairros;

        public BairroService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("CidadeInteligenteDB");
            _bairros = database.GetCollection<Bairro>("bairros");
        }

        public List<Bairro> Get() => _bairros.Find(b => true).ToList();

        public Bairro Get(string id) => _bairros.Find(b => b.Id == id).FirstOrDefault();

        public Bairro Create(Bairro bairro)
        {
            _bairros.InsertOne(bairro);
            return bairro;
        }

        public void Update(string id, Bairro bairroIn) =>
            _bairros.ReplaceOne(b => b.Id == id, bairroIn);

        public void Remove(string id) =>
            _bairros.DeleteOne(b => b.Id == id);
    }
}
