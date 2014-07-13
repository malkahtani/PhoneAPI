using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneAPI.Models
{
    public interface IEmpRepository
    {
        void Update(Emp updatedDep);

        Emp Get(int id);

        IQueryable<Emp> GetAll();

        void Post(Emp dep);

        Emp Delete(int id);
    }
}