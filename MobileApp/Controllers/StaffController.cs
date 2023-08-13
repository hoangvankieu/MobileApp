using Microsoft.AspNetCore.Mvc;
using MobileApp.Models;
using MobileApp.Services;
using MobileApp.ViewModel;

namespace MobileApp.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffSevice _staffSevice;
        public StaffController(IStaffSevice staffSevice)
        {
            _staffSevice = staffSevice;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
		
		public async Task<JsonResult> Register(Staff staff)
        {
			
			var _staff = await _staffSevice.getByUserName(staff.Username);
            if(_staff == null)
            {
                if (_staffSevice.Register(staff) != null)
                {
					return Json(new
					{
						isSuccess = true
					});
				}
			}
			return Json(new
			{
				isSuccess = false
			});
		}
        [HttpGet]
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(StaffLoginViewModel staffLogin)
        {
            var jwtString= _staffSevice.Login(staffLogin);
            if (jwtString == null)
            {
                return Json(new { isSuccess = false});
            }
            else
            {
                return Json(
                    new
                    {
						isSuccess = true,
                        Jwt= jwtString
                    });
            }
        }
    }
}
