using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MobileApp.Models;
using MobileApp.ViewModel;

namespace MobileApp.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly MobileAppDBcontext _context;
        public StaffRepository(MobileAppDBcontext context)
        {
            _context = context;
        }

        public  Staff? Create(Staff staff)
        {
            string query = "EXEC [dbo].[RegisterStaff] @username, @hash_password, @role";
			try
            {
                var x =  _context.Staffs.FromSqlRaw(query,
                        new SqlParameter("username", staff.Username),
                        new SqlParameter("hash_password", staff.HashPassword),
                        new SqlParameter("role", staff.Role)).AsEnumerable().FirstOrDefault();

               
				return x;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Staff?> getById(int id)
        {
			return await _context.Staffs.FirstOrDefaultAsync(staff => staff.StaffId == id);
		}

        public async Task<Staff?> getByUserName(string userName)
        {
			return await _context.Staffs.FirstOrDefaultAsync(staff => staff.Username == userName);
		}

		public Staff? Login(StaffLoginViewModel StaffLoginviewModel)
		{
            string query = "EXEC dbo.[login] @username, @password";
            try
            {
                Staff? staff = _context.Staffs.FromSqlRaw(query,
                    new SqlParameter("username", StaffLoginviewModel.Username),
                    new SqlParameter("password", StaffLoginviewModel.Password)).AsEnumerable().FirstOrDefault();
                return staff;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
			
		}
	}
}
