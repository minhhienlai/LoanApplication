#nullable disable
using LoanAppMVC.Client.LoanApiRequestDto;
using LoanAppMVC.Client.LoanApiResponseDto;
using LoanAppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedClassLibrary;
using System.Text;

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
        public async Task<IActionResult> Index([FromQuery] int? pageNumber)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(apiController);
            if (pageNumber!=null) sb.Append("?pageNumber="+pageNumber.ToString());
            var result = await _httpClient.GetAsync(sb.ToString());
            PaginatedList<DemographicViewResponseDto> models = new PaginatedList<DemographicViewResponseDto>();
            if (result.IsSuccessStatusCode)
            {
                string data = await result.Content.ReadAsStringAsync();
                models = JsonConvert.DeserializeObject<PaginatedList<DemographicViewResponseDto>>(data);
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
        public async Task<IActionResult> Create(DemographicRequestDto model)
        {
            var result = await _httpClient.PostAsJsonAsync<DemographicRequestDto>(apiController, model);

            if (result.IsSuccessStatusCode)
            {
                int newId = result.Content.ReadAsAsync<int>().Result;
                return RedirectToAction("List", "Business", new { ownerId = newId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }


            return View(model);
        }

        // GET: Demographic/Edit/5
        public async Task<IActionResult> Edit(int? id, int? pageNo)
        {
            if (id == null)
            {
                return NotFound();
            }

            DemographicEditableResponseDto model = new DemographicEditableResponseDto();

            var result = await _httpClient.GetAsync(apiController + "/" + id.ToString());
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<DemographicEditableResponseDto>();
                readTask.Wait();

                model = readTask.Result;
                model.CurrentPage = pageNo.HasValue ? pageNo.Value:1;
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
        public async Task<IActionResult> Edit(int id, DemographicRequestDto model)
        {
            int oid = 0;
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
                var result = await _httpClient.PutAsJsonAsync<DemographicRequestDto>(apiController, model);
                if (result.IsSuccessStatusCode)
                {
                    oid = result.Content.ReadAsAsync<int>().Result;
                    return RedirectToAction("List", "Business", new { ownerId = oid });
                }
            }
            ViewData["OwnerId"] = oid;
            return View(model);
        }

        public async Task<IActionResult> DeleteAction(int? id, [FromQuery] int? pageNumber)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _httpClient.DeleteAsync(apiController + "/" + id.ToString());
            return RedirectToAction("Index", new { pageNumber  = pageNumber});
        }
    }
}
