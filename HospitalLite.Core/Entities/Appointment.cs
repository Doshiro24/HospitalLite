using HospitalLite.Core.Common;
using HospitalLite.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLite.Core.Entities
{
    public class Appointment:BaseEntity
    {
        public int PatientId { get; set; }
        public virtual AppUser Patient { get; set; } = null!; // hasta aslında AppUser tablosunda yer alır, Role'ü UserRole.Patient olmalıdır
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;

        public DateTime AppoinmentDate { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled; // Randevu durumu default olarak "Scheduled" (planlanmış) olarak ayarlanır
    }
}
