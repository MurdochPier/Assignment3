using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3
{
    public class SLL : ILinkedListADT
    {
        private Node head;
        private int size;

        public SLL()
        {
            head = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public void AddLast(User value)
        {
            var newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            size++;
        }

        public void AddFirst(User value)
        {
            var newNode = new Node(value)
            {
                Next = head
            };
            head = newNode;
            size++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            var newNode = new Node(value);
            var current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
            size++;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }

        public int Count()
        {
            return size;
        }

        public void RemoveFirst()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty");

            head = head.Next;
            size--;
        }

        public void RemoveLast()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty");

            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                var current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            size--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            var current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            size--;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int IndexOf(User value)
        {
            var current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1; // Not found
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }
    }
}
