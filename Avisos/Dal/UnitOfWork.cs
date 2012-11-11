using Avisos.Models.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avisos.Dal
{
    public class UnitOfWork : IDisposable
    {
        private AvisoContext context = new AvisoContext();
        private AvisoRepository avisoRepository;


        public AvisoRepository AvisoRepository
        {
            get
            {
                if (this.avisoRepository == null)
                {
                    this.avisoRepository = new AvisoRepository(context);
                }
                return avisoRepository;
            }
        }


        public void Save()
        {
            int i = context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}