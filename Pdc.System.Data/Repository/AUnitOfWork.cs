using System;
using System.Data.Entity;

namespace Pdc.System.Data.Repository
{
    /**
     *  Inherit from AUnitOfWork and add your repositories to the implementation like this:
     *
     *  private Repository<Lead> leadRepository;
     *  private Repository<Request> requestRepository;
     *
     *  public Repository<Lead> LeadRepository
     *  {
     *      get
     *      {
     *          return this.leadRepository ?? new Repository<Lead>(Context);
     *      }
     *  }
     *
     *  public Repository<Request> RequestRepository
     *  {
     *      get
     *      {
     *          return this.requestRepository ?? new Repository<Request>(Context);
     *      }
     *  }
     */

    /// <summary>
    ///     Provides a way for <seealso cref="Repository{TEntity}"/> classes to share a DbContext
    /// </summary>
    public abstract class AUnitOfWork : IDisposable
    {
        protected AUnitOfWork(DbContext context)
        {
            Context = context;
        }

        public bool Disposed { get; set; }

        public DbContext Context { get; }

        public int RowsAffected { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            RowsAffected = Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            Disposed = true;
        }
    }
}