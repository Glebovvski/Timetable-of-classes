using Schedule_CodeFirstModel.Models;
using Schedule_CodeFirstModel.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Schedule_CodeFirstModel
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IRepository<AcademicPlan>, AcademicPlanRepository>();
            container.RegisterType<IRepository<Subject>, SubjectRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}