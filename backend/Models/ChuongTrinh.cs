using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class ChuongTrinh
    {
        public ChuongTrinh()
        {
            DatLiches = new HashSet<DatLich>();
            Xes = new HashSet<Xe>();
        }

        public int ChuongTrinhId { get; set; }
        public string? TenChuongTrinh { get; set; }
        public DateTime? ThoiGianChieu { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string? DiaDiem { get; set; }
        public string? TacGia { get; set; }
        public int? Phong { get; set; }

        public virtual Phong? PhongNavigation { get; set; }
        public virtual ICollection<DatLich> DatLiches { get; set; }
        public virtual ICollection<Xe> Xes { get; set; }
    }
}
