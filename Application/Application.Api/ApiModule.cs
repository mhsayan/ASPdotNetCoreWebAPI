using Autofac;

namespace Application.Api;

public class ApiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // builder.RegisterType<IndexModel>().AsSelf();

        base.Load(builder);
    }
}