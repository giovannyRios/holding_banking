using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationBanking.Application.Commons.Utilities
{
    public class Enumeraciones
    {
        public enum CodigosHttp
        {
            [EnumValue("200")]
            Ok = 1,
            [EnumValue("400")]
            BadRequest = 2,
            [EnumValue("500")]
            InternalServerError = 3,
            [EnumValue("404")]
            NotFound = 4
        }

        [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
        public class EnumValue : System.Attribute
        {

            private readonly string[] _value;
            public EnumValue(params string[] value)
            {
                _value = value;
            }
            public string[] Value
            {
                get { return _value; }
            }
        }

        public static EnumValue GetEnumValueAttribute<T>(T value)
        {
            var fieldInfo = typeof(T).GetField(value.ToString());
            var attribute = fieldInfo?.GetCustomAttributes(typeof(EnumValue), false) as EnumValue[];

            return attribute?.FirstOrDefault();
        }
    }
}
