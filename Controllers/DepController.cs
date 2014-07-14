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
        // GET: api/Dep
        // Return all departments as json i.e. [{"$id": "1" , "dep_Id" : 1 , "dep_name": "HR"},{"$id":"2", "dep_Id": 5, "dep_name": "IT"}]
        public IEnumerable<Dep> Get()
        {
            return TheDepRepository.GetAll();
        }
       
        // GET: api/Dep/3
        // Return one department according to the id as json i.e. [{"dep_Id" : 3 , "dep_name": "HR"}]
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

        //POST: api/Dep
        // Insert new department to the repository
    [HttpPost]
    [CheckModelForNull]
    [ValidateModelState]
    public HttpResponseMessage Post([FromBody] DepModel depModel)
    {
        try
        {

            var entity = TheDepModelFactory.Parse(depModel);

            if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read department from body");

            TheDepRepository.Post(entity);
            
                return Request.CreateResponse(HttpStatusCode.Created, TheDepModelFactory.Create(entity));
            
        }
        catch (Exception ex)
        {

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        }
    }

    // PUT: api/Dep/5
    // Update the department in the repository
         [HttpPatch]
        [HttpPut]
         [CheckModelForNull]
        [ValidateModelState]
        public HttpResponseMessage Put(int id, [FromBody] DepModel depModel)
        {
            try
            {

                var updatedDep = TheDepModelFactory.Parse(depModel);

                if (updatedDep == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read department from body");
                
                var originalDep = TheDepRepository.Get(id);

                if (originalDep == null || originalDep.dep_Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Department is not found");
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

         // DELETE: api/Dep/5
         // Delete department from the repository
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var dep = TheDepRepository.Get(id);
                
                if (dep == null)
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
