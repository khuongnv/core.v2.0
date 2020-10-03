using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserModel
    {
        public int NguoiDungId { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string SessionId { get; set; }
        public long TinhThanhId { get; set; }
        public string MaTinhThanh { get; set; }
        public long? DonViId { get; set; }
    }
}
