using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobileApp.ViewModel
{
	public class StaffLoginViewModel
	{
		
		[Required]
		[StringLength(100)]
		public string Username { get; set; } = "";

		
		[Required]
		public string Password { get; set; } = "";
	}
}
