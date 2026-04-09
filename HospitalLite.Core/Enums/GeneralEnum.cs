using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLite.Core.Enums
{
    public enum AppointmentStatus
    {
        Scheduled = 1, //randevu oluşturuldu
        Checked = 2, // hasta hastaneye geldi ve muayene odasına alındı
        InExamination = 3, // MUAYENE ODASINDA İŞLEM GÖRÜYOR
        LabPending = 4, // laboratuvar işlemi bekleniyor, örneğin kan tahlili yapıldı ve sonuç bekleniyor
        Completed = 5, // işlem tamamlandı
        Cancelled = 6, // işlem iptal edildi
    }
}
