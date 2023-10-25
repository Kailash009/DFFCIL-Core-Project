using HealthClaim.BAL.Repository.Interface;
using HealthClaim.BAL.Service;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Response;
using HealthClaim.Model.Dtos.UsersDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class AccountRepository : GenricRepository<ApplicationUser>, IAccountRepository
    {
        private readonly HealthClaimDbContext _dbContext;

        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly TokenService _tokenService;
        public AccountRepository(HealthClaimDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService) : base(db)
        {
            _dbContext = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<ResponeModel> AccountCreate(RegisterDto registerDto)
        {
            ResponeModel responeModel = new ResponeModel();
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.UserName) || await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName))
            {
                responeModel.Message = registerDto.UserName + " Email taken.";
                responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return responeModel;
            }
            var employee = _dbContext.Employees.Where(e => e.Id == registerDto.EmpId).FirstOrDefault();
            string empEmail = string.Empty;
            string empMobile = string.Empty;
            if (employee != null)
            {
                empEmail = employee.EmailId;
                empMobile = employee.Mobile;
            }
            var user = new ApplicationUser
            {
                Email = empEmail,
                UserName = registerDto.UserName,
                EmpId = registerDto.EmpId,
                PhoneNumber = empMobile,
            };
            await _userManager.AddPasswordAsync(user, registerDto.Password);
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                responeModel.Message = "Account created succesfully.";
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Message = "Email taken";
                responeModel.Data = user;
            }
            return responeModel;
        }

        public async Task<ResponeModel> Login(LoginDto loginDto)
        {
            ResponeModel responeModel = new ResponeModel();
            ApplicationUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);
            if (user == null)
            {
                responeModel.Message = loginDto.UserName + "Please check user name and password, the give user ar unautorized.";
                responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return responeModel;
            }

            var result = _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (result.IsCompletedSuccessfully)
            {
                responeModel.Message = "Login sucessfully";
                responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;

                var token = _tokenService.CrateToken(user);
                var Token = new { Token = token };
                responeModel.Data = Token;
                return responeModel;
            }
            responeModel.Message = loginDto.UserName + "Please check user name and password, the give user ar unautorized.";
            responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;

            return responeModel;
            //throw new NotImplementedException();
        }
    }
}
