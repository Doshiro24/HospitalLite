using HospitalLite.Core.DTOs;
using HospitalLite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLite.Core.Interfaces
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser user);
    }
}
