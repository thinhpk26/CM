using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class UtilityFunction
    {
        public static object ConvertValueSql(object value)
        {
            object result = value;
            if(value != null)
            {
                switch (value)
                {

                }
                if(result is decimal)
                {

                }
            }

            return value;
        }

        public static void ConvertToDatetime<T>(T objectInput)
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (property.PropertyType == typeof(String))
                {
                    // Lấy giá trị của thuộc tính hiện tại
                    string value = property.GetValue(objectInput)?.ToString();

                    // Nếu giá trị không null và có dạng chuỗi datetime, chuyển đổi và gán lại cho thuộc tính
                    if (!string.IsNullOrEmpty(value) && DateTimeOffset.TryParse(value, out DateTimeOffset dateTimeValue))
                    {
                        property.SetValue(objectInput, dateTimeValue);
                    }
                }
            }
        }
    }
}
