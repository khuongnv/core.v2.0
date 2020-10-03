using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Repository;
using Core.Models;
using Core.Models.Entities;
using Core.Models.Input;
using Core.Models.Output;
namespace Core.Business
{

    public class NhanVienBusiness : BaseBusiness
    {
        private readonly NhanVienRepository repository;

        public NhanVienBusiness()
        {
            repository = new NhanVienRepository();
        }
        public ResultModel<List<DM_NHAN_VIEN>> GetAllNhanVien()
        {
            return repository.GetAllNhanVien();
        }
        public ResultModel<List<DM_NHAN_VIEN>> GetNhanVienByDonViId(long donViId)
        {
            return repository.GetNhanVienByDonViId(donViId);
        }
        public ResultModel<DM_NHAN_VIEN> GetThongTinNhanVienById(long Id)
        {
            return repository.GetThongTinNhanVienById(Id);
        }
        public ResultModel<List<QtNhanVienSearchResultModel>> Search(SearchModel<QtNhanVienModel> parameter)
        {
            return repository.Search(parameter);
        }
        public ResultModel<bool> DeleteNhanVienById(long Id)
        {
            return repository.DeleteNhanVienById(Id);
        }
        public ResultModel<bool> InsertOrUpdateNhanVien(DM_NHAN_VIEN parameter)
        {
            return repository.InsertOrUpdateNhanVien(parameter);
        }
        public ResultModel<bool> PhanQuyenMenuNhanVien(long pNhanVienId, string pDsMenu, long pNguoiCapNhatId)
        {
            return repository.PhanQuyenMenuNhanVien(pNhanVienId, pDsMenu, pNguoiCapNhatId);
        }  
    }
}



