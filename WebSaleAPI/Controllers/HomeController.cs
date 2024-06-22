using Microsoft.AspNetCore.Mvc;

namespace WebSaleAPI.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}