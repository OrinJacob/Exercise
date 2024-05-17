using System;
using System.Collections.Generic;

namespace NewCProject
{
    class LinkedList
    {
        private Node Head;
        private Node Tail;
        private Node MaxNode;
        private Node MinNode;

        public void Append(int val)
        {
            Node newNode = new Node(val);
            if (this.Head == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
                this.MaxNode = newNode;
                this.MinNode = newNode;
            }
            else
            {
                this.Tail.SetNext(newNode);
                this.Tail = newNode;
                if (newNode.GetValue() > MaxNode.GetValue())
                {
                    MaxNode = newNode;
                }
                if (newNode.GetValue() < MinNode.GetValue())
                {
                    MinNode = newNode;
                }
            }
        }

        public void Prepend(int val)
        {
            Node newNode = new Node(val);
            if (this.Head == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
                this.MaxNode = newNode;
                this.MinNode = newNode;
            }
            else
            {
                newNode.SetNext(this.Head);
                this.Head = newNode;
                if (newNode.GetValue() > MaxNode.GetValue())
                {
                    MaxNode = newNode;
                }
                if (newNode.GetValue() < MinNode.GetValue())
                {
                    MinNode = newNode;
                }
            }
        }

        public int Pop()
        {
            Node lastNode;

            if (this.Head == null)
            {
                return -1;
            }
            else if (this.Head.GetNext() == null)
            {
                lastNode = this.Head;
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                Node currentNode = this.Head;

                while (currentNode.GetNext().GetNext() != null)
                {
                    currentNode = currentNode.GetNext();
                }

                lastNode = currentNode.GetNext();

                currentNode.SetNext(null);

                this.Tail = currentNode;
            }

            this.MaxNode = updateMaxValue(lastNode);
            this.MinNode = updateMinValue(lastNode);

            return lastNode.GetValue();
        }

        public int Unqueue()
        {
            Node firstNode;

            if (this.Head == null)
            {
                return -1;
            }
            else if (this.Head.GetNext() == null)
            {
                firstNode = this.Head;
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                firstNode = this.Head;

                this.Head = this.Head.GetNext();
            }

            this.MaxNode = updateMaxValue(firstNode);
            this.MinNode = updateMinValue(firstNode);

            return firstNode.GetValue();
        }

        public IEnumerable<int> ToList()
        {
            Node currentNode = this.Head;
            while (currentNode != null)
            {
                yield return currentNode.GetValue();
                currentNode = currentNode.GetNext();
            }
        }

        public bool IsCircular()
        {
            return this.Head.Equals(this.Tail.GetNext());
        }

        public void Sort()
        {
            if (Head == null || Head.GetNext() == null)
                return;

            bool swapped = false;
            Node current;
            Node prev = null;

            bool startSort = true;

            while (startSort || swapped)
            {
                startSort = false;
                swapped = false;
                current = Head;

                while (current != null && current.GetNext() != prev)
                {
                    if (current.GetNext() != null && current.GetValue() > current.GetNext().GetValue())
                    {
                        if (prev != null)
                            prev.SetNext(Swap(current, current.GetNext()));
                        else
                            Head = Swap(current, current.GetNext());
                        swapped = true;
                    }
                    prev = current;
                    current = current.GetNext();
                }

                prev = null;
            }
        }

        private Node Swap(Node firstNode, Node secondNode)
        {
            Node tempNext = secondNode.GetNext();
            secondNode.SetNext(firstNode);
            firstNode.SetNext(tempNext);
            return secondNode;
        }

        public Node GetMaxNode()
        {
            return this.MaxNode;
        }

        public Node GetMinNode()
        {
            return this.MinNode;
        }

        public Node updateMaxValue(Node removedNode)
        {
            if (this.MaxNode.Equals(removedNode))
            {
                this.MaxNode = null;

                Node currentNode = this.Head;
                while (currentNode != null)
                {
                    if (this.MaxNode == null || currentNode.GetValue() > this.MaxNode.GetValue())
                    {
                        this.MaxNode = currentNode;
                    }
                    currentNode = currentNode.GetNext();
                }
            }

            return this.MaxNode;
        }

        public Node updateMinValue(Node removedNode)
        {
            if (this.MinNode.Equals(removedNode))
            {
                Node updatedMinNode = null;

                Node currentNode = this.Head;
                while (currentNode != null)
                {
                    if (updatedMinNode == null || currentNode.GetValue() < this.MinNode.GetValue())
                    {
                        this.MinNode = currentNode;
                    }
                    currentNode = currentNode.GetNext();
                }
            }

            return this.MinNode;
        }
        public void Display()
        {
            Node temp = this.Head;
            while (temp != null)
            {
                Console.Write(temp.GetValue() + " ");
                temp = temp.GetNext();
            }
            Console.WriteLine();
        }
    }
}
