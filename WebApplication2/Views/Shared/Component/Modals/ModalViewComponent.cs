using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Views.Shared.Component.Modals
{
    public class ModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Modals");
        }
    }
}
