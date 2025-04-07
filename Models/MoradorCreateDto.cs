namespace MoradorBairroAPI.Models.DTO
{
    public class MoradorCreateDto
    {
        public string Nome { get; set; } = null!;
        public int Idade { get; set; }
        public string BairroId { get; set; } = null!;
    }
}
