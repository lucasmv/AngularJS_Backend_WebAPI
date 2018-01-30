using System;

namespace TesteWebAPI.Models
{
    public class ContatoDTO
    {
        public ContatoDTO(string nome, string telefone, DateTime data, OperadoraDTO operadora)
        {
            Nome = nome;
            Telefone = telefone;
            Data = data;
            Operadora = operadora;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime Data { get; set; }
        public int OperadoraId { get; set; }
        public string Serial { get; set; }
        public OperadoraDTO Operadora { get; set; }
    }
}