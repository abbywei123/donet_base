﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a.b.f
{
    public class People
    {
        public People()
        {
            Console.WriteLine("{0}被创建", this.GetType().FullName);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

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
