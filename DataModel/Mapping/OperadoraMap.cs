using DataModel.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Mapping
{
    public class OperadoraMap : ClassMap<Operadora>
    {
        public OperadoraMap()
        {
            Table("OPERADORA");

            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.Nome).Column("NOME").Not.Nullable();
            Map(x => x.Codigo).Column("CODIGO").Not.Nullable();
            Map(x => x.Categoria).Column("CATEGORIA");
            Map(x => x.Preco).Column("PRECO");
        }
    }
}
