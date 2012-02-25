using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13StackAsArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 13: Implement the ADT stack as auto-resizable array.
            // Resize the capacity on demand (when no space is available
            // to add / insert a new element).

            StackAsArray<int> stack = new StackAsArray<int>();
            Console.WriteLine("stack capacity = {0}, stack length = {1}", stack.Capacity(), stack.Length());
            Console.WriteLine();
            
            Console.WriteLine("Inserting elements to the stack...");
            for (int i = 0; i < 20; i++)
            {
                stack.Push((int)Math.Pow(2, i));
            }
            
            Console.WriteLine();
            Console.WriteLine("stack capacity = {0}, stack length = {1}", stack.Capacity(), stack.Length());

            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }
            
            Console.WriteLine();
            Console.WriteLine("stack capacity = {0}, stack length = {1}", stack.Capacity(), stack.Length());
        }
    }

    class StackAsArray<T>
    {
        private T[] array;
        private int usedCells;

        public StackAsArray()
        {
            array = null;
            usedCells = 0;
        }

        public StackAsArray(int initSize)
        {
            array = new T[initSize];
            usedCells = 0;
        }

        public void Push(T element)
        {
            if (array != null)
            {
                if (array.Length == usedCells)
                {
                    Resize(usedCells);
                    array[usedCells] = element;
                    usedCells++;
                }
                else
                {
                    array[usedCells] = element;
                    usedCells++;
                }
            }
            else
            {
                Resize(0);
                array[usedCells] = element;
                usedCells++;
            }
        }

        public T Pop()
        {
            if (usedCells != 0)
            {
                usedCells--;
                return array[usedCells];
            }
            else
            {
                throw new ArgumentNullException("Stack is empty.");
            }
        }

        public T Peek()
        {
            if (array != null)
                return array[usedCells - 1];
            else
                throw new ArgumentNullException("Stack is empty.");
        }

        public int Length()
        {
            return usedCells;
        }

        public int Capacity()
        {
            if (array != null)
            {
                return array.Length;
            }
            else
            {
                return 0;
            }
        }

        public bool IsEmpty()
        {
            if (usedCells == 0)
                return true;
            else
                return false;
        }

        private void Resize(int currentLength)
        {
            if (currentLength == 0)
            {
                array = new T[4];
            }
            else
            {
                T[] tmpArray = new T[array.Length];
                array.CopyTo(tmpArray, 0);
                array = new T[array.Length * 2];
                tmpArray.CopyTo(array, 0);
            }
        }
    }
}
