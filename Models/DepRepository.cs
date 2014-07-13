using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PhoneAPI.Models
{
    public class DepRepository : IDepRepository
    {
        

            private PhoneContext db = new PhoneContext();

            public void Update(Dep updateddep)
            {
                var dep = this.Get(updateddep.dep_Id);
                dep.dep_name = updateddep.dep_name;

                db.SaveChanges();
            }

            public Dep Get(int id)
            {
                Dep dep = db.Deps.Find(id); 
                return dep;
            }

            public IQueryable<Dep> GetAll()
            {
                return db.Deps;
            }

            public void Post(Dep dep)
            {
                db.Deps.Add(dep);
                db.SaveChanges();
            }

            public Dep Delete(int id)
            {
                Dep dep = Get(id);
                if (dep == null)
                {
                    return null;
                }

                db.Deps.Remove(dep);

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }

                return dep;
            }
        }
    
}