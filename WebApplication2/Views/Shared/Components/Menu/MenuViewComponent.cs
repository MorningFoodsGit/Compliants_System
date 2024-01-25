using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Views.Shared.Component.Menu
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string activeMenuItem)
        {
            ViewBag.ActiveMenuItem = activeMenuItem;
            return View("Menu");
        }
    }
}
