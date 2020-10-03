using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Core.Models;
using Core.Models.Entities;
using Core.Models.Input;
using Core.Models.Output;
using Core.Common;

namespace Core.Repository
{
    public class MenuRepository : BaseRepository
    {
        public MenuRepository()
        {
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
        public ResultModel<DM_MENU> GetAllMenuById(long menuId)
        {
            var result = new ResultModel<DM_MENU>();
            BaseRepository adapter = new BaseRepository();
            adapter.AddParameter(":p_menu_id", menuId);
            string command = @"       SELECT   *
                                        FROM   dm_menu a WHERE id = :p_menu_id                                       
                                    ORDER BY   MENU_CHA_ID, THU_TU";
            try
            {
                result.Data = adapter.GetList<DM_MENU>(command, CommandType.Text, CustomConnectionState.CloseOnExit).FirstOrDefault();
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
        public ResultModel<List<QtMenuSearchResultModel>> Search(SearchModel<QtMenuModel> parameter)
        {
            var result = new ResultModel<List<QtMenuSearchResultModel>>();
            BaseRepository adapter = new BaseRepository();
            adapter.AddParameter("pId", parameter.Cretia.ID);
            adapter.AddParameter("pColumnOrder", parameter.ColumnOrder);
            adapter.AddParameter("pDirectionOrder", parameter.DirectionOrder);
            adapter.AddParameter("pPageIndex", parameter.PageIndex);
            adapter.AddParameter("pPageSize", parameter.PageSize);
            var totalRecord = adapter.AddParameter("pTotalRecord", OracleDbType.Int16, ParameterDirection.Output);
            adapter.AddParameter("pData", OracleDbType.RefCursor, ParameterDirection.Output);                        
            try
            {
                result.Data = adapter.GetList<QtMenuSearchResultModel>("PKG_DANH_MUC.P_SEARCH_MENU", CommandType.StoredProcedure, CustomConnectionState.CloseOnExit).ToList();
                result.IsError = false;                
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
        public List<QtNhanVienQuyenMenuModel> GetDanhSachMenuByNhanVienId(long pNhanVienId)
        {
            var result = new List<QtNhanVienQuyenMenuModel>();
            BaseRepository adapter = new BaseRepository();
            adapter.AddParameter("p_Nhan_Vien_Id", pNhanVienId);            
            adapter.AddParameter("pData", OracleDbType.RefCursor, ParameterDirection.Output);
            try
            {
                result = adapter.GetList<QtNhanVienQuyenMenuModel>("PKG_MENU.P_DS_MENU_BY_NV_ID", CommandType.StoredProcedure, CustomConnectionState.CloseOnExit).ToList();                
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
        public ResultModel<bool> DeleteMenuById(long menuId)
        {
            var result = new ResultModel<bool>();
            BaseRepository adapter = new BaseRepository();
            adapter.AddParameter(":p_menu_id", menuId);
            string command = @" DELETE FROM  dm_menu  WHERE id = :p_menu_id";
            try
            {
                adapter.ExecuteNonQuery(command, CommandType.Text, CustomConnectionState.CloseOnExit);
                result.IsError = false;               
                result.Message = "Thao tác thành công";
            }
            catch (Exception ex)
            {
                HandleDAOExceptions(ex);
                result.IsError = true;
                result.Message = "Thao tác không thành công";
            }
            finally
            {
                adapter.Dispose();
            }
            return result;
        }
        public ResultModel<bool> InsertOrUpdateMenu(DM_MENU parameter)
        {
            try
            {
                AddParameter("p_id", parameter.ID);
                AddParameter("p_m", parameter.M);
                AddParameter("p_ten", parameter.TEN);
                AddParameter("p_menu_cha_id", parameter.MENU_CHA_ID);
                AddParameter("p_bieu_tuong", parameter.BIEU_TUONG);
                AddParameter("p_url", parameter.URL);
                AddParameter("p_show", parameter.SHOW);
                AddParameter("p_thu_tu", parameter.THU_TU);   
                ExecuteNonQuery("pkg_danh_muc.P_Insert_Update_Menu", CommandType.StoredProcedure, CustomConnectionState.CloseOnExit);                
                if(parameter.ID > 0)
                {
                    return new ResultModel<bool>(false, "Cập nhật thành công", true);
                }
                else
                {
                    return new ResultModel<bool>(false, "Insert thành công", true);
                }
                
            }
            catch (Exception exception)
            {
                HandleDAOExceptions(exception);
                return new ResultModel<bool>(true, exception.Message, false);
            }
        }        
    }
}

