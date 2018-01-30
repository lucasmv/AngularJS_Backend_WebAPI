using DataModel.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Mapping
{
    public class ContatoMap : ClassMap<Contato>
    {
        public ContatoMap()
        {
            Table("CONTATO");

            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.Nome).Column("NOME").Not.Nullable();
            Map(x => x.Telefone).Column("TELEFONE").Not.Nullable();
            Map(x => x.Data).Column("DATA");
            Map(x => x.OperadoraId).Column("OPERADORA_ID");
            Map(x => x.Serial).Column("SERIAL");

            //HasOne(x => x.Operadora).Constrained().ForeignKey();
            //this.References(x => x.Operadora).Column("OPERADORA_ID");
            References(x => x.Operadora).Column("OPERADORA_ID").Not.Insert().Not.Update();
        }
    }
}
