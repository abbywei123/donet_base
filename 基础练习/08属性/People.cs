using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08属性
{
    [CustomAttribute]   //也可以[Custom]  <=>等价于[Custom()]  无参构造方式
    [Custom()]   
    [Custom(123)] // 有参构造方式
    [Custom(123),Custom(123,Description ="1234")] //多重
    [Custom(123,Description ="1234",Remark ="123")] //可以构造函数，指定字段参数等，方法不行
    public class People
    {
        public People()
        {
            Console.WriteLine("{0}被创建", this.GetType().FullName);
        }

        public int Id { get; set; }

        [Leng(5,10)]
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// 范围 10001~999999999999
        /// </summary>
        [LongAttribute(10001,999999999999)]
        public long QQ { get; set; }

        public void Study()
        {
            Console.WriteLine($"this is syudy");
        }

        [Custom()]  //表示给方法加特性
        [return:Custom()] //表示给返回值加特性
        public string Answer([Custom]string name)    //表示给参数加特性
        {
            return $"This is {name}";
        }
    }
    public class PeopleDTO
    {
        public PeopleDTO()
        {
            Console.WriteLine("{0}被创建", this.GetType().FullName);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
