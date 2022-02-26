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
            return View(models);
        }

        // GET: ListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
