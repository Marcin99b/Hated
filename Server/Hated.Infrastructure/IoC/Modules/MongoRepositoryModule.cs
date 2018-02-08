using Autofac;
using System.Reflection;
using Hated.Core.Repositories;
using Hated.Infrastructure.Mongo;
using MongoDB.Driver;

namespace Hated.Infrastructure.IoC.Modules
{
    public class MongoRepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) =>
            {
                var settings = c.Resolve<MongoSettings>();
                return new MongoClient(settings.ConnectionString);
            }).SingleInstance();

            builder.Register((c, p) =>
            {
                var client = c.Resolve<MongoClient>();
                var settings = c.Resolve<MongoSettings>();
                var database = client.GetDatabase(settings.Database);

                return database;
            }).As<IMongoDatabase>();

            var assembly = typeof(MongoRepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
