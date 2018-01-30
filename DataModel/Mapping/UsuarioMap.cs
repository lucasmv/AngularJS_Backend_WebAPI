using DataModel.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("USUARIO");

            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.UserName).Column("USERNAME").Not.Nullable();
            Map(x => x.Password).Column("PASSWORD").Not.Nullable();
            Map(x => x.Data).Column("DATA");
            Map(x => x.Token).Column("TOKEN");
        }
    }
}
