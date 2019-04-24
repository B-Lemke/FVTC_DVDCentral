using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class FormatController : Controller
    {
        // GET: Format
        public ActionResult Index()
        {
            FormatList formats = new FormatList();
            formats.Load();
            return View(formats);
        }

        // GET: Format/Details/5
        public ActionResult Details(int id)
        {
            Format format = new Format { Id = id };
            format.LoadById();
            return View(format);
        }

        // GET: Format/Create
        public ActionResult Create()
        {
            Format format = new Format();
            return View(format);
        }

        // POST: Format/Create
        [HttpPost]
        public ActionResult Create(Format format)
        {
            try
            {
                // TODO: Add insert logic here
                format.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(format);
            }
        }

        // GET: Format/Edit/5
        public ActionResult Edit(int id)
        {
            Format format = new Format { Id = id };
            format.LoadById();
            return View(format);
        }

        // POST: Format/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Format format)
        {
            try
            {
                // TODO: Add update logic here
                format.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(format);
            }
        }

        // GET: Format/Delete/5
        public ActionResult Delete(int id)
        {
            Format format = new Format { Id = id };
            format.LoadById();
            return View(format);
        }

        // POST: Format/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Format format)
        {
            try
            {
                // TODO: Add delete logic here
                format.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(format);
            }
        }
    }
}
