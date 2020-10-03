using System.Collections.Generic;
using Core.Models.Entities;
namespace Core.Models.Output
{
    public class QtNhanVienSearchResultModel : DM_NHAN_VIEN
    {
        public long? STT { get; set; }
        public string TEN_DON_VI { get; set; }
        public string TEN_GIOI_TINH { get; set; }
        public string TEN_TRINH_DO { get; set; }
        public string TEN_CHUC_VU { get; set; }
    }
}