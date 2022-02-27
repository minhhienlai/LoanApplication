#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SharedClassLibrary.Data;
using SharedClassLibrary.Models;

namespace LoanAppMVC.Controllers
{
    public class LoanAppController : Controller
    {
        static HttpClient client = new HttpClient();
        string apiController = "LoanApp";

        public LoanAppController(IConfiguration configuration)
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("baseApiUri"));

            }
        }

        // GET: Business
        public async Task<IActionResult> Index()
        {
            IList<LoanAppModel> models = new List<LoanAppModel>();

            var result = await client.GetAsync(apiController);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<LoanAppModel>>();
                readTask.Wait();

                models = readTask.Result;
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(models);
        }
        public async Task<IActionResult> List(int businessId, int ownerId)
        {
            IList<LoanAppModel> models = new List<LoanAppModel>();

            var result = await client.GetAsync(apiController + "/GetByBusiness/" + businessId.ToString());
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<LoanAppModel>>();
                readTask.Wait();

                models = readTask.Result;
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            ViewData["OwnerId"] = ownerId;
            ViewData["BusinessId"] = businessId;
            return View("Index", models);
        }

        // GET: Business/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    LoanAppModel model = new LoanAppModel();

        //    var result = await client.GetAsync(apiController + "/" + id.ToString());
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<LoanAppModel>();
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
        public IActionResult Create(int? businessId)
        {
            LoanAppModel model = new LoanAppModel();
            model.BusinessId = businessId.HasValue ? businessId.Value : 0;
            model.DateSubmitted = DateTime.Today;
            return View(model);
        }

        // POST: Business/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanAppModel model)
        {
            var result = await client.PostAsJsonAsync<LoanAppModel>(apiController, model);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","List");
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
            if (id == null)
            {
                return NotFound();
            }

            LoanAppModel model = new LoanAppModel();

            var result = await client.GetAsync(apiController + "/" + id.ToString());
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LoanAppModel>();
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
        public async Task<IActionResult> Edit(int id, LoanAppModel model)
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
                var result = await client.PutAsJsonAsync<LoanAppModel>(apiController, model);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","List");
                }
            }
            return View(model);
        }

        // GET: Business/Delete/5
        public async Task<IActionResult> Delete(int? id, int? businessId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await client.DeleteAsync(apiController + "/" + id.ToString());
            return RedirectToAction("Index","List");

            //LoanAppModel model = new LoanAppModel();

            //var result = await client.GetAsync(apiController + "/" + id.ToString());
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<LoanAppModel>();
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
