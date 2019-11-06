using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08属性
{
    /// <summary>
    /// 特性就是一个类，直接/间接继承Attribute
    /// 一般来说  Attribute结尾可以省略掉
    /// </summary>
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true)]  //允许重复修饰
    public class CustomAttribute:Attribute
    {
        public CustomAttribute()
        {

        }

        public CustomAttribute(int id)
        {

        }

        public string Description { get; set; }

        public string Remark = null;

        public void Show()
        {
            Console.WriteLine($"this is {nameof(CustomAttribute)}");
        }
    }
}
