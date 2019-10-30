using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02里氏转换
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rm = new Random();
            Persion[] pers = new Persion[10];
            for(int i=0;i<pers.Length;i++)
            {
                int rNumber = rm.Next(1, 7);
                switch(rNumber)
                {
                    case 1:pers[i] = new Student();
                        break;
                    case 2:
                        pers[i] = new Teacher();
                        break;
                    case 3:
                        pers[i] = new Meinv();
                        break;
                    case 4:
                        pers[i] = new ShuaiGuo();
                        break;
                    case 5:
                        pers[i] = new YeShou();
                        break;
                    case 6:
                        pers[i] = new Persion();
                        break;
                }
            }

            for (int i = 0; i < pers.Length; i++)
            {
                ZhuanHuan(pers[i]);
            }
            Console.ReadKey();
        }
        public static void ZhuanHuan(Persion per)
        {
            if(per is Student)
            {
                ((Student)per).StudentSay();
            }
            else if (per is Teacher)
            {
                ((Teacher)per).TeacherSay();
            }
            else if (per is Meinv)
            {
                ((Meinv)per).MeinvSay();
            }
            else if (per is ShuaiGuo)
            {
                ((ShuaiGuo)per).ShuaiGuoSay();
            }
            else if (per is YeShou)
            {
                ((YeShou)per).YeShouSay();
            }
            else
            {
                per.PersonSay();
            }
        }
    }
}
public class Persion
{
    public void PersonSay()
    {
        Console.WriteLine("我是父类");
    }
}

public class Student:Persion
{
    public void StudentSay()
    {
        Console.WriteLine("我是学生");
    }
}

public class Teacher : Persion
{
    public void TeacherSay()
    {
        Console.WriteLine("我是老师");
    }
}

public class Meinv : Persion
{
    public void MeinvSay()
    {
        Console.WriteLine("我是美女");
    }
}

public class ShuaiGuo : Persion
{
    public void ShuaiGuoSay()
    {
        Console.WriteLine("我是帅锅");
    }
}

public class YeShou : Persion
{
    public void YeShouSay()
    {
        Console.WriteLine("我是野兽");
    }
}
