using Application.Operation.Contexts;
using Application.Operation.Repositories;
using Application.Operation.Services;
using Application.Operation.UnitOfWorks;
using Autofac;

namespace Application.Operation;

public class OperationModule : Module
{
    private readonly string _connectionString;
    private readonly string _migrationAssemblyName;

    public OperationModule(string connectionString, string migrationAssemblyName)
    {
        _connectionString = connectionString;
        _migrationAssemblyName = migrationAssemblyName;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<OperationDbContext>().AsSelf()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();

        builder.RegisterType<OperationDbContext>().As<IOperationDbContext>()
            .WithParameter("connectionString", _connectionString)
            .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            .InstancePerLifetimeScope();

        builder.RegisterType<StudentService>().As<IStudentService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<StudentRepository>().As<IStudentRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<OperationUnitOfWork>().As<IOperationUnitOfWork>()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}