using System;
using System.Collections.Generic;

namespace Core.Models.Entities
{
    public class GT_MENU
    {        
        public long ID { get; set; }        
        public long NHAN_VIEN_ID { get; set; }
        public long MENU_ID { get; set; }
        public long NGUOI_CAP_NHAT_ID { get; set; }
        public DateTime NGAY_CAP_NHAT { get; set; }
    }
}

