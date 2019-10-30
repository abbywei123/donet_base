
using a.b.d;
using System;
using System.Reflection;

namespace _07反射
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Assembly assembly = Assembly.Load("a.b.c");//dll名称   当前目录加载
                //Assembly assembly1 = Assembly.LoadFile("C:\\Users\\j\\source\\repos\\基础练习\\07反射\\bin\\Debug\\netcoreapp2.1\\07反射.dll");//文件完整路劲的加载
                // Assembly assembly2 = Assembly.LoadFrom("07反射.dll");//带后缀或者完整路劲
                //获取类型信息
                Type type = assembly.GetType("a.b.c.HelperAttribute");
                //创建对象
                object obj = Activator.CreateInstance(type);
                //类型转换
                HelperAttribute helperAttribute = (HelperAttribute)obj;
                //调用方法
                helperAttribute.show();


            }
            Console.WriteLine("======================");

            Console.ReadKey();
        }
    }
}
