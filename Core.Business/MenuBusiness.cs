using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository;
using Core.Models;
using Core.Models.Entities;
using Core.Models.Input;
using Core.Models.Output;
using Core.Common;

namespace Core.Business
{
    
    public class MenuBusiness: BaseBusiness
    {
        private readonly MenuRepository repository;

        public MenuBusiness()
        {
            repository = new MenuRepository();            
        }        
        public ResultModel<List<DM_MENU>> GetAllMenu()
        {
            return repository.GetAllMenu();
        }
        public ResultModel<DM_MENU> GetAllMenuById(long menuId)
        {            
            return repository.GetAllMenuById(menuId);
        }
        public ResultModel<List<QtMenuSearchResultModel>> Search(SearchModel<QtMenuModel> parameter)
        {            
            return repository.Search(parameter);
        }
        public List<QtNhanVienQuyenMenuModel> GetDanhSachMenuByNhanVienId(long pNhanVienId)
        {
            return repository.GetDanhSachMenuByNhanVienId(pNhanVienId);
        }
        public ResultModel<bool> DeleteMenuById(long menuId)
        {
            return repository.DeleteMenuById(menuId);
        }
        public ResultModel<bool> InsertOrUpdateMenu(DM_MENU parameter)
        {
            return repository.InsertOrUpdateMenu(parameter);
        }       

    }
}



