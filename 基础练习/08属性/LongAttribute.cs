using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _08属性
{
    public class LongAttribute:Attribute
    {
        private long _Min = 0;
        private long _Max = 0;


        public LongAttribute(long min,long max)
        {
            this._Max = max;
            this._Min = min;
        }

        public bool Validate(object value)
        {
            if(value!=null&&!string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (long.TryParse(value.ToString(),out long IResult)) //将value转换为long
                {
                    if (IResult>this._Min&& IResult<this._Max)
                    {
                        return true;
                    }
                }
              
            }
            return false;

        }
    }


    public class LengAttribute : Attribute
    {
        private int _Min = 0;
        private int _Max = 0;


        public LengAttribute(int min, int max)
        {
            this._Max = max;
            this._Min = min;
        }

        public bool Validate(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                int length = value.ToString().Length;
                if (length > this._Min && length < this._Max)
                {
                    return true;
                }
            }
            return false;

        }
    }

    /// <summary>
    /// 扩展类
    /// </summary>
    public static class ValidateExtension
    {
        public static bool Validate(this object oObject)
        {
            Type type = oObject.GetType();
            foreach(var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(LongAttribute), true))
                {
                    LongAttribute attribute=(LongAttribute)prop.GetCustomAttribute(typeof(LongAttribute), true);
                    if (!attribute.Validate(prop.GetValue(oObject)))
                    {
                        return false;
                    }
                 
                }

                if (prop.IsDefined(typeof(LengAttribute), true))
                {
                    LengAttribute attribute = (LengAttribute)prop.GetCustomAttribute(typeof(LengAttribute), true);
                    if (!attribute.Validate(prop.GetValue(oObject)))
                    {
                        return false;
                    }

                }


            }
            return true;
        }

    }
}
