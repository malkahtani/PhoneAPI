using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneAPI.Models
{
    public interface IRankRepository
    {
       
        void Update(Rank updatedRank); 
 
        Rank Get(int id); 
 
        IQueryable<Rank> GetAll(); 
 
        void Post(Rank rank); 
 
        Rank Delete(int id); 
    } 
}
