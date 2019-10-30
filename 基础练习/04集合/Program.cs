using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04集合
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = new int[] { 1,2,3,4,5,6,7,8,9};
            ArrayList list = new ArrayList();
            //list.Add(1);
            //list.Add("hello");
            //list.Insert(1,2);
            //// list.Add(numbers);
            //list.AddRange(numbers);
            Random rm = new Random();
            for(int i=0;i<10; i++)
            {
                int rNumber = rm.Next(0, 10);
                if (!list.Contains(rNumber))
                {
                    list.Add(rNumber);
                }
                else
                {
                    i--;
                }
            }
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
               
            }
            Console.ReadKey();
        }
    }
}
