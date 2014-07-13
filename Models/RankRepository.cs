using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PhoneAPI.Models
{
    public class RankRepository :  IRankRepository 
    {

        private PhoneContext db = new PhoneContext(); 
 
        public void Update(Rank updatedrnak) 
        { 
            var rank = this.Get(updatedrnak.rank_Id); 
            rank.rank_name = updatedrnak.rank_name; 
           
            db.SaveChanges(); 
        } 
 
        public Rank Get(int id) 
        {
            Rank rank = db.Ranks.Find(id); 
            return rank; 
        } 
 
        public IQueryable<Rank> GetAll() 
        { 
            return db.Ranks; 
        } 
 
        public void Post(Rank rank) 
        { 
            db.Ranks.Add(rank); 
            db.SaveChanges(); 
        } 
 
        public Rank Delete(int id) 
        { 
            Rank rank = Get(id); 
            if (rank == null) 
            { 
                return null; 
            } 
 
            db.Ranks.Remove(rank); 
 
            try 
            { 
                db.SaveChanges(); 
            } 
            catch (DbUpdateConcurrencyException) 
            { 
                return null; 
            } 
 
            return rank; 
        } 
    }
}