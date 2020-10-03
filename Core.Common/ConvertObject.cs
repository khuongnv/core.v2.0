using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Core.Common
{
    public class ConvertObject
    {
        /// <summary>
        /// Convert DataSet => List Object
        /// </summary>
        public static List<T> DataSetToList<T>(DataSet dataSet)
        {
            var result = new List<T>();
            var dataTable = dataSet.Tables;
            var dt = dataTable[0];
            foreach (DataRow dataRow in dt.Rows)
            {
                var row = Activator.CreateInstance<T>();
                var propertyInfos = typeof(T).GetProperties();
                foreach (var ppi in propertyInfos)
                {
                    var name = ppi.Name.ToUpper();                    
                    if (!dataRow.Table.Columns.Contains(name)) continue;
                    var value = dataRow[name];
                    ppi.SetValue(row, Convert.ChangeType(value, ppi.PropertyType), null);                    
                }
                result.Add((T)row);
            }
            return result;
        }        
    }
}
