using System.Collections.Generic;
using Core.Models.Entities;
namespace Core.Models.Output
{
    public class QtMenuModel : DM_MENU
    {  
        public List<DM_MENU> ListMenuParent { get; set; }
    }
}