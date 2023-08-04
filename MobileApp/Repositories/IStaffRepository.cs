using Microsoft.AspNetCore.Mvc;
using MobileApp.Models;

namespace MobileApp.Repositories
{
    public interface IStaffRepository
    {
        public Task<Staff> getByUserName(string userName);
        public Task<Staff> getById(int id);
        public void Create(Staff staff);
    }
}
