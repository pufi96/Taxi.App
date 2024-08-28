using Autofac;
using MediatR.Pipeline;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;
using Taxi.Persistence.Repositories;
using Taxi.Aplication.Contracts.Persistence;

namespace Taxi.Aplication.Core;

public class AutofacInfrastructureModule : Module
{
    private readonly List<Assembly> _assemblies = [];

    public AutofacInfrastructureModule(Assembly? callingAssembly = null)
    {
        AddToAssembliesIfNotNull(callingAssembly);
    }

    private void AddToAssembliesIfNotNull(Assembly? assembly)
    {
        if (assembly != null)
        {
            _assemblies.Add(assembly);
        }
    }

    private void LoadAssemblies()
    {
        var infrastructureAssembly = Assembly.GetAssembly(typeof(AutofacInfrastructureModule));

        AddToAssembliesIfNotNull(infrastructureAssembly);
    }

    protected override void Load(ContainerBuilder builder)
    {
        LoadAssemblies();
        RegisterEF(builder);
        RegisterQueriesCommands(builder);
        //RegisterServices(builder);
        RegisterMediatR(builder);
    }

    private static void RegisterEF(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EFBaseRepository<>))
          .As(typeof(IAsyncRepository<>))
          .InstancePerLifetimeScope();
    }

    private void RegisterQueriesCommands(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes([.. _assemblies])
            .Where(t => t.Name.EndsWith("Repository"))
            .Where(t => t.GetInterfaces().Any(i => "I" + t.Name.Replace("EF", "") == i.Name))
            .As(t => t.GetInterfaces().First(i => "I" + t.Name.Replace("EF", "") == i.Name))
            .InstancePerLifetimeScope();
    }

    private static void RegisterServices(ContainerBuilder builder)
    {
        //builder.RegisterType<HttpContextAccessor>()
        //    .As<IHttpContextAccessor>()
        //    .SingleInstance();

        //builder.RegisterType<IdentityService>()
        //    .As<IIdentityService>()
        //    .InstancePerLifetimeScope();

        //builder.RegisterType<DatabaseConnectionService>()
        //    .As<IDatabaseConnectionService>()
        //    .InstancePerDependency();
    }

    private void RegisterMediatR(ContainerBuilder builder)
    {
        //builder
        //  .RegisterType<Mediator>()
        //  .As<IMediator>()
        //  .InstancePerLifetimeScope();

        //builder
        //  .RegisterGeneric(typeof(LoggingBehavior<,>))
        //  .As(typeof(IPipelineBehavior<,>))
        //  .InstancePerLifetimeScope();

        //builder
        //  .RegisterType<MediatRDomainEventDispatcher>()
        //  .As<IDomainEventDispatcher>()
        //  .InstancePerLifetimeScope();

        var mediatrOpenTypes = new[]
        {
          typeof(IRequestHandler<,>),
          typeof(IRequestExceptionHandler<,,>),
          typeof(IRequestExceptionAction<,>),
          typeof(INotificationHandler<>),
        };

        foreach (var mediatrOpenType in mediatrOpenTypes)
        {
            builder
              .RegisterAssemblyTypes([.. _assemblies])
              .AsClosedTypesOf(mediatrOpenType)
              .AsImplementedInterfaces();
        }
    }
}