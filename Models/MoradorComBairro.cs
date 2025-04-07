namespace MoradorBairroAPI.Models
{
    public class MoradorComBairro
    {
        public string? Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Idade { get; set; }

        // Dados do bairro incorporados
        public string? BairroId { get; set; }
        public string? BairroNome { get; set; }
        public string? BairroZona { get; set; }
    }
}
