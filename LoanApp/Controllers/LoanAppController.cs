#nullable disable
using LoanAppMVC.Client.LoanApiRequestDto;
using LoanAppMVC.Client.LoanApiResponseDto;
using LoanAppMVC.Models;
using LoanAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedClassLibrary;

namespace LoanAppMVC.Controllers
{
    public class LoanAppController : Controller
    {
        private readonly IHttpClientService _httpClient;
        string apiController = "LoanApp";

        public LoanAppController(IConfiguration configuration, IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Business
        //public async Task<IActionResult> Index()
        //{
        //    IList<LoanAppModel> models = new List<LoanAppModel>();

        //    var result = await _httpClient.GetAsync(apiController);
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<IList<LoanAppModel>>();
        //        readTask.Wait();

        //        models = readTask.Result;
        //    }
        //    else //web api sent error response 
        //    {
        //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //    }
        //    return View(models);
        //}
        public async Task<IActionResult> List(int businessId)
        {
            var result = await _httpClient.GetAsync(apiController + "/GetByBusiness/" + businessId.ToString());
            var models = new PaginatedList<LoanAppResponseDto>();
            if (result.IsSuccessStatusCode)
            {
                string data = await result.Content.ReadAsStringAsync();
                models = JsonConvert.DeserializeObject<PaginatedList<LoanAppResponseDto>>(data);
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            ViewData["businessId"] = businessId;
            return View("Index", models);
        }

        public IActionResult Create(int? businessId)
        {
            var model = new LoanAppRequestDto();
            model.BusinessId = businessId.HasValue ? businessId.Value : 0;
            model.DateSubmitted = DateTime.Today;
            return View(model);
        }

        // POST: Business/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanAppRequestDto model)
        {
            var result = await _httpClient.PostAsJsonAsync<LoanAppRequestDto>(apiController, model);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("List", new {businessId = model.BusinessId});
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

            var model = new LoanAppResponseDto();

            var result = await _httpClient.GetAsync(apiController + "/" + id.ToString());
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LoanAppResponseDto>();
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
        public async Task<IActionResult> Edit(int id, 
            [Bind("Id,Amount,PayBackInMonths,APRPercent,DateSubmitted,DateProcessed,Status,BusinessId")]LoanAppRequestDto model)
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
                var result = await _httpClient.PutAsJsonAsync(apiController, model);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("List", new { businessId = model.BusinessId });
                }
            }
            return View(model);
        }

        // GET: Business/Delete/5
        public async Task<IActionResult> DeleteAction(int? id, int? businessId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _httpClient.DeleteAsync(apiController + "/" + id.ToString());
            return RedirectToAction("List", new {businessId = businessId});

        }
    }
}
