using Autofac;
using REC.CHM.Core.Interfaces;
using REC.CHM.Core.Services;

namespace REC.CHM.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
