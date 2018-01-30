using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities
{
    public class Operadora
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual int Codigo { get; set; }
        public virtual string Categoria { get; set; }
        public virtual int Preco { get; set; }
    }
}
