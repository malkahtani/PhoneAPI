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
        // GET: api/Rank
        // Return all ranks as json i.e. [{"$id": "1" , "rank_Id" : 1 , "rank_name": "Private"},{"$id":"2", "rank_Id": 5, "rank_name": "Captin"}]
      
        public IEnumerable<Rank> Get()
        {
            return TheRankRepository.GetAll();
        }

        // GET: api/Rank/3
        // Return one rank according to the id as json i.e. [{"rank_Id" : 3 , "rank_name": "Major"}]
       
        public HttpResponseMessage GetRank(int id)
        {
            try
            {
                var rank = TheRankRepository.Get(id);
                if (rank != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheRankModelFactory.Create(rank));
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
        //POST: api/Rank
        // Insert new rank to the repository
        [HttpPost]
        [CheckModelForNull]
        [ValidateModelState]
        public HttpResponseMessage Post([FromBody] RankModel rankModel)
        {
            try
            {

                var entity = TheRankModelFactory.Parse(rankModel);

                if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read rank from body");

                TheRankRepository.Post(entity);

                return Request.CreateResponse(HttpStatusCode.Created, TheRankModelFactory.Create(entity));

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        // PUT: api/Rank/5
        // Update the rank in the repository
        [HttpPatch]
        [HttpPut]
        [CheckModelForNull]
        [ValidateModelState]
        public HttpResponseMessage Put(int id, [FromBody] RankModel rankModel)
        {
            try
            {

                var updatedRank = TheRankModelFactory.Parse(rankModel);

                if (updatedRank == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read rank from body");

                var originalRank = TheRankRepository.Get(id);

                if (originalRank == null || originalRank.rank_Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Rank is not found");
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

        // DELETE: api/Rank/5
        // Delete rank from the repository
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var rank = TheRankRepository.Get(id);

                if (rank == null)
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
