using System;
using System.Collections.Generic;
using System.Text;

namespace a.b.f
{
    public class HelperAttribute : Attribute
    {
        public readonly string Url;

        public string Topic { get; set; }

        public HelperAttribute()
        {
            Console.WriteLine("无参构造");
        }

        public HelperAttribute(string url)
        {
            this.Url = url;
        }

        private string topic;

        public void show()
        {
            Console.WriteLine("HelperAttribute---show()");
        }
    }

}
