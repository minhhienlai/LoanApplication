#nullable disable
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
    public class DemographicController : Controller
    {
        private readonly IHttpClientService _httpClient;
        string apiController = "Demographic";

        public DemographicController(IConfiguration configuration, IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Demographic
        public async Task<IActionResult> Index()
        {
            
            IList<DemographicModel> models = new List<DemographicModel>();

            var result = await _httpClient.GetAsync(apiController);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<DemographicModel>>();
                readTask.Wait();

                models = readTask.Result;
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Demographic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNo,Email")] DemographicModel model)
        {
                var result = await _httpClient.PostAsJsonAsync<DemographicModel>(apiController, model);

                if (result.IsSuccessStatusCode)
                {
                    int newId = result.Content.ReadAsAsync<int>().Result;
                    return RedirectToAction("Create", "Business", new { ownerId = newId});
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }


            return View(model);
        }

        // GET: Demographic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DemographicModel model = new DemographicModel();

            var result = await _httpClient.GetAsync(apiController+"/" + id.ToString());
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<DemographicModel>();
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

        // POST: Demographic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNo,Email")] DemographicModel model)
        {
            int oid=0;
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
                var result = await _httpClient.PutAsJsonAsync<DemographicModel>(apiController, model);
                if (result.IsSuccessStatusCode)
                {
                    oid = result.Content.ReadAsAsync<int>().Result;
                    return RedirectToAction("List","Business", new { ownerId= oid });
                }
            }
            ViewData["OwnerId"] = oid;
            return View(model);
        }

        // GET: Demographic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _httpClient.DeleteAsync(apiController + "/" + id.ToString());
            return RedirectToAction("Index","List");
        }
    }
}
