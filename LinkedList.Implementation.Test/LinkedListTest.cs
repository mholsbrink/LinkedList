using FluentAssertions;
using Xunit;
using LinkedList.Implementation;
using System.Diagnostics;

namespace LinkedList.Implementation.Test
{
    public class LinkedListImplementationTest
    {
        [Fact]
        public void AddNode_AddsNode()
        {
            var linkedList = new LinkedListImplementation<int>();

            linkedList.Add(1);
            linkedList.Should().Equal(1);
        }

        [Fact]
        public void AddNode_AddsNode_AtEnd()
        {
            var linkedList = new LinkedListImplementation<int>();            

            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Should().Equal(1, 2);
        }

        [Fact]
        public void AddNode_CanAdd_MultipleNodes()
        {
            var linkedList = new LinkedListImplementation<int>();

            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            linkedList.Should().Equal(1, 2, 3, 4, 5);
        }

        [Fact]
        public void Reverse_Reverses_LinkedList()
        {
            var linkedList = new LinkedListImplementation<int>();

            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            linkedList.Reverse();
            linkedList.Should().Equal(5, 4, 3, 2, 1);
        }

        [Fact]
        public void ReverseNode_ReversesNode()
        {
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);

            node2.Previous = node1;
            node2.Next = node3;

            node2.Reverse();
            node2.Previous.Should().BeSameAs(node3);
            node2.Next.Should().BeSameAs(node1);
        }
    }
}