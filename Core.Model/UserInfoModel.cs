using System.Collections.Generic;
using Core.Models.Entities;

namespace Core.Models
{
    public class UserInfoModel : DM_NHAN_VIEN
    { 
        public List<DM_MENU> ListMenu { get; set; }
        public List<string> Actions { get; set; }        
        public int HeThongId { get; set; }
    }
}