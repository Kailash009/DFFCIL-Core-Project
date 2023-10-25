using HealthClaim.Model.Dtos.Response;
using HealthClaim.Model.Dtos.UsersDtos;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IAccountRepository
    {
        public Task<ResponeModel> AccountCreate(RegisterDto registerDto);
        public Task<ResponeModel> Login(LoginDto loginDto);
    }
}
