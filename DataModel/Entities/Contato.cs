using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities
{
    public class Contato
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual int OperadoraId { get; set; }
        public virtual string Serial { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
