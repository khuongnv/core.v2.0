using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository;
using Core.Models;
using Core.Models.Input;
using Core.Models.Output;
namespace Core.Business
{
    public class LogBusiness: BaseBusiness
    {
        private readonly LogRepository repository;
        public LogBusiness()
        {
            repository = new LogRepository();
        }
        public ResultModel<List<LogUserModel>> LogUserDangNhap()
        {
            return repository.LogUserDangNhap();
        }
        public ResultModel<List<LogThaoTacModel>> LogUserThaoTac()
        {
            return repository.LogUserThaoTac();
        }
        public void LogDangNhap(string TenDangNhap, string sessionId, long LogInOut, string ipMayChu, string ipMayTram, string trinhDuyet, long thanhCong)
        {
            repository.LogDangNhap(TenDangNhap, sessionId, LogInOut, ipMayChu, ipMayTram, trinhDuyet, thanhCong);
        }
        public void LogThaoTac(string NguoiThaoTac, string NoiDungThucHien, string MoTa, long TargetId)
        {
            repository.LogThaoTac(NguoiThaoTac, NoiDungThucHien, MoTa, TargetId);
        }
    }
}
