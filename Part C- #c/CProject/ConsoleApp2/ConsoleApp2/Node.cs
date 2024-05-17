using System;

namespace NewCProject
{
    class Node
    {
        private int Value;
        private Node Next;

        public Node(int value)
        {
            this.Value = value;
            this.Next = null;
        }

        public int GetValue()
        {
            return this.Value;
        }

        public void SetValue(int val)
        {
            this.Value = val;
        }

        public Node GetNext()
        {
            return this.Next;
        }

        public void SetNext(Node node)
        {
            this.Next = node;
        }

    }
}
