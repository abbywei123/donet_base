using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a.b.f
{
    public class ReflectionTest
    {
        public ReflectionTest()
        {
            Console.WriteLine("这里是{0}无参构造函数",this.GetType());
        }

        public ReflectionTest(string name)
        {
            Console.WriteLine("这里是{0}有参构造函数", this.GetType());
        }

        public ReflectionTest(int d)
        {
            Console.WriteLine("这里是{0}有参构造函数", this.GetType());
        }

        #region Method
        public  void Show1()
        {
            Console.WriteLine("这里是{0}的show1", this.GetType());
        }

        public void Show2(int d)
        {
            Console.WriteLine("这里是{0}的show2", this.GetType());
        }

        public   void Show3(string name)
        {
            Console.WriteLine("这里是{0}的show3", this.GetType());
        }

        private void Show4(string name)
        {
            Console.WriteLine("这里是{0}的show4", this.GetType());
        }

        public static void Shhow5(string namme)
        {
            Console.WriteLine("这里是{0}的show5", typeof(ReflectionTest));
        }

        public void Show3()
        {
            Console.WriteLine("这里是{0}的show3_1", this.GetType());
        }

        public  void Show3(string name,int id)
        {
            Console.WriteLine("这里是{0}的show3_2", this.GetType());
        }

        public void Show3(int id)
        {
            Console.WriteLine("这里是{0}的show3_3", typeof(ReflectionTest));
        }
        #endregion    
    }

    #region 含泛型方法的类
    /// <summary>
    /// 泛型方法
    /// </summary>
    //public class GenericMethod
    //{
    //    public void Show<T, W, X>(T t, W w, X x)
    //    {
    //        Console.WriteLine("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
    //    }
    //}
    #endregion

    #region 泛型类 泛型方法
    public class GenericDouble<T>
    {
        public void Show<W, X>(T t, W w, X x)
        {
            Console.WriteLine("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }

    #endregion
}


