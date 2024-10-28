using Microsoft.AspNetCore.Mvc;
using CalculatorApp.Models;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var model = new CalculatorModel();
            return View(model);
        }

        // POST
        [HttpPost]
        public IActionResult Index(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
               
                model.Result = model.Number1 + model.Number2;
            }

            return View(model);
        }
    }
}
