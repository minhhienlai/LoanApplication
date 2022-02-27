using LoanAppMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary.Models;

namespace LoanAppMVC.Controllers
{
    public class ListController : Controller
    {
        static HttpClient client = new HttpClient();
        string apiController = "List";

        public ListController(IConfiguration configuration)
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("baseApiUri"));

            }
        }
        // GET: ListController
        public async Task<IActionResult> Index()
        {
            IList<ListModel> models = new List<ListModel>();

            var result = await client.GetAsync(apiController);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ListModel>>();
                readTask.Wait();

                models = readTask.Result;
            }
            else //web api sent error response 
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            SearchResultViewModel model = new SearchResultViewModel()
            {
                searchResult = models
            };
            return View(model);
        }

        public async Task<IActionResult> Search(string app,string bcode,string bname,
            int MinScore,int MaxScore, int MinAmount, int MaxAmount)
        {
            IList<ListModel> models = new List<ListModel>();
            string query = apiController + "/Search?";
             if (app != null && app.Length > 0) query += "app=" + app+"&";
             if (bcode != null && bcode.Length > 0) query += "bcode=" + bcode + "&";
             if (bname != null && bname.Length > 0) query += "bname=" + bname + "&";
             if (MinScore > 0) query += "MinScore=" + MinScore + "&";
             if (MaxScore > 0) query += "MaxScore=" + MaxScore + "&";
             if (MinAmount > 0) query += "MinAmount=" + MinAmount + "&";
             if (MaxAmount > 0) query += "MaxAmount=" + MaxAmount;

            var result = await client.GetAsync(query);
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ListModel>>();
                readTask.Wait();

                models = readTask.Result;
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
