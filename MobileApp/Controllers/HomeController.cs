using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MobileApp.Controllers
{
	public class HomeController:Controller
	{
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}
	}
}
