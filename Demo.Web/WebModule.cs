using Autofac;

namespace Demo.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        public WebModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<DemoDbContext>().AsSelf().WithParameter("connectionString", _connectionString).InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
