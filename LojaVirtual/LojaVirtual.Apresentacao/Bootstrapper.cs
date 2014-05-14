using System.Web.Mvc;
using LojaVirtual.Infraestrutura.Daos;
using LojaVirtual.Infraestrutura.Maps;
using LojaVirtual.Modelo;
using LojaVirtual.Repositorio;
using LojaVirtual.Servico;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace LojaVirtual.Apresentacao
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

      public static void RegisterTypes(IUnityContainer container)
      {
          container.RegisterType<IRepositorio<Categoria>, Repositorio<Categoria, CategoriaMap>>(
              new ContainerControlledLifetimeManager());
          container.RegisterType<IRepositorio<Mercadoria>, Repositorio<Mercadoria, MercadoriaMap>>(
              new ContainerControlledLifetimeManager());
          container.RegisterType<IRepositorio<Usuario>, Repositorio<Usuario, UsuarioMap>>(
              new ContainerControlledLifetimeManager());
          container.RegisterType<IRepositorio<Permissao>, Repositorio<Permissao, PermissaoMap>>(
              new ContainerControlledLifetimeManager());
          container.RegisterType<ISeguranca, Seguranca>(
              new ContainerControlledLifetimeManager());
          container.RegisterType<ICompras, Compras>(
              new ContainerControlledLifetimeManager());
      }
  }
}