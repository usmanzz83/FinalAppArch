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
        
        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Ajax_CategoryList()
        {
            return View();
        }


        public JsonResult GetCategories()
        {
            List<Category> Categories = oCategoryService.Queryable().ToList();
            List<Models.mCategory> mCatg = new List<Models.mCategory>();
            foreach (var o in Categories)
            {
                mCatg.Add(new Models.mCategory { CategoryID = o.CategoryID, CategoryName = o.CategoryName, Description = o.Description });
            }

            return Json(new { data = mCatg }, JsonRequestBehavior.AllowGet);
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
                oCategoryService.Insert(oCatg);

                try
                {
                    oUnitofWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
                return View(oCategory);
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
