using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.Pattern.Repositories;
using Service.Pattern;
using Application.Entities.Entities;

namespace Application.Service
{
    public interface ICustomerService : IService<Customer>
    {

    }

    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(IRepositoryAsync<Customer> repository) : base(repository)
        {

        }
    }
}
