using a.b.f;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace _07反射
{
    public class MyFactory
    {
        private static string HelperAttributeConfig = ConfigurationManager.AppSettings["HelperAttributeConfig"];
        private static string DllName = HelperAttributeConfig.Split(',')[1];
        private static string TypeName = HelperAttributeConfig.Split(',')[0];

        public static HelperAttribute CreateHelper()
        {
            //Assembly assembly = Assembly.Load("a.b.f");//dll名称   当前目录加载
            Assembly assembly = Assembly.Load(DllName);
            //获取类型信息
            //Type type = assembly.GetType("a.b.f.HelperAttribute");
            Type type = assembly.GetType(TypeName);
            //创建对象
            object obj = Activator.CreateInstance(type);
            //类型转换
            HelperAttribute helperAttribute = (HelperAttribute)obj;
            return helperAttribute;
        }
    }
}
