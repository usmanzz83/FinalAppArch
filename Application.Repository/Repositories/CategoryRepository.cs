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

    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetCategoriesWithProduct(int ProductId);
    }

    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private MyAppDbContext oDbContext;
        private IUnitOfWorkAsync oUnitofWork;        

        public CategoryRepository(MyAppDbContext context , IUnitOfWorkAsync UnitofWork) : base(context, UnitofWork)
        {
            oDbContext = context;
            oUnitofWork = UnitofWork;
        }

        public List<Category> GetCategoriesWithProduct(int ProductId)
        {
            return oDbContext.Categories.ToList();
        }
    }
}
