
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Extensions;
using WebApplication7.Models;

namespace WebApplicatin7.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
			var cart = HttpContext.Session.Get<Cart>("cart");
			return View(cart);
		}
	}
    
}
