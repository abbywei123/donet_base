using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础练习
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("请输入你喜欢的课程：");
            //string lessonOne = Console.ReadLine();
            //Console.WriteLine("请输入你喜欢的课程：");
            //string lessonTwo = Console.ReadLine();
            //if(lessonOne.Equals(lessonTwo,StringComparison.OrdinalIgnoreCase))//第二个参数表示忽略大小写
            //{
            //    Console.WriteLine("你俩喜欢的课程一样");
            //}
            //else
            //{
            //    Console.WriteLine("你俩喜欢的课程不一样");
            //}
            //Console.ReadKey();

            #region 字符串的分割
            //string str = " ab,c,d,e,f,h, df,df,d,   ";
            //str.Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(str);
            //Console.ReadKey();
            #endregion

            //Console.WriteLine("请输入一个日期 格式如下：2008-01-02");
            //string str = Console.ReadLine();
            //string[] newStr = str.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(newStr[0]+"年"+ newStr[1]+ "月" + newStr[2]+"日" );
            //Console.ReadKey();

            string str = "今天天气好晴朗，处处好风光";
            str = str.Substring(5,3);
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
