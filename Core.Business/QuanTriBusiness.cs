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
namespace Core.Business
{
    
    public class QuanTriBusiness: BaseBusiness
    {
        private readonly QuanTriRepository repository;

        public QuanTriBusiness()
        {
            repository = new QuanTriRepository();            
        }        
        public ResultModel<DM_NHAN_VIEN> CheckAccount(string userName, string passWord)
        {
            var result = new ResultModel<DM_NHAN_VIEN>();
            if (string.IsNullOrEmpty(userName))
            {
                result.IsError = true;
                result.Message = "Bạn phải nhập tên đăng nhập";
                return result;
            }
            if (string.IsNullOrEmpty(passWord))
            {
                result.IsError = true;
                result.Message = "Bạn phải nhập mật khẩu";
                return result;
            }           
            
            var isCheckUser = repository.isExitsUsername(userName);
            if (!isCheckUser)
            {
                result.IsError = true;
                result.Message = "Tên đăng nhập không tồn tại";
                return result;                
            }
            else
            {
                //Lấy hình thức xác thực
                bool isCheckPassWord = true;
                /*
                string moTaLoi = "";               
                switch (xacThuc)
                {                    
                    case 1:
                        isCheckPassWord = CheckXacThucVnpt(userName, passWord, ref moTaLoi);
                        break;
                    default:
                        isCheckPassWord = repository.CheckXacThucLocal(userName, passWord);
                        break;
                }
                */                
                isCheckPassWord = true;
                if (!isCheckPassWord)
                {
                    result.IsError = true;
                    result.Message = "Tên đăng nhập không tồn tại";
                    return result;
                }
                else
                {
                    result = LoginSuccess(userName);
                    return result;
                }

            }
        }       
        
        

        /// <summary>
        /// LogIn
        /// </summary>
        /// <returns></returns>
        public ResultModel<DM_NHAN_VIEN> LoginSuccess(string userName)
        {
            return repository.LoginSuccess(userName);
        }
        public ResultModel<List<DM_MENU>> GetMenuByNhanvien(decimal nhanVienId)
        {
            return repository.GetMenuByNhanvien(nhanVienId);
        }
        public ResultModel<List<DM_MENU>> GetAllMenu()
        {
            return repository.GetAllMenu();
        }        

    }
}



