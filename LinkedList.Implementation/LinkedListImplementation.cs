using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList.Implementation
{
    public class LinkedListImplementation<T> : IEnumerable<T>
    {
        private Node<T>? head = null;

        public void Add(T value)
        {            
            if (head == null)
            {
                head = new Node<T>(value);

                return;
            }

            head.AddToEnd(value);
        }

        public void Reverse()
        {
            var current = head;

            while (current != null)
            {
                var staleNext = current.Next;

                current.Reverse();

                if (staleNext == null)
                {
                    head = current;
                }

                current = staleNext;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (head == null)
            {
                return (IEnumerator<T>) Array.Empty<T>().GetEnumerator();
            }

            return new LinkedListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class LinkedListEnumerator<T> : IEnumerator<T>
        {
            private readonly LinkedListImplementation<T> linkedList;
            private Node<T>? currentNode;

            public LinkedListEnumerator(LinkedListImplementation<T> linkedList)
            {
                this.linkedList = linkedList;
            }

            public T Current => currentNode.Value;

            object IEnumerator.Current => currentNode;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (currentNode == null)
                {
                    if (linkedList.head != null)
                    {
                        currentNode = linkedList.head;

                        return true;
                    }

                    return false;
                }

                if (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;

                    return true;
                }

                return false;

            }

            public void Reset()
            {
                while (currentNode.Previous != null)
                {
                    currentNode = currentNode.Previous;
                }
            }
        }
    }
}