using HospitalLite.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLite.Core.Entities
{
    public class UserClaim:BaseEntity
    {
        public int AppUserId { get; set; }
        public string ClaimType { get; set; } = string.Empty; // "Permission", "Role" gibi claim türleri
        public string ClaimValue { get; set; } = string.Empty; // "ViewPatients", "Lab.Read" gibi claim değerleri
    }
}
