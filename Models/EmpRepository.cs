using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PhoneAPI.Models
{
    public class EmpRepository : IEmpRepository
    {
        private PhoneContext db = new PhoneContext();

            public void Update(Emp updatedemp)
            {
                var emp = this.Get(updatedemp.emp_Id);
                emp.dep_Id = updatedemp.dep_Id;
                emp.emp_name = updatedemp.emp_name;
                emp.mobile = updatedemp.mobile;
                emp.phone = updatedemp.phone;
                emp.rank_Id = updatedemp.rank_Id;

                db.SaveChanges();
            }

            public Emp Get(int id)
            {
                Emp emp = db.Emps.Find(id); 
                return emp;
            }

            public IQueryable<Emp> GetAll()
            {
                return db.Emps;
            }

            public void Post(Emp emp)
            {
                db.Emps.Add(emp);
                db.SaveChanges();
            }

            public Emp Delete(int id)
            {
                Emp emp = Get(id);
                if (emp == null)
                {
                    return null;
                }

                db.Emps.Remove(emp);

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }

                return emp;
            }
        }
 
}