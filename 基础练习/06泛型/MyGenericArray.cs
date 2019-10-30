using System;
using System.Collections.Generic;
using System.Text;

namespace _06泛型
{
    public class MyGenericArray<T>
    {
        private T[] array;

        public MyGenericArray(int size)
        {
            array = new T[size + 1];
        }

        public T getItem(int index)
        {
            return array[index];
        }

        public void setItem(int index,T value)
        {
            array[index] = value;
        }

    }
}
