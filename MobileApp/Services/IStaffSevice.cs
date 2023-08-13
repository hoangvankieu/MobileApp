using MobileApp.Models;
using MobileApp.ViewModel;

namespace MobileApp.Services
{
	public interface IStaffSevice
	{
		public Task<Staff?> getByUserName(string userName);
		public Task<Staff?> getById(int id);
		public Staff? Register(Staff staff);
		public string? Login(StaffLoginViewModel staffLoginViewModel);
	}
}
