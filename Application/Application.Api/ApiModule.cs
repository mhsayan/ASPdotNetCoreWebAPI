using Application.Api.Models;
using Autofac;

namespace Application.Api;

public class ApiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CreateStudentModel>().AsSelf();
        builder.RegisterType<GetStudentModel>().AsSelf();
        builder.RegisterType<UpdateStudentModel>().AsSelf();

        base.Load(builder);
    }
}