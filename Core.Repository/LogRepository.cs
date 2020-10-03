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
    public class LogRepository : BaseRepository
    {
        public LogRepository()
        {
        }
        public ResultModel<List<LogUserModel>> LogUserDangNhap()
        {
            var result = new ResultModel<List<LogUserModel>>();
            BaseRepository adapter = new BaseRepository();
            string sQL = "";
            try
            {
                sQL = @" SELECT ROWNUM STT, a.*
                            FROM LOG_USER a
                            ORDER BY a.TG_THUC_HIEN DESC ";
                result.Data = adapter.GetList<LogUserModel>(sQL, CommandType.Text, CustomConnectionState.CloseOnExit).ToList();
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
        public ResultModel<List<LogThaoTacModel>> LogUserThaoTac()
        {
            var result = new ResultModel<List<LogThaoTacModel>>();
            BaseRepository adapter = new BaseRepository();
            string sQL = "";
            try
            {
                sQL = @" SELECT ROWNUM STT, a.*
                            FROM LOG_THAO_TAC a
                            ORDER BY a.TG_THUC_HIEN DESC ";
                result.Data = adapter.GetList<LogThaoTacModel>(sQL, CommandType.Text, CustomConnectionState.CloseOnExit).ToList();
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
        public void LogDangNhap(string TenDangNhap, string sessionId, long LogInOut, string ipMayChu, string ipMayTram, string trinhDuyet, long thanhCong)
        {
            BaseRepository adapter = new BaseRepository();
            string command = "";
            try
            {
                adapter.AddParameter(":TEN_DANG_NHAP", TenDangNhap);
                adapter.AddParameter(":SESSION_ID", sessionId);
                adapter.AddParameter(":LOG_IN_OUT", LogInOut);
                adapter.AddParameter(":IP_MAY_CHU", ipMayChu);
                adapter.AddParameter(":IP_MAY_TRAM", ipMayTram);
                adapter.AddParameter(":TRINH_DUYET", trinhDuyet);
                adapter.AddParameter(":THANH_CONG", thanhCong);
                command = @" INSERT INTO LOG_USER (
                                                        TEN_DANG_NHAP,
                                                        SESSION_ID,
                                                        LOG_IN_OUT,
                                                        IP_MAY_CHU,
                                                        IP_MAY_TRAM,
                                                        TRINH_DUYET,
                                                        THANH_CONG
                                                    )
                                            VALUES (:TEN_DANG_NHAP, :SESSION_ID, :LOG_IN_OUT, :IP_MAY_CHU, :IP_MAY_TRAM,
                                                :TRINH_DUYET, :THANH_CONG)";
                adapter.ExecuteNonQuery(command, CommandType.Text, CustomConnectionState.CloseOnExit);
            }
            catch (Exception ex)
            {
                adapter.HandleDAOExceptions(ex);
            }
        }
        public void LogThaoTac(string NguoiThaoTac, string NoiDungThucHien, string MoTa, long TargetId)
        {
            BaseRepository adapter = new BaseRepository();
            string command = "";
            try
            {
                adapter.AddParameter(":NGUOI_THAO_TAC", NguoiThaoTac);
                adapter.AddParameter(":NOI_DUNG_THUC_HIEN", NoiDungThucHien);
                adapter.AddParameter(":MO_TA", MoTa);
                adapter.AddParameter(":TARGET_ID", TargetId);
                command = @" INSERT INTO LOG_THAO_TAC (
                                                        NGUOI_THAO_TAC,
                                                        NOI_DUNG_THUC_HIEN,
                                                        MO_TA,
                                                        TARGET_ID
                                                    )
                                            VALUES (:NGUOI_THAO_TAC, :NOI_DUNG_THUC_HIEN, :MO_TA, :TARGET_ID)";
                adapter.ExecuteNonQuery(command, CommandType.Text, CustomConnectionState.CloseOnExit);
            }
            catch (Exception ex)
            {
                adapter.HandleDAOExceptions(ex);
            }
        }
    }
}

