using HospitalLite.Core.DTOs;
using HospitalLite.Core.Entities;
using HospitalLite.Core.Enums;
using HospitalLite.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLite.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<AppUser> _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IGenericRepository<AppUser> userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateUserDto dto)
        {
            AppUser user = new AppUser
            {
                CreatedBy = "admin",
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };
            await _userRepo.AddAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateRefreshToken(int userId, string refreshToken, DateTime expiration)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = expiration;
                await _unitOfWork.CommitAsync();
            }

        }
    }
}
