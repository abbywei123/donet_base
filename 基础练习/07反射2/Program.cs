using _07反射;
using a.b.f;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _07反射2
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Assembly a1 = typeof(Example).Assembly;
                Console.WriteLine("Assembly Full Name:");
                Console.WriteLine(a1.FullName);
                AssemblyName assemName = a1.GetName();
                Console.WriteLine("\nName: {0}", assemName.Name);
                Console.WriteLine("Version: {0}.{1}",assemName.Version.Major, assemName.Version.Minor);

                Console.WriteLine("\nAssembly CodeBase:");
                Console.WriteLine(a1.CodeBase);

            }
            Console.WriteLine("======================");
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                Console.WriteLine(assemblyName);
            }
            { 
                Assembly assembly = Assembly.Load("a.b.f");//dll名称   当前目录加载
                //Assembly assembly1 = Assembly.LoadFile("C:\\Users\\j\\source\\repos\\基础练习\\07反射\\bin\\Debug\\netcoreapp2.1\\07反射.dll");//文件完整路劲的加载
                // Assembly assembly2 = Assembly.LoadFrom("07反射.dll");//带后缀或者完整路劲
                //获取类型信息
                Type type = assembly.GetType("a.b.f.HelperAttribute");
                //Type type1 = assembly.GetType("a.b.f.HelperAttribute");
                //创建对象
                    object obj = Activator.CreateInstance(type);
                //类型转换
                HelperAttribute helperAttribute = (HelperAttribute)obj;
                //调用方法
                helperAttribute.show();

                HelperAttribute helperAttribute2 = new HelperAttribute();
                helperAttribute2.show();

                HelperAttribute helperAttribute3 = MyFactory.CreateHelper();

            }
            Console.WriteLine("======================");

            Console.ReadKey();
        }

        public class Example
        {
            private int factor;
            public Example(int f)
            {
                factor = f;
            }

            public int SampleMethod(int x)
            {
                Console.WriteLine("\nExample.SampleMethod({0}) executes.", x);
                return x * factor;
            }
        }
    }
}
