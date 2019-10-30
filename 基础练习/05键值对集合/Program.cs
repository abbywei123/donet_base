using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05键值对集合
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "张三");
            hashtable.Add('2', 11.2);
            hashtable.Add(3, "李四");
            hashtable.Add('4',3.1415);

          foreach(var item in hashtable.Keys)
            {
                Console.WriteLine("键："+item+"->"+"值:"+hashtable[item]);
            }
            Console.ReadKey();
        }
    }
}
