using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net.Http.Formatting;
using PhoneAPI.Models;
using System.Web.Http.Routing;

namespace PhoneAPI.Filters
{
    public class EmpSelfLinkFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var response = actionExecutedContext.Response;
            Emp emp = null;
            if (response.TryGetContentValue<Emp>(out emp))
            {
                AddSelfLink(emp, actionExecutedContext);
            }

            IEnumerable<Emp> emps = null;
            if (response.TryGetContentValue<IEnumerable<Emp>>(out emps))
            {
                var objectContent = (ObjectContent<IEnumerable<Emp>>)actionExecutedContext.Response.Content;
                objectContent.Value = emps.Select(c => AddSelfLink(c, actionExecutedContext)).AsQueryable();
            }
        }

        Uri GetEmpLink(int emp_Id, HttpActionExecutedContext context)
        {
            var routeData = context.Request.GetRouteData();
            var controller = routeData.Values["controller"];
            var urlHelper = context.Request.GetUrlHelper();
            return new Uri(urlHelper.Route("DefaultApi", new { controller = controller, id = emp_Id }), UriKind.Relative);
        }

        Emp AddSelfLink(Emp emp, HttpActionExecutedContext context)
        {
            emp.Self = GetEmpLink(emp.emp_Id, context).ToString();
            return emp;
        }
    }
}