using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models.Entities;
namespace Core.Models.Output
{
    public class MenuModel : DM_MENU
    {       
        public MenuModel()
        {  
        }       
        public decimal? MenuChaId { get; set; }
        public List<DM_MENU> ListMenuCha { get; set; }
        
    }
}