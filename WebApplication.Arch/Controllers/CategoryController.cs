﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Service;
using Repository.Pattern.UnitOfWork;
using Application.Entities.Entities;

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
            IEnumerable<Category> Categories =  oCategoryService.Queryable();
            return View(Categories);
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
    }
}