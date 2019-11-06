using _08属性;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08特性
{
    /// <summary>
    /// 特性attribute,和注释
    /// 特性：[]中括号声明
    /// 每一个特性
    /// </summary>
    
        
    [CustomAttribute]
    class Program
    {
        static void Main(string[] args)
        {
            {
                UesrState uesrState = UesrState.Normal;
                //if(uesrState==UesrState.Normal)
                //{
                //    Console.WriteLine("正常状态");
                //}
                Console.WriteLine(uesrState.GetRemark());
                Console.WriteLine(UesrState.Forzem.GetRemark());
                Console.WriteLine(UesrState.Deleted.GetRemark());
            }
            {
                People p = new People()
                {
                    Id=123,
                    Name="haha",
                    QQ=123456
                };

                p.Validate();


            }
            
        }
    }
}
