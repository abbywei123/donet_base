using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 单例模式
/// </summary>
namespace a.b.f
{
    public class Singleton
    {
        private static Singleton _Singleton = null;

        private Singleton()
        {
            Console.WriteLine("Singleton被构造");
        }

        static Singleton()
        {
            _Singleton = new Singleton();
        }

        public static Singleton GetInstance()
        {
            return _Singleton;
        }
    }
}
