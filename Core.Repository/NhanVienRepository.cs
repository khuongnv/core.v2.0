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
    public class NhanVienRepository : BaseRepository
    {
        public NhanVienRepository()
        {
        }
        public ResultModel<List<DM_NHAN_VIEN>> GetAllNhanVien()
        {
            var result = new ResultModel<List<DM_NHAN_VIEN>>();
            BaseRepository adapter = new BaseRepository();
            string command = @"       SELECT   *
                                        FROM   dm_nhan_vien a  
                                       WHERE   hoat_dong = 1
                                    ORDER BY   ma";
            try
            {
                result.Data = adapter.GetList<DM_NHAN_VIEN>(command, CommandType.Text, CustomConnectionState.CloseOnExit);
                result.IsError = false;
                if (result.Data == null)
                {
                    result.IsError = true;
                    result.Message = "Không tìm thấy thông tin";
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
        public ResultModel<List<DM_NHAN_VIEN>> GetNhanVienByDonViId(long donViId)
        {
            var result = new ResultModel<List<DM_NHAN_VIEN>>();
            BaseRepository adapter = new BaseRepository();
            adapter.AddParameter(":don_vi_id", donViId);
            string command = @"       SELECT   *
                                        FROM   dm_nhan_vien a  
                                       WHERE   don_vi_id = :don_vi_id
                                    ORDER BY   ma";
            try
            {
                result.Data = adapter.GetList<DM_NHAN_VIEN>(command, CommandType.Text, CustomConnectionState.CloseOnExit);
                result.IsError = false;
                if (result.Data == null)
                {
                    result.IsError = true;
                    result.Message = "Không tìm thấy thông tin";
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
        public ResultModel<DM_NHAN_VIEN> GetThongTinNhanVienById(long Id)
        {
            var result = new ResultModel<DM_NHAN_VIEN>();
            BaseRepository adapter = new BaseRepository();
            adapter.AddParameter(":p_id", Id);
            string command = @"       SELECT   *
                                        FROM   dm_nhan_vien a WHERE id = :p_id";
            try
            {
                result.Data = adapter.GetList<DM_NHAN_VIEN>(command, CommandType.Text, CustomConnectionState.CloseOnExit).FirstOrDefault();
                result.IsError = false;
                if (result.Data == null)
                {
                    result.IsError = true;
                    result.Message = "Không tìm thấy thông tin";
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
        public ResultModel<List<QtNhanVienSearchResultModel>> Search(SearchModel<QtNhanVienModel> parameter)
        {
            var result = new ResultModel<List<QtNhanVienSearchResultModel>>();
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
                result.Data = adapter.GetList<QtNhanVienSearchResultModel>("PKG_DANH_MUC.P_SEARCH_NHAN_VIEN", CommandType.StoredProcedure, CustomConnectionState.CloseOnExit).ToList();
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
        public ResultModel<bool> DeleteNhanVienById(long Id)
        {
            var result = new ResultModel<bool>();
            BaseRepository adapter = new BaseRepository();
            adapter.AddParameter(":p_id", Id);
            string command = @" DELETE FROM  dm_nhan_vien  WHERE id = :p_id";
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
        public ResultModel<bool> InsertOrUpdateNhanVien(DM_NHAN_VIEN parameter)
        {
            try
            {
                parameter.HOAT_DONG = 1;
                AddParameter("p_id", parameter.ID);
                AddParameter("p_ma", parameter.MA);
                AddParameter("p_ten", parameter.TEN);
                AddParameter("p_don_vi_id", parameter.DON_VI_ID);
                AddParameter("p_ngay_sinh", parameter.NGAY_SINH);
                AddParameter("p_so_the", parameter.SO_THE);
                AddParameter("p_user_name", parameter.USER_NAME);
                AddParameter("p_hoat_dong", parameter.HOAT_DONG);                
                AddParameter("p_so_di_dong", parameter.SO_DI_DONG);                
                ExecuteNonQuery("pkg_danh_muc.P_Insert_Update_Nhanvien", CommandType.StoredProcedure, CustomConnectionState.CloseOnExit);
                if (parameter.ID > 0)
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
        public ResultModel<bool> PhanQuyenMenuNhanVien(long pNhanVienId, string pDsMenu, long pNguoiCapNhatId)
        {
            try
            {
                AddParameter("p_Nhan_Vien_id", pNhanVienId);
                AddParameter("p_Ds_Menu", pDsMenu);
                AddParameter("p_Nguoi_Cap_Nhat_Id", pNguoiCapNhatId);
                var pReturn = AddParameter("o_Is_Error", OracleDbType.Int16, ParameterDirection.Output);
                ExecuteNonQuery("pkg_danh_muc.P_PhanQuyen_Nhanvien_Menu", CommandType.StoredProcedure, CustomConnectionState.CloseOnExit);
                var result = long.Parse(pReturn.Value.ToString());
                if (result == 0)
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

