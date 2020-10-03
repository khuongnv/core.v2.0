using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Core.Extension.Models;
using Core.Common;
namespace Core.Extension
{
    public class BaseExtension
    {
        public void HandleDAOExceptions(Exception ex)
        {
            ExceptionHandlers.Handle(ex, ExceptionTypes.BASE_EXTENSION_EXCEPTION);

        }
        public ApiResultOfDataSetModel GetData(UriParameter paraInfo)
        {
            //Gọi API để validate key
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl.MainApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // New code:
                //var response = client.GetAsync("Authentication/ValidateTokenKeySSO?tokenkey=" + HttpUtility.UrlEncode(key)).Result;
                //Nếu sử dụng API để get phân quyền thì truyền thêm tham số
                var response = client.PostAsync("TraCuu/GetData", paraInfo, new JsonMediaTypeFormatter()).Result;
                if (!response.IsSuccessStatusCode) return null;
                var result = response.Content.ReadAsAsync<ApiResultOfDataSetModel>().Result;
                return result;
            }

        }
        public ApiResultOfDataSetModel GetAll(long dataBaseId, string tableName)
        {
            var result = new ApiResultOfDataSetModel();
            try
            {
                var _tableName = new ThamSoThuTuc
                {
                    TEN = "pTableName",
                    GIA_TRI = tableName,
                    KIEU_DU_LIEU = "VARCHAR2"
                };
                var _listThamSoIn = new List<ThamSoThuTuc>();
                _listThamSoIn.Add(_tableName);
                var paraInfo = new UriParameter
                {
                    DatabaseId = dataBaseId,
                    TenThuTuc = "PKG_DANH_MUC.GetAllTable",
                    listThamSoIn = _listThamSoIn
                };
                result = GetData(paraInfo);
            }
            catch (Exception ex)
            {
                HandleDAOExceptions(ex);
            }
            return result;
        }
        public ApiResultOfDataSetModel GetAllById(long dataBaseId, string tableName, string idName, long id)
        {
            var result = new ApiResultOfDataSetModel();
            try
            {
                var _tableName = new ThamSoThuTuc
                {
                    TEN = "pTableName",
                    GIA_TRI = tableName,
                    KIEU_DU_LIEU = "VARCHAR2"
                };
                var _id = new ThamSoThuTuc
                {
                    TEN = idName,
                    GIA_TRI = id.ToString(),
                    KIEU_DU_LIEU = "NUMBER"
                };
                var _listThamSoIn = new List<ThamSoThuTuc>();
                _listThamSoIn.Add(_tableName);
                var paraInfo = new UriParameter
                {
                    DatabaseId = dataBaseId,
                    TenThuTuc = "PKG_DANH_MUC.GetAllTableById",
                    listThamSoIn = _listThamSoIn
                };
                result = GetData(paraInfo);
            }
            catch (Exception ex)
            {
                HandleDAOExceptions(ex);
            }
            return result;
        }
        public ResultModel<List<T>> ConvertToResultModel<T>(ApiResultOfDataSetModel model)
        {
            var result = new ResultModel<List<T>>();
            try
            {
                result.IsError = model.ErrorCode == 0;
                result.Message = model.Message;
                result.Data = ConvertObject.DataSetToList<T>(model.Data);
            }
            catch (Exception ex)
            {
                HandleDAOExceptions(ex);
            }
            return result;
        }
    }
}
