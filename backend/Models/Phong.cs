using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class Phong
    {
        public Phong()
        {
            ChuongTrinhs = new HashSet<ChuongTrinh>();
        }

        public int PhongId { get; set; }
        public string? TenPhong { get; set; }

        public virtual ICollection<ChuongTrinh> ChuongTrinhs { get; set; }
    }
}
