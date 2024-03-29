﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a.b.f
{
    public class GenericClass<T,W,X>
    {
        public void show(T t,W w,X x)
        {
            Console.WriteLine("t.type={0},w.type={1},x.type={2}",t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }

    public class GenericMethod
    {
        public void Show<T,W,X>(T t,W w,X x)
        {
            Console.WriteLine("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }
}
