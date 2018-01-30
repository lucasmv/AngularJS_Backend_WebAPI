using System;

namespace TesteWebAPI.Models
{
    public class Contato
    {
        public Contato(string nome, string telefone, DateTime data, Operadora operadora)
        {
            Nome = nome;
            Telefone = telefone;
            Data = data;
            Operadora = operadora;
        }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Serial { get; set; }
        public DateTime Data { get; set; }
        public Operadora Operadora { get; set; }
    }
}