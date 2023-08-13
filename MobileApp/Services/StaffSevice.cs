using Microsoft.IdentityModel.Tokens;
using MobileApp.Models;
using MobileApp.Repositories;
using MobileApp.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MobileApp.Services
{
	public class StaffSevice : IStaffSevice
	{
		private readonly IStaffRepository _repository;
		private readonly IConfiguration _config;
		public StaffSevice(IStaffRepository repository,IConfiguration configuration)
		{
			_config = configuration;
			_repository = repository;
		}

		public async Task<Staff?> getById(int id)
		{
			return await _repository.getById(id);
		}

		public async Task<Staff?> getByUserName(string userName)
		{
			return await _repository.getByUserName(userName);
		}

		public string? Login(StaffLoginViewModel staffLoginViewModel)
		{
			Staff? staff = _repository.Login(staffLoginViewModel);
			if(staff != null)
			{
				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "")); ;
				var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			
				var Claim = new[]
				{
					new Claim(ClaimTypes.NameIdentifier,staff.StaffId.ToString()),
					new Claim(ClaimTypes.Role,staff.Role)
				};
				var token = new JwtSecurityToken(
						issuer: null,
						audience: null,
						claims: Claim,
						expires: DateTime.Now.AddDays(1),
						signingCredentials: credentials
					);
				return new JwtSecurityTokenHandler().WriteToken(token);
			}
			else
			{
				return null;
			}
		}

		public  Staff? Register(Staff staff)
		{
		   return 	_repository.Create(staff);
		}

		
	}
}
