using LoanAppMVC.Models;
using LoanAppMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary;
using SharedClassLibrary.Models;

namespace LoanAppMVC.Controllers
{
    public class ListController : Controller
    {
        private readonly IHttpClientService _httpClient;
        string apiController = "List";
        const int PAGE_SIZE = 50;

        public ListController(IConfiguration configuration, IHttpClientService httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: ListController
        //public async Task<IActionResult> Index(int? pageNumber)
        //{
        //    IList<ListModel> searchResult = new List<ListModel>();
        //    PaginatedList<ListModel> models = new PaginatedList<ListModel>();

        //    var result = await _httpClient.GetAsync(apiController);
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<IList<ListModel>>();
        //        readTask.Wait();

        //        searchResult = readTask.Result;

        //        models = PaginatedList<ListModel>.Create(searchResult, pageNumber ?? 1, PAGE_SIZE);
        //    }
        //    else //web api sent error response 
        //    {
        //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //    }
        //    SearchResultViewModel model = new SearchResultViewModel()
        //    {
        //        searchResult = models
        //    };
        //    return View(model);
        //}

        public async Task<IActionResult> Index(int? pageNumber,
            string app,string bcode,string bname,
            int MinScore,int MaxScore, int MinAmount, int MaxAmount)
        {
            IList<ListModel> searchResult = new List<ListModel>();
            PaginatedList<ListModel> models = new PaginatedList<ListModel>();

            string filter = "";
             if (app != null && app.Length > 0) filter += "app=" + app+"&";
             if (bcode != null && bcode.Length > 0) filter += "bcode=" + bcode + "&";
             if (bname != null && bname.Length > 0) filter += "bname=" + bname + "&";
             if (MinScore > 0) filter += "MinScore=" + MinScore + "&";
             if (MaxScore > 0) filter += "MaxScore=" + MaxScore + "&";
             if (MinAmount > 0) filter += "MinAmount=" + MinAmount + "&";
             if (MaxAmount > 0) filter += "MaxAmount=" + MaxAmount;

            string query = apiController + ((filter.Length> 0) ? "/Search?" + filter: "");

            var result = await _httpClient.GetAsync(query);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ListModel>>();
                readTask.Wait();

                searchResult = readTask.Result;
                
                models = PaginatedList<ListModel>.Create(searchResult, pageNumber ?? 1, PAGE_SIZE);
            }
            else if ((int)result.StatusCode == StatusCodes.Status404NotFound)
            {
                ModelState.AddModelError(string.Empty, "No results");
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            SearchResultViewModel model = new SearchResultViewModel()
            {
                app = app,
                bcode = bcode,
                bname = bname,
                MinScore = MinScore,
                MaxScore = MaxScore,
                MinAmount = MinAmount,
                MaxAmount = MaxAmount,
                searchResult = models
            };
            return View("Index", model);
        }

        // GET: ListController/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: ListController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //// GET: ListController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ListController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
