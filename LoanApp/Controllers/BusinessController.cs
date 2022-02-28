﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Models;

namespace LoanAppMVC.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IHttpClientService _httpClient;
        string apiController = "Business";
        //string nextController = "LoanApp";

        public BusinessController(IConfiguration configuration, IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: Business
        public async Task<IActionResult> Index()
        {
            IList<BusinessModel> models = new List<BusinessModel>();

            var result = await _httpClient.GetAsync(apiController);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<BusinessModel>>();
                readTask.Wait();

                models = readTask.Result;
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(models);
        }

        public async Task<IActionResult> List(int ownerid)
        {
            IList<BusinessModel> models = new List<BusinessModel>();

            var result = await _httpClient.GetAsync(apiController+"/GetByDemo/"+ ownerid.ToString());
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<BusinessModel>>();
                readTask.Wait();

                models = readTask.Result;
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            ViewData["OwnerId"] = ownerid;
            return View("Index", models);
                //new BusinessListViewModel { modelList = models, OwnerId  = ownerid});
        }

        //// GET: Business/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    BusinessModel model = new BusinessModel();

        //    var result = await client.GetAsync(apiController + "/" + id.ToString());
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<BusinessModel>();
        //        readTask.Wait();

        //        model = readTask.Result;
        //    }
        //    else //web api sent error response 
        //    {
        //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        return NotFound();
        //    }

        //    return View(model);
        //}

        // GET: Business/Create
        public IActionResult Create(int? ownerId)
        {
            BusinessModel model = new BusinessModel();
            model.OwnerId = ownerId.HasValue? ownerId.Value:0;
            return View(model);
        }

        // POST: Business/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessModel model)
        {
            var result = await _httpClient.PostAsJsonAsync<BusinessModel>(apiController, model);

            if (result.IsSuccessStatusCode)
            {
                int newId = result.Content.ReadAsAsync<int>().Result;
                return RedirectToAction("Create", "LoanApp", new { businessId = newId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }


            return View(model);
        }

        // GET: Business/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
               return NotFound();
            }

            BusinessModel model = new BusinessModel();

            var result = await _httpClient.GetAsync(apiController + "/" + id.ToString());
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<BusinessModel>();
                readTask.Wait();

                model = readTask.Result;
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                return NotFound();
            }
            return View(model);
        }

        // POST: Business/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessCode,Name,Description,OwnerId")] BusinessModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            else
            {
                //HTTP POST
                var result = await _httpClient.PutAsJsonAsync<BusinessModel>(apiController, model);
                if (result.IsSuccessStatusCode)
                {
                    int oid = result.Content.ReadAsAsync<int>().Result;
                    return RedirectToAction("List", "LoanApp", new { businessId = oid });
                }
            }
            return View(model);
        }

        // GET: Business/Delete/5
        public async Task<IActionResult> Delete(int? id, int? ownerId)
        {
            if (id == null)
            {
                return NotFound();
            }
            string request = apiController + "/" + id.ToString();
            var result = await _httpClient.DeleteAsync(request);
            return RedirectToAction("List","Business", new {ownerId = ownerId});

            //BusinessModel model = new BusinessModel();

            //var result = await client.GetAsync(apiController + "/" + id.ToString());
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<BusinessModel>();
            //    readTask.Wait();

            //    model = readTask.Result;
            //}
            //else //web api sent error response 
            //{
            //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //    return NotFound();
            //}
            //return View(model);
        }

        // POST: Business/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await client.DeleteAsync(apiController + "/" + id.ToString());
        //    return RedirectToAction("Index");

        //}
    }
}
