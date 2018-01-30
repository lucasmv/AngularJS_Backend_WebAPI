namespace TesteWebAPI.Models
{
    public class OperadoraDTO
    {
        public OperadoraDTO(string nome, int codigo, string categoria, int preco)
        {
            Nome = nome;
            Codigo = codigo;
            Categoria = categoria;
            Preco = preco;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Categoria { get; set; }
        public int Preco { get; set; }
    }
}