using HospitalLite.Core.DTOs;
using HospitalLite.Core.Entities;
using HospitalLite.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLite.Business.Services
{
    public class AuthService:IAuthService
    {
        private readonly IGenericRepository<AppUser> _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthService(IUnitOfWork unitOfWork, IGenericRepository<AppUser> userRepo, ITokenService tokenService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userRepo = userRepo;
            _tokenService = tokenService;
            _userService = userService;
        }

        public AuthService(IGenericRepository<AppUser> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepo.Where(x => x.Email == loginDto.Email).FirstOrDefaultAsync();

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                throw new Exception("Geçersiz e-posta veya şifre");
            }

            var tokenDto = _tokenService.CreateToken(user);

            await _userService.UpdateRefreshToken(user.Id, tokenDto.RefreshToken, DateTime.Now.AddDays(7));

            return tokenDto;
        }
    }
}
