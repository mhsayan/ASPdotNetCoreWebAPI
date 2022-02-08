using Application.Api.Models;
using Autofac;

namespace Application.Api;

public class ApiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CreateStudentModel>().AsSelf();

        base.Load(builder);
    }
}