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
    [DepSelfLinkFilter]
    public class DepController : BaseApiController
    {
      
        public DepController(IDepRepository repo)
            : base(repo)
        {
        }
        public IEnumerable<Dep> Get()
        {
            return TheDepRepository.GetAll();
        }
          
    public HttpResponseMessage GetDep(int id)
        {
            try
            {
                var dep = TheDepRepository.Get(id);
                if (dep != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheDepModelFactory.Create(dep));
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
    public HttpResponseMessage Post([FromBody] DepModel depModel)
    {
        try
        {

            var entity = TheDepModelFactory.Parse(depModel);

            if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read subject/tutor from body");

            TheDepRepository.Post(entity);
            
                return Request.CreateResponse(HttpStatusCode.Created, TheDepModelFactory.Create(entity));
            
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
        public HttpResponseMessage Put(int id, [FromBody] DepModel depModel)
        {
            try
            {

                var updatedDep = TheDepModelFactory.Parse(depModel);

                if (updatedDep == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read subject/tutor from body");
                
                var originalDep = TheDepRepository.Get(id);

                if (originalDep == null || originalDep.dep_Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Course is not found");
                }
                else
                {
                    updatedDep.dep_Id = id;
                }

                TheDepRepository.Update(updatedDep);
                
                    return Request.CreateResponse(HttpStatusCode.OK, TheDepModelFactory.Create(updatedDep));
                

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
                var course = TheDepRepository.Get(id);
                
                if (course == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                

                this.TheDepRepository.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK);
                
               

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
    }
}
