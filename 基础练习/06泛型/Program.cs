using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _06泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                for (int i=0; i < 5;i++)
                {
                    Console.WriteLine(GenericCache<int>.GetCache());
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<long>.GetCache());
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<DateTime>.GetCache());
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<string>.GetCache());
                    Thread.Sleep(10);
                    Console.WriteLine(GenericCache<Program>.GetCache());
                    Thread.Sleep(10);
                    

                }
            }
            {
                int[] numbers = { 1, 4, 8, 9, 6, 7, 5 };
                var listt = from num in numbers where num % 2 != 0 orderby num descending select num;
                foreach(int item in listt)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("======================================");

            {
                int[] numm = { 1, 3, 5, 7 };
                var litt = numm.Select(itm => itm * itm);
                foreach (int item in litt)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("======================================");

            {
                People p1 = new People();
                People p2 = new Son();
                Son s1 = new Son();
                // Son s2 = new People();  错的,这个是编译不通过的，违反了继承性。
            }
            {
                List<People> ps1 = new List<People>();
                // List<People> ps2 = new List<Son>();  编译不通过,不是父子关系，没有继承关系
                //一群儿子一定是一群人
              

               

                IEnumerable<People> ps4 = new List<People>();
                IEnumerable<People> ps5= new List<Son>();
                //一群儿子一定是一群人

                ICustomeListOut<People> ps6 = new CusTomeListOut<People>();//这是能编译的
                ICustomeListOut<People> ps7 = new CusTomeListOut<Son>();//这也是能编译的，在泛型中，子类指向父类，我们称为协变
               //老版本的写法                                                    
                List<People> ps3 = new List<Son>().Select(c => (People)c).ToList();

                ICustomeListIn<People> ps8 = new CustomerListIn<People>();
                ps8.show(new People());
                ps8.show(new Son());

                Action<Son> act=new Action<People>((People p)=>{ });
            }


            MyGenericArray<int>intArray = new MyGenericArray<int>(5);
            for(int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c * 5);
            }
            for (int c = 0; c < 5; c++)
            {
                Console.WriteLine(intArray.getItem(c)+" ");
            }
            Console.WriteLine();

            MyGenericArray<char> charArray = new MyGenericArray<char>(5);
            for (int c = 0; c < 5; c++)
            {
                charArray.setItem(c, (char)(c +97));
            }
            for (int c = 0; c < 5; c++)
            {
                Console.WriteLine(charArray.getItem(c) + " ");
            }
            Console.WriteLine("======================================");
            GenericClass<int> generic = new GenericClass<int>()
            {
                _T=123
            };
            GenericClass<string> generic1 = new GenericClass<string>()
            {
                _T = "123"
            };

            int? num1 = null;
            int? num2 = 45;
            double? num3 = new double?();
            double? num4 = 3.14157;

            bool? boolval = new bool?();

            // 显示值

            Console.WriteLine("显示可空类型的值： {0}, {1}, {2}, {3}",
                               num1, num2, num3, num4);
            Console.WriteLine("一个可空的布尔值： {0}", boolval);

            Console.WriteLine(typeof(List<>));
            Console.WriteLine(typeof(Dictionary<,>));
            Show(23);  //<T> 类型参数可省略，自动推算
            Show<int>(23); //需指定类型参数
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        /// <summary>
        /// 泛型方法  解决用一个方法，满足不同的参数类型：做相同的事
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {

        }
    }
    class GenericClass<T>
    {
        public T _T;
    }

    interface GenericInterface<T>
    {
        T GetT();//泛型类型的返回值
    }

    class CommonClass : GenericClass<int>
    {

    }

    class GenericClassChild<Eleven> : GenericClass<Eleven>
    {

    }

    class People
    {
        public int id;
        public string name;
    }

    class Son:People
    {
        public string age;
    }

    class Constraint
    {
        public static void Show<T>(T tParameter) where T: People
        {
            Console.WriteLine($"{tParameter.id}_{tParameter.name}");
        }
    }

    /// <summary>
    /// 协变  out 只能是返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICustomeListOut<out T>
    {
        T Get();
        //void show(T t);//T 不能作为传入参数
    }

    class CusTomeListOut<T> : ICustomeListOut<T>
    {
        public T Get()
        {
            return default(T);
        }
    }

    /// <summary>
    /// 逆变
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICustomeListIn<in T>
    {
       // T Get();//不能作为返回值

        void show(T t);
    }

    class CustomerListIn<T> : ICustomeListIn<T>
    {
        public T Get(T t)
        {
            return default(T);
        }

        public void show(T t)
        {

        }
    }

    class GenericCache<T>
    {
        private static string _TypeTime = "";

        static GenericCache()
        {
            Console.WriteLine("This is GenericCache 静态构造函数");
           _TypeTime = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.fff"));
        }

        public static string GetCache()
        {
            return _TypeTime;
        }
    }
}
