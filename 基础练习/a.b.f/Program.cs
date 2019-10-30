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
                    Console.WriteLine("================泛型方法method======================");
                    {
                        //反射
                        Type typeGenericDouble = a.GetType("a.b.f.GenericDouble`1"); //GenericDouble<T>
                        Type newType = typeGenericDouble.MakeGenericType(new Type[] { typeof(int) });
                        object genericDouble = Activator.CreateInstance(newType);
                        MethodInfo method = newType.GetMethod("Show");                   
                        MethodInfo newMethod = method.MakeGenericMethod(new Type[] {typeof(string), typeof(DateTime) });
                        newMethod.Invoke(genericDouble, new object[] { 123, "诗人", DateTime.Now });
                    }
                    Console.WriteLine("================类及属性=====================");
                    {
                        People p = new People
                        {
                            Id=1,
                            Name="花花",
                            Description="三好学生"
                        };
                        Console.WriteLine($"people.Id={p.Id}");
                        Console.WriteLine($"people.Name={p.Name}");
                        Console.WriteLine($"people.Description={p.Description}");

                        Type tPeople = typeof(People);
                        object oPeople = Activator.CreateInstance(tPeople);
                        Console.WriteLine("++++++++++GetProperties++++++++++++");
                        foreach (var prop in tPeople.GetProperties())
                        {
                            Console.WriteLine(tPeople.Name);
                            Console.WriteLine(prop.Name);
                            Console.WriteLine(prop.GetValue(oPeople));

                            if (prop.Name.Equals("Id"))
                            {
                                prop.SetValue(oPeople, 2);
                            }else if(prop.Name.Equals("Name"))
                            {
                                prop.SetValue(oPeople, "xiaoxiao");
                            }
                            Console.WriteLine($"{tPeople.Name}.{prop.Name}={prop.GetValue(oPeople)}");
                        }

                        Console.WriteLine("++++++++++GetFields++++++++++++");
                        foreach (var field in tPeople.GetFields())
                        {
                            Console.WriteLine(tPeople.Name);
                            Console.WriteLine(field.Name);
                            Console.WriteLine(field.GetValue(oPeople));

                            if (field.Name.Equals("Id"))
                            {
                                field.SetValue(oPeople, 2);
                            }
                            else if (field.Name.Equals("Name"))
                            {
                                field.SetValue(oPeople, "xiaoxiao");
                            }
                            Console.WriteLine($"{tPeople.Name}.{field.Name}={field.GetValue(oPeople)}");
                        }
                    }
                    Console.WriteLine("================应用实例====================");
                    {
                        People p = new People()
                        {
                            Id = 1,
                            Name = "花花",
                            Description = "三好学生"
                        };
                        {
                            PeopleDTO peopleDTO = new PeopleDTO()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Description = p.Description
                            };//硬编码
                        }
                        //利用反射赋值   将对象People的属性值赋值给PeopleDTO
                        {
                            Type typePeople = typeof(People);
                            Type typePeopleDTO = typeof(PeopleDTO);
                            object peopleDTO = Activator.CreateInstance(typePeopleDTO);
                            foreach (var prop in typePeopleDTO.GetProperties())
                            {
                                //if (prop.Name.Equals("Id"))
                                //{
                                //    //object value=typePeople.GetProperty("Id").GetValue(p);
                                //    object value = typePeople.GetProperty(prop.Name).GetValue(p);
                                //    prop.SetValue(peopleDTO, value);
                                //}
                                //else if (prop.Name.Equals("Name"))
                                //{
                                //    object value = typePeople.GetProperty(prop.Name).GetValue(p);
                                //    prop.SetValue(peopleDTO, value);
                                //}
                                object value = typePeople.GetProperty(prop.Name).GetValue(p);
                                prop.SetValue(peopleDTO, value);
                            }
                        }
                      
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
