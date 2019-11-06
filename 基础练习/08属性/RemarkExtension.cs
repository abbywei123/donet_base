using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _08属性
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UesrState
    {
        //正常
        [RemarkAttribute("正常")]
        Normal=0,
        //冻结
        [RemarkAttribute("冻结")]
        Forzem =1,
        //删除
        [RemarkAttribute("删除")]
        Deleted =2
    }
    public class RemarkAttribute : Attribute
    {
        public RemarkAttribute(string remark)
        {
            this._Remark = remark;
        }

        private string _Remark = null;

        public string GetRemark()
        {
            return this._Remark;
        }
    }

    /// <summary>
    /// 扩展类
    /// </summary>
    public static class RemarkExtension
    {
        public static string GetRemark(this Enum value)
        {
            Type type=value.GetType();
            FieldInfo field=type.GetField(value.ToString());
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.GetRemark();
            }
            else
            {
                return value.ToString();
            }
            
        }
    }
}
