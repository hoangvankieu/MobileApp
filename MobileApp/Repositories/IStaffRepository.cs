using Microsoft.AspNetCore.Mvc;
using MobileApp.Models;
using MobileApp.ViewModel;

namespace MobileApp.Repositories
{
    public interface IStaffRepository
    {
        public Task<Staff?> getByUserName(string userName);
        public Task<Staff?> getById(int id);
        public Staff? Create(Staff staff);
        public Staff? Login(StaffLoginViewModel StaffLoginviewModel);
    }
}
