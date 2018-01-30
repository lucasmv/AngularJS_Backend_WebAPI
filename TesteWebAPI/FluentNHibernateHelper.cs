using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Entities;
using NHibernate.Tool.hbm2ddl;

namespace TesteWebAPI
{
    public class FluentNHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString)
                .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Usuario>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                 .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}