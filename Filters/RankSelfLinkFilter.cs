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
    public class RankSelfLinkFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var response = actionExecutedContext.Response;
            Rank rank = null;
            if (response.TryGetContentValue<Rank>(out rank))
            {
                AddSelfLink(rank, actionExecutedContext);
            }

            IEnumerable<Rank> ranks = null;
            if (response.TryGetContentValue<IEnumerable<Rank>>(out ranks))
            {
                var objectContent = (ObjectContent<IEnumerable<Rank>>)actionExecutedContext.Response.Content;
                objectContent.Value = ranks.Select(c => AddSelfLink(c, actionExecutedContext)).AsQueryable();
            }
        }

        Uri GetRankLink(int rank_Id, HttpActionExecutedContext context)
        {
            var routeData = context.Request.GetRouteData();
            var controller = routeData.Values["controller"];
            var urlHelper = context.Request.GetUrlHelper();
            return new Uri(urlHelper.Route("DefaultApi", new { controller = controller, id = rank_Id }), UriKind.Relative);
        }

        Rank AddSelfLink(Rank rank, HttpActionExecutedContext context)
        {
            rank.Self = GetRankLink(rank.rank_Id, context).ToString();
            return rank;
        }
    }
}