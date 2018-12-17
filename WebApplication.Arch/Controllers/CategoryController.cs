using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Application.Service;
using Repository.Pattern.UnitOfWork;
using Application.Entities.Entities;
using Repository.Pattern.Ef6;
using AutoMapper;


namespace WebApplication.Arch.Controllers
{
    public class CategoryController : Base.BaseController
    {
        private readonly ICategoryService oCategoryService;
        private readonly IUnitOfWork oUnitofWork;


        public CategoryController(ICategoryService oService, IUnitOfWork UnitofWork)
        {
            oCategoryService = oService;
            oUnitofWork = UnitofWork;
        }


        // GET: Category
        public ActionResult Index()
        {
            // Get all categories and products data
            IEnumerable<Category> Categories = oCategoryService.Queryable();
            return View(Categories);
            //return View();
        }
        

        public ActionResult Ajax_CategoryList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            List<Category> Categories = oCategoryService.Queryable().ToList();
            List<Models.mCategory> mCatg = new List<Models.mCategory>();
            foreach (var o in Categories)
            {
                Models.mCategory  omCatg= new Models.mCategory { CategoryID = o.CategoryID, CategoryName = o.CategoryName, Description = o.Description };
                mCatg.Add(omCatg);
            }
            return Json(new { data = mCatg }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CategoryProducts(int? CategoryID)
        {
            Category oCategory = oCategoryService.Find(CategoryID);// .Queryable().ToList();

            Models.mCategory omCatg = new Models.mCategory { CategoryID = oCategory.CategoryID, CategoryName = oCategory.CategoryName, Description = oCategory.Description };
            omCatg.Products = new List<Product>();

            omCatg.Products.Add(new Product { ProductID = 1000 + omCatg.CategoryID, ProductName = omCatg.CategoryName + " - Prod 1", UnitPrice = 100 + omCatg.CategoryID });
            omCatg.Products.Add(new Product { ProductID = 2000 + omCatg.CategoryID, ProductName = omCatg.CategoryName + " - Prod 2", UnitPrice = 200 + omCatg.CategoryID });
            omCatg.Products.Add(new Product { ProductID = 3000 + omCatg.CategoryID, ProductName = omCatg.CategoryName + " - Prod 3", UnitPrice = 300 + omCatg.CategoryID });
            omCatg.Products.Add(new Product { ProductID = 4000 + omCatg.CategoryID, ProductName = omCatg.CategoryName + " - Prod 4", UnitPrice = 400 + omCatg.CategoryID });
            omCatg.Products.Add(new Product { ProductID = 5000 + omCatg.CategoryID, ProductName = omCatg.CategoryName + " - Prod 5", UnitPrice = 500 + omCatg.CategoryID });

            return Json(new { data = omCatg.Products }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Models.mCategory oCategory)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Models.mCategory , Category>());
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.mCategory, Category>());

            var mapper = config.CreateMapper(); // Mapper(config);
            Category oCatg = mapper.Map<Category>(oCategory);            

            //Category oCatg  = Mapper.Map<Category>(oCategory);

            if (ModelState.IsValid)
            {

                

                try
                {
                    if (oCatg.CategoryID == 0)
                        oCategoryService.Insert(oCatg);
                    else
                        oCategoryService.Update(oCatg);

                    oUnitofWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("SOME ERROR", ex.Message);
                    return Json(new { success = false, message = "Error while saving data. Data not saved." }, JsonRequestBehavior.AllowGet);
                    throw ex;
                }

                return Json(new { success = true, message = "Saved Successfully." }, JsonRequestBehavior.AllowGet);
            }
            else
                return View(oCategory);
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var Categ = oCategoryService.Find(id);


            Models.mCategory oCatg = new Models.mCategory { CategoryID = Categ.CategoryID, CategoryName = Categ.CategoryName, Description = Categ.Description, RowVersion = Categ.RowVersion };


            return View("AddCategory", oCatg);
        }



        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            var Catg = oCategoryService.Find(id);
            oCategoryService.Delete(Catg);

            try
            {
                oUnitofWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet); ;
        }

    }
}
