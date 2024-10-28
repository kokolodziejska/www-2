using Microsoft.AspNetCore.Mvc;
using FavoriteQuotesApp.Models;

namespace FavoriteQuotesApp.Controllers
{
    public class QuotesController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
