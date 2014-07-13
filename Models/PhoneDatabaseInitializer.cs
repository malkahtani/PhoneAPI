using System;
using System.Data.Entity;
using PhoneAPI.Models;

namespace PhoneAPI.Models
{
    public class PhoneDatabaseInitializer : CreateDatabaseIfNotExists<PhoneContext>
    {
        protected override void Seed(PhoneContext context)
        {
            base.Seed(context);

            

        }
    }
}