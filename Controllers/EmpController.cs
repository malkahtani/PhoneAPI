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
        // GET: api/Emp
        // Return all employees as json i.e. [{"$id": "1" , "emp_Id": 1, "emp_name":"Mohammad","dep_Id" : 1 , "rank_Id": 2,"phone":"0118747430","mobile":"0555331717"},{"$id": "1" , "emp_Id": 3, "emp_name":"Saad","dep_Id" : 4, "rank_Id": 5,"phone":"0118747474","mobile":"0555334040"}]
       
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

        // GET: api/Emp?phone=0118747430
        // return the list of employees that have the phone number in the variable phone i.e 
        // [{"emp_Id": 3, "emp_name":"Mohammad","dep_Id" : 1 , "rank_Id": 2,"phone":"0118747430","mobile":"0555331717"}]
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
        // GET: api/Emp?mobile=0555331717
        // return the list of employees that have the mobile number in the variable mobile i.e 
        // [{"emp_Id": 3, "emp_name":"Mohammad","dep_Id" : 1 , "rank_Id": 2,"phone":"0118747430","mobile":"0555331717"}]
       
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
        // GET: api/Emp?name=Mohammad
        // return the list of employees that have the in their names the word in the variable name i.e 
        // [{"emp_Id": 3, "emp_name":"Mohammad","dep_Id" : 1 , "rank_Id": 2,"phone":"0118747430","mobile":"0555331717"}]
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

        // GET: api/Emp/3
        // Return one employee according to the id as json i.e. [{"emp_Id": 3, "emp_name":"Mohammad","dep_Id" : 1 , "rank_Id": 2,"phone":"0118747430","mobile":"0555331717"}]
      
        public HttpResponseMessage GetEmp(int id)
        {
            try
            {
                var emp = TheEmpRepository.Get(id);
                if (emp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheEmpModelFactory.Create(emp));
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
        //POST: api/Emp
        // Insert new employee to the repository
        [HttpPost]
        [CheckModelForNull]
        [ValidateModelState]
        public HttpResponseMessage Post([FromBody] EmpModel empModel)
        {
            try
            {

                var entity = TheEmpModelFactory.Parse(empModel);

                if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read employee from body");

                TheEmpRepository.Post(entity);

                return Request.CreateResponse(HttpStatusCode.Created, TheEmpModelFactory.Create(entity));

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Emp/5
        // Update the employee in the repository
        [HttpPatch]
        [HttpPut]
        [CheckModelForNull]
        [ValidateModelState]
        public HttpResponseMessage Put(int id, [FromBody] EmpModel depModel)
        {
            try
            {

                var updatedEmp = TheEmpModelFactory.Parse(depModel);

                if (updatedEmp == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read employee from body");

                var originalEmp = TheEmpRepository.Get(id);

                if (originalEmp == null || originalEmp.emp_Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Employee is not found");
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

        // DELETE: api/Emp/5
        // Delete employee from the repository
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
