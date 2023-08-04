using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MobileApp.Models;

namespace MobileApp.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly MobileAppDBcontext _context;
        public StaffRepository(MobileAppDBcontext context)
        {
            _context = context;
        }

        public  void Create(Staff staff)
        {
            string query = "EXEC dbo.RegisterStaff @username, @hash_password, @role";
            try
            {
                    _context.Staffs.FromSqlRaw(query,
                        new SqlParameter("username", staff.Username),
                        new SqlParameter("hash_password", staff.HashPassword),
                        new SqlParameter("role", staff.Role));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Staff> getById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Staff> getByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
