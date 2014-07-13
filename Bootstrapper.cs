using System.Web.Mvc;
using Microsoft.Practices.Unity;
using PhoneAPI.Models;
using Unity.Mvc4;

namespace PhoneAPI
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
      container.RegisterType<IDepRepository, DepRepository>();
      container.RegisterType<IEmpRepository, EmpRepository>();
      container.RegisterType<IRankRepository, RankRepository>(); 

      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}