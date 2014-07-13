using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneAPI.Models
{
    public interface IDepRepository
    {
        
            void Update(Dep updatedDep);

            Dep Get(int id);

            IQueryable<Dep> GetAll();

            void Post(Dep dep);

            Dep Delete(int id);
        
    }
}