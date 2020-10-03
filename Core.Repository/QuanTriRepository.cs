using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.Entities;
using Core.Models.Input;
using Core.Models.Output;
using Core.Common;

namespace Core.Repository
{
    public class QuanTriRepository : BaseRepository
    {
        public QuanTriRepository()
        {
        }        
        /// <summary>
        /// Đăng Nhập
        /// </summary>
        /// <remarks>Updated by: KhươngNV</remarks>
        /// <returns></returns>      
        public bool isExitsUsername(string userName)
        {
            BaseRepository adapter = new BaseRepository();            
            var result = new ResultModel<DM_NHAN_VIEN>();
            bool isExits = false;            
            string command = "";            
            try
            {
                adapter.AddParameter(":userName", userName.ToLower());
                command = @" SELECT  * FROM   dm_nhan_vien a WHERE LOWER (a.user_name) = :userName";
                result.Data = adapter.GetList<DM_NHAN_VIEN>(command, CommandType.Text, CustomConnectionState.CloseOnExit).FirstOrDefault();
                if (result.Data != null)
                {
                    isExits = true;;
                }
                else
                {
                    isExits = false;
                }
            }
            catch (Exception ex)
            {
                adapter.HandleDAOExceptions(ex);
            }
            return isExits;
        }        
        public ResultModel<DM_NHAN_VIEN> LoginSuccess(string userName)
        {
            BaseRepository adapter = new BaseRepository();
            var result = new ResultModel<DM_NHAN_VIEN>();
                     
            string command = "";
            try
            {                      
                adapter.AddParameter(":userName", userName.ToLower());
                command = @" SELECT  *
                              FROM   dm_nhan_vien a
                                     WHERE LOWER (a.user_name) = :userName
                                     AND ROWNUM = 1 ";
                result.Data = adapter.GetList<DM_NHAN_VIEN>(command, CommandType.Text, CustomConnectionState.CloseOnExit).FirstOrDefault();
                result.IsError = false;
                if (result.Data == null)
                {
                    result.IsError = true;
                    result.Message = "Không tìm thấy thông tin người dùng";
                }
            }
            catch (Exception ex)
            {
                HandleDAOExceptions(ex);
            }
            finally
            {
                adapter.Dispose();
            }            
            return result;
        }
        public ResultModel<List<DM_MENU>> GetMenuByNhanvien(decimal nhanVienId)
        {
            var result = new ResultModel<List<DM_MENU>>();
            BaseRepository adapter = new BaseRepository();            
            adapter.AddParameter(":p_id_nhanvien", nhanVienId);
            string command = @"       SELECT   *
                                        FROM   dm_menu a
                                       WHERE   1 = 1
                                               AND ( (a.show = 1)
                                                    OR (EXISTS (SELECT   1
                                                                  FROM   gt_menu
                                                                 WHERE   nhan_vien_id = :p_id_nhanvien AND menu_id = a.id)))
                                    ORDER BY   MENU_CHA_ID, THU_TU";
            try
            {
                result.Data = adapter.GetList<DM_MENU>(command, CommandType.Text, CustomConnectionState.CloseOnExit);
                result.IsError = false;
                if (result.Data == null)
                {
                    result.IsError = true;
                    result.Message = "Không tìm thấy thông tin menu";
                }
            }
            catch (Exception ex)
            {
                HandleDAOExceptions(ex);
            }
            finally
            {
                adapter.Dispose();
            }
            return result;
        }
        public ResultModel<List<DM_MENU>> GetAllMenu()
        {
            var result = new ResultModel<List<DM_MENU>>();
            BaseRepository adapter = new BaseRepository();            
            string command = @"       SELECT   *
                                        FROM   dm_menu a                                       
                                    ORDER BY   MENU_CHA_ID, THU_TU";
            try
            {
                result.Data = adapter.GetList<DM_MENU>(command, CommandType.Text, CustomConnectionState.CloseOnExit);
                result.IsError = false;
                if (result.Data == null)
                {
                    result.IsError = true;
                    result.Message = "Không tìm thấy thông tin menu";
                }
            }
            catch (Exception ex)
            {
                HandleDAOExceptions(ex);
            }
            finally
            {
                adapter.Dispose();
            }
            return result;
        }        
    }
}

