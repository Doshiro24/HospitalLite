using HospitalLite.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLite.Core.DTOs
{
    public record CreateUserDto(string FirstName, string LastName, string Email, string Password, UserRole Role);
}
