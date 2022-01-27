using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class Xe
    {
        public Xe()
        {
            DatLiches = new HashSet<DatLich>();
        }

        public int XeId { get; set; }
        public string? TenXe { get; set; }
        public DateTime? ThoiGianKhoiHanh { get; set; }
        public DateTime? ThoiGianVe { get; set; }
        public string? NguoiLaiXe { get; set; }
        public int? ChuongTrinh { get; set; }

        public virtual ChuongTrinh? ChuongTrinhNavigation { get; set; }
        public virtual ICollection<DatLich> DatLiches { get; set; }
    }
}
