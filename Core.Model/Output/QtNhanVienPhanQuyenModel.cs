using System.Collections.Generic;
using Core.Models.Entities;
namespace Core.Models.Output
{
    public class QtNhanVienQuyenMenuModel : DM_MENU
    { 
        public long LEVEL { get; set; }
        public long IS_QUYEN { get; set; }        
    }    
    public class QtNhanVienQuyenModel
    {
        public long NHAN_VIEN_ID { get; set; }
        public List<QtNhanVienQuyenMenuModel> ListQuyenMenu { get; set; }
        public string DANH_SACH_MENU_ID { get; set; }        
    }
}