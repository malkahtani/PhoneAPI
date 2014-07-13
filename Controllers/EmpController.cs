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
    [EmpSelfLinkFilter]
    public class EmpController : BaseApiController
    {
       
        public EmpController(IEmpRepository repo)
            : base(repo)
        {
        }
        public List<EmpModel> Get()
        {
            if (TheEmpRepository.GetAll() != null) { 
           var query = TheEmpRepository.GetAll().ToList();
            List<EmpModel> ret = new List<EmpModel>(); 
            for (int i = 0; i < query.Count(); i++)

            {
                var emp = TheEmpModelFactory.Create(query.ElementAt(i));
                ret.Add(emp);
            }
            return ret;
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        public IQueryable<EmpModel> SearchByPhone(string phone)
        {
            if (TheEmpRepository.GetAll() != null)
            {
                var query = TheEmpRepository.GetAll();
                var phoneQuery =(
                from qphone in query
                where qphone.phone == phone 
                select qphone).ToList();
                
                List<EmpModel> ret = new List<EmpModel>();
                for (int i = 0; i < phoneQuery.Count(); i++)
                {
                    var emp = TheEmpModelFactory.Create(phoneQuery.ElementAt(i));
                    ret.Add(emp);
                }
                return ret.AsQueryable();
            }
            else
            {
                return null;
            }
          
        }
        [HttpGet]
        public IQueryable<EmpModel> SearchByMobile(string mobile)
        {
            if (TheEmpRepository.GetAll() != null)
            {
                var query = TheEmpRepository.GetAll();
                var mobileQuery = (
                from qmobile in query
                where qmobile.mobile == mobile
                select qmobile).ToList();

                List<EmpModel> ret = new List<EmpModel>();
                for (int i = 0; i < mobileQuery.Count(); i++)
                {
                    var emp = TheEmpModelFactory.Create(mobileQuery.ElementAt(i));
                    ret.Add(emp);
                }
                return ret.AsQueryable();
            }
            else
            {
                return null;
            }
         
        }

        [HttpGet]
        public IQueryable<EmpModel> SearchByName(string name)
        {
            if (TheEmpRepository.GetAll() != null)
            {
                var query = TheEmpRepository.GetAll();
                var nameQuery = (
                from qname in query
                where qname.emp_name.Contains(name)
                select qname).ToList();

                List<EmpModel> ret = new List<EmpModel>();
                for (int i = 0; i < nameQuery.Count(); i++)
                {
                    var emp = TheEmpModelFactory.Create(nameQuery.ElementAt(i));
                    ret.Add(emp);
                }
                return ret.AsQueryable();
            }
            else
            {
                return null;
            }
         
        }
       
        public HttpResponseMessage GetEmp(int id)
        {
            try
            {
                var dep = TheEmpRepository.Get(id);
                if (dep != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheEmpModelFactory.Create(dep));
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
        public HttpResponseMessage Post([FromBody] EmpModel empModel)
        {
            try
            {

                var entity = TheEmpModelFactory.Parse(empModel);

                if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read subject/tutor from body");

                TheEmpRepository.Post(entity);

                return Request.CreateResponse(HttpStatusCode.Created, TheEmpModelFactory.Create(entity));

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
        public HttpResponseMessage Put(int id, [FromBody] EmpModel depModel)
        {
            try
            {

                var updatedEmp = TheEmpModelFactory.Parse(depModel);

                if (updatedEmp == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read subject/tutor from body");

                var originalEmp = TheEmpRepository.Get(id);

                if (originalEmp == null || originalEmp.emp_Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Course is not found");
                }
                else
                {
                    updatedEmp.emp_Id = id;
                }

                TheEmpRepository.Update(updatedEmp);

                return Request.CreateResponse(HttpStatusCode.OK, TheEmpModelFactory.Create(updatedEmp));


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
                var course = TheEmpRepository.Get(id);

                if (course == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }



                this.TheEmpRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);



            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
