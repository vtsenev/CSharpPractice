using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task12LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 12: Implement the data structure linked list. Define a class ListItem<T>
            // that has two fields: value (of type T) and nextItem (of type ListItem<T>).
            // Define additionally a class LinkedList<T> with a single field firstElement (of type ListItem<T>).

            ListItem<int> item4 = new ListItem<int>(20);
            ListItem<int> item3 = new ListItem<int>(15, item4);
            ListItem<int> item2 = new ListItem<int>(10, item3);
            ListItem<int> item1 = new ListItem<int>(5, item2);

            LinkedList<int> list = new LinkedList<int>();
            list.FirstElement = item1;

            ListItem<int> tmpItem = list.FirstElement;
            while (tmpItem != null)
            {
                Console.WriteLine(tmpItem.Value);
                tmpItem = tmpItem.NextItem;
            }
        }
    }

    class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

        public ListItem(T value)
        {
            this.value = value;
            nextItem = null;
        }

        public ListItem(T value, ListItem<T> nextItem)
        {
            this.value = value;
            this.nextItem = nextItem;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ListItem<T> NextItem
        {
            get { return this.nextItem; }
            set { this.nextItem = value; }
        }
    }

    class LinkedList<T>
    {
        private ListItem<T> firstElement;

        public LinkedList()
        {
            firstElement = null;
        }

        public ListItem<T> FirstElement
        {
            get { return this.firstElement; }
            set { this.firstElement = value; }
        }
    }
}
