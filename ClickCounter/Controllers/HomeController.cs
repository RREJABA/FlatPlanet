using ClickCounter.DAL;
using System.Web.Mvc;

namespace ClickCounter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View((object)DataAccess.GetCounter());
        }

        [HttpPost]
        public ActionResult UpdateClickCount()
        {
            string msg = "Click count limit reached";

            if (DataAccess.GetCounter() < 10)
            {
                DataAccess.UpdateCounter();
                return RedirectToAction("Index", "Home");
            }
                

            return View("Index", (object)msg);
        }
    }
}