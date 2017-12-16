

using System.Data.Entity;

namespace Pdc.System.Data.Test.Patterns
{
    using Pdc.System.Data.Repository;

    public class UnitOfWorkLeadsRequests : AUnitOfWork
    {
        private readonly Repository<Lead> _leads;
        private readonly Repository<Request> _requests;

        public UnitOfWorkLeadsRequests(TestContext context) : base(context)
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