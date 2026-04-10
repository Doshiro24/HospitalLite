using HospitalLite.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLite.Core.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserDto dto);
        Task UpdateRefreshToken(int userId, string refreshToken, DateTime expiration);
    }
}
