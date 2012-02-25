using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task14QueueAsLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 14: Implement the ADT queue as dynamic linked list.
            // Use generics (LinkedQueue<T>) to allow storing different
            // data types in the queue.

            LinkedQueue<int> linqueue = new LinkedQueue<int>();

            for (int i = 0; i < 20; i++)
            {
                linqueue.Enqueue(i);
            }

            while (!linqueue.IsEmpty())
            {
                Console.WriteLine(linqueue.Dequeue());
            }
        }
    }

    class LinkedQueue<T>
    {
        private LinkedList<T> list;

        public LinkedQueue()
        {
            list = new LinkedList<T>();
        }

        public void Enqueue(T element)
        {
            list.AddLast(element);
        }

        public T Dequeue()
        {
            if (list.Count != 0)
            {
                T element = list.First.Value;
                list.RemoveFirst();
                return element;
            }
            else
            {
                throw new ArgumentNullException("Linked queue is empty.");
            }
        }

        public bool IsEmpty()
        {
            if (list.Count == 0)
                return true;
            else
                return false;
        }
    }
}
