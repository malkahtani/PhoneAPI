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
    // Return the link of the department and store it in the self variable in the model.
    public class DepSelfLinkFilter :  ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var response = actionExecutedContext.Response;
            Dep dep = null;
            if (response.TryGetContentValue<Dep>(out dep))
            {
                AddSelfLink(dep, actionExecutedContext);
            }

            IEnumerable<Dep> deps = null;
            if (response.TryGetContentValue<IEnumerable<Dep>>(out deps))
            {
                var objectContent = (ObjectContent<IEnumerable<Dep>>)actionExecutedContext.Response.Content;
                objectContent.Value = deps.Select(c => AddSelfLink(c, actionExecutedContext)).AsQueryable();
            }
        }

        Uri GetDepLink(int dep_Id, HttpActionExecutedContext context)
        {
            var routeData = context.Request.GetRouteData();
            var controller = routeData.Values["controller"];
            var urlHelper = context.Request.GetUrlHelper();
            return new Uri(urlHelper.Route("DefaultApi", new { controller = controller, id = dep_Id }), UriKind.Relative);
        }

        Dep AddSelfLink(Dep dep, HttpActionExecutedContext context)
        {
            dep.Self = GetDepLink(dep.dep_Id, context).ToString();
            return dep;
        }
    }
}