namespace TesteWebAPI.Models
{
    public class Operadora
    {
        public Operadora(string nome, int codigo, string categoria, int preco)
        {
            Nome = nome;
            Codigo = codigo;
            Categoria = categoria;
            Preco = preco;
        }

        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Categoria { get; set; }
        public int Preco { get; set; }
    }
}