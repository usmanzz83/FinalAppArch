using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Application.Entities.Entities;

namespace Application.Repository.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        
    }

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        private MyAppDbContext oDbContext;
        private IUnitOfWorkAsync oUnitofWork;


        public CustomerRepository(MyAppDbContext context, IUnitOfWorkAsync UnitofWork) : base(context, UnitofWork)
        {
            oDbContext = context;
            oUnitofWork = UnitofWork;
        }
    }
}
