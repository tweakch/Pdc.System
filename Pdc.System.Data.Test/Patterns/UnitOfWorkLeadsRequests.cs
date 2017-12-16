using System.Data.Entity;
using Pdc.System.Data.Repository;

namespace Pdc.System.Data.Test.Patterns
{
    public class UnitOfWorkLeadsRequests : AUnitOfWork
    {
        private readonly Repository<Lead> _leads;
        private readonly Repository<Request> _requests;

        public UnitOfWorkLeadsRequests(DbContext context) : base(context)
        {
        }

        public UnitOfWorkLeadsRequests(DbContext context, Repository<Lead> leads, Repository<Request> requests) : base(context)
        {
            _leads = leads;
            _requests = requests;
        }

        public Repository<Lead> Leads => _leads ?? new Repository<Lead>(Context);

        public Repository<Request> Requests => _requests ?? new Repository<Request>(Context);
    }
}