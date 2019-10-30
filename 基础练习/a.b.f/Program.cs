using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace a.b.f
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    // Singleton s = new Singleton();   //因为是私有的构造函数 不能被调用
                    Singleton s1 = Singleton.GetInstance(); //静态类只能被初始化一次
                    Singleton s3 = Singleton.GetInstance();
                    Singleton s4 = Singleton.GetInstance();

                    //反射
                    Assembly a = Assembly.Load("a.b.f");
                    Type type = a.GetType("a.b.f.Singleton");
                    Singleton s2 = (Singleton)Activator.CreateInstance(type, true);  //相当于Singleton s2 = new Singleton(); 
                    Singleton s5 = (Singleton)Activator.CreateInstance(type, true);  //相当于Singleton s5 = new Singleton(); 
                    Singleton s6 = (Singleton)Activator.CreateInstance(type, true);  //相当于Singleton s6 = new Singleton(); 

                }
                Console.WriteLine("======================================");
                {
                    //反射
                    Assembly a = Assembly.Load("a.b.f");
                    Type type = a.GetType("a.b.f.ReflectionTest");
                    ReflectionTest r1 = (ReflectionTest)Activator.CreateInstance(type);
                    ReflectionTest r2 = (ReflectionTest)Activator.CreateInstance(type, new object[] { 123 });
                    ReflectionTest r3 = (ReflectionTest)Activator.CreateInstance(type, new object[] { "123" });
                }
                Console.WriteLine("======================================");
                {
                    //反射
                    Assembly a = Assembly.Load("a.b.f");
                    Type type = a.GetType("a.b.f.GenericClass`3"); //class GenericClass<T,W,X>
                    //object o1 = Activator.CreateInstance(type);
                    //MakeGenericType() 替代由当前泛型类型定义的类型参数组成的类型数组的元素，并返回表示结果构造类型的Type对象
                    Type newType = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                    object o1 = Activator.CreateInstance(newType);
                }
                Console.WriteLine("================method======================");
                {
                    //反射
                    Assembly a = Assembly.Load("a.b.f");
                    Type type = a.GetType("a.b.f.ReflectionTest");
                    ReflectionTest r1 = (ReflectionTest)Activator.CreateInstance(type);
                    foreach(var item in type.GetMethods())
                    {
                        Console.WriteLine(item.Name);
                    }
                    {
                        MethodInfo method=type.GetMethod("Show1");
                        method.Invoke(r1, null);
                    }
                    {
                        MethodInfo method = type.GetMethod("Show2");
                        method.Invoke(r1, new object[] {123 });
                    }
                    {
                        //重载
                        MethodInfo method = type.GetMethod("Show3",new Type[] { typeof(int)});
                        method.Invoke(r1, new object[] { 123 });
                    }
                    {
                        //重载
                        MethodInfo method = type.GetMethod("Show3", new Type[] { typeof(string) });
                        method.Invoke(r1, new object[] { "果然" });
                    }
                    {
                        //重载
                        MethodInfo method = type.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });
                        method.Invoke(r1, new object[] { "果然",123 });
                    }
                    {
                        MethodInfo method = type.GetMethod("Show4", BindingFlags.Instance|BindingFlags.NonPublic);
                        method.Invoke(r1, new object[] { "果然"});
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
