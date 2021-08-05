using System;
using System.Text;

namespace LinkedList.Implementation
{
    public class Node<T>
    {
        public T Value { get; }
        public Node<T>? Previous { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        internal void AddToEnd(T value)
        {
            if (Next == null)
            {
                var newNode = new Node<T>(value)
                {
                    Previous = this
                };

                Next = newNode;

                return;
            }

            Next.AddToEnd(value);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(" [ ");

            if (Previous != null)
            {
                stringBuilder.Append(Previous.Value);
            }

            stringBuilder.Append("<--");
            stringBuilder.Append($" {Value} ");
            stringBuilder.Append($"-->");

            if (Next != null)
            {
                stringBuilder.Append(Next.Value);
            }

            stringBuilder.Append(" ] ");

            return stringBuilder.ToString();
        }

        public void Reverse()
        {
            var oldPrevious = Previous;
            var oldNext = Next;

            Previous = oldNext;
            Next = oldPrevious;
        }
    }
}