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
    public class BusinessController : Controller
    {
        private readonly IHttpClientService _httpClient;
        string apiController = "Business";
        public BusinessController(IConfiguration configuration, IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: Business
        public async Task<IActionResult> Index()
        {
            IList<BusinessResponseDto> models = new List<BusinessResponseDto>();

            var result = await _httpClient.GetAsync(apiController);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<BusinessResponseDto>>();
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
            var result = await _httpClient.GetAsync(apiController+"/GetByDemo/"+ ownerid.ToString());
            var models = new PaginatedList<BusinessResponseDto>();
            if (result.IsSuccessStatusCode)
            {
                string data = await result.Content.ReadAsStringAsync();
                models = JsonConvert.DeserializeObject<PaginatedList<BusinessResponseDto>>(data);
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            ViewData["OwnerId"] = ownerid;
            return View("List", models);
        }

        public IActionResult Create(int? ownerId)
        {
            BusinessRequestDto model = new BusinessRequestDto();
            model.OwnerId = ownerId.HasValue? ownerId.Value:0;
            return View(model);
        }

        // POST: Business/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessRequestDto model)
        {
            var result = await _httpClient.PostAsJsonAsync<BusinessRequestDto>(apiController, model);

            if (result.IsSuccessStatusCode)
            {
                int newId = result.Content.ReadAsAsync<int>().Result;
                return RedirectToAction("List", "LoanApp", new { businessId = newId });
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

            var model = new BusinessResponseDto();

            var result = await _httpClient.GetAsync(apiController + "/" + id.ToString());
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<BusinessResponseDto>();
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessCode,Name,Description,OwnerId")] BusinessRequestDto model)
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
                var result = await _httpClient.PutAsJsonAsync<BusinessRequestDto>(apiController, model);
                if (result.IsSuccessStatusCode)
                {
                    int oid = result.Content.ReadAsAsync<int>().Result;
                    return RedirectToAction("List", "LoanApp", new { businessId = oid });
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteAction(int? id, int? ownerId, [FromQuery] int? pageNumber)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _httpClient.DeleteAsync(apiController + "/" + id.ToString());
            return RedirectToAction("List","Business", new { ownerid = ownerId });
        }
    }
}
