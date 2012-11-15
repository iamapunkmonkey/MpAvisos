using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Avisos.Models;

namespace Avisos.Dal
{
    public class AvisoContext : DbContext
    {
        public DbSet<Aviso> Avisos { get; set; }
        public AvisoContext()
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public class AvisoContextInitializer : DropCreateDatabaseIfModelChanges<AvisoContext>
        {
            protected override void Seed(AvisoContext context)
            {
                // Use the context to seed the db.
                base.Seed(context);
            }
        }
    }
}