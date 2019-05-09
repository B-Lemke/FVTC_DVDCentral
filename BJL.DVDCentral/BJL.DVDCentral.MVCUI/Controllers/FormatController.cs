using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class FormatController : Controller
    {
        FormatList formats;
        Format format;
        #region Format no api

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
     
        #endregion



        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            Uri baseAddress = new Uri("http://bjldvdcentralapi.azurewebsites.net/api/");
            client.BaseAddress = baseAddress;
            return client;
        }



        public ActionResult Get()
        {
            
            //Initialize Cient
            HttpClient client = InitializeClient();

            //Call the API
            HttpResponseMessage response = client.GetAsync("Format").Result;

            //Deserialize the json
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            formats = items.ToObject<FormatList>();

            return View("Index", formats);
        }

        public ActionResult GetOne(int id)
        {
            //Initialize Cient
            HttpClient client = InitializeClient();

            //Call the API
            HttpResponseMessage response = client.GetAsync("Format/" + id).Result;

            //Deserialize the json
            string result = response.Content.ReadAsStringAsync().Result;
            format = JsonConvert.DeserializeObject<Format>(result);

            return View("Details", format);
        }


        public ActionResult Insert()
        {
            //Initialize Cient
            HttpClient client = InitializeClient();

            format = new Format();

            return View("Create", format);
        }

        [HttpPost]
        public ActionResult Insert(Format format)
        {
            try
            {
                //Initialize Cient
                HttpClient client = InitializeClient();


                HttpResponseMessage response = client.PostAsJsonAsync("Format", format).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create", format);
            }
        }


        public ActionResult Update(int id)
        {
            //Initialize Cient
            HttpClient client = InitializeClient();

            //Call the API to get a program
            HttpResponseMessage response = client.GetAsync("Format/" + id).Result;
            //Deserialize the json
            string result = response.Content.ReadAsStringAsync().Result;
            format = JsonConvert.DeserializeObject<Format>(result);

            return View("Edit", format);
        }

        [HttpPost]
        public ActionResult Update(int id, Format format)
        {
            try
            {
                //Initialize Cient
                HttpClient client = InitializeClient();

                HttpResponseMessage response = client.PutAsJsonAsync("Format/" + id, format).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Edit", format);
            }
        }



        public ActionResult Remove(int id)
        {
            //Initialize Cient
            HttpClient client = InitializeClient();

            //Call the API to get a program
            HttpResponseMessage response = client.GetAsync("Format/" + id).Result;
            //Deserialize the json
            string result = response.Content.ReadAsStringAsync().Result;
            format = JsonConvert.DeserializeObject<Format>(result);


            return View("Delete", format);
        }

        [HttpPost]
        public ActionResult Remove(int id, Format format)
        {
            try
            {
                //Initialize Cient
                HttpClient client = InitializeClient();

                HttpResponseMessage response = client.DeleteAsync("Format/" + id).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Delete", format);
            }
        }
    }
}
