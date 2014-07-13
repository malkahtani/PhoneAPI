using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using PhoneAPI.Filters;
using PhoneAPI.Models;

namespace PhoneAPI.Controllers.api
{
    [RankSelfLinkFilter]
    public class RankController : BaseApiController
    {
       
        public RankController(IRankRepository repo)
            : base(repo)
        {
        }
        public IEnumerable<Rank> Get()
        {
            return TheRankRepository.GetAll();
        }
        
        public HttpResponseMessage GetRank(int id)
        {
            try
            {
                var dep = TheRankRepository.Get(id);
                if (dep != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheRankModelFactory.Create(dep));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPost]
        [CheckModelForNull]
        [ValidateModelState]
        public HttpResponseMessage Post([FromBody] RankModel depModel)
        {
            try
            {

                var entity = TheRankModelFactory.Parse(depModel);

                if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read subject/tutor from body");

                TheRankRepository.Post(entity);

                return Request.CreateResponse(HttpStatusCode.Created, TheRankModelFactory.Create(entity));

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPatch]
        [HttpPut]
        [CheckModelForNull]
        [ValidateModelState]
        public HttpResponseMessage Put(int id, [FromBody] RankModel depModel)
        {
            try
            {

                var updatedRank = TheRankModelFactory.Parse(depModel);

                if (updatedRank == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read subject/tutor from body");

                var originalRank = TheRankRepository.Get(id);

                if (originalRank == null || originalRank.rank_Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Course is not found");
                }
                else
                {
                    updatedRank.rank_Id = id;
                }

                TheRankRepository.Update(updatedRank);

                return Request.CreateResponse(HttpStatusCode.OK, TheRankModelFactory.Create(updatedRank));


            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var course = TheRankRepository.Get(id);

                if (course == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }



                this.TheRankRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);



            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
