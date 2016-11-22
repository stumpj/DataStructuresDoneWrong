using System;

namespace DataStructuresDoneWrong.LL
{
    public class AnnLL<T> : BadLinkedList<T> where T : IEquatable<T>, ICloneable
    {
        private Node Head = null;
        private Node Tail = null;
        private int LLSize = 0;

        private class Node
        {
            private Node previousNode;
            private Node nextNode;
            private T nodeValue;

            public Node PreviousNode
            {
                get { return previousNode; }
                set { previousNode = value; }
            }
            public Node NextNode
            {
                get { return nextNode; }
                set { nextNode = value; }
            }
            public T NodeValue
            {
                get { return nodeValue; }
                set { nodeValue = value; }
            }

            public Node(T value, Node prev, Node next)
            {
                NodeValue = value;
                PreviousNode = prev;
                NextNode = next;
            }
        }

        public bool IsEmpty
        {
            get { return LLSize == 0; }
        }

        public int Size
        {
            get { return (LLSize); }
        }

        public void Add(T value)
        {
            Node tempNode = Tail;
            Tail = new Node(value, tempNode, null);

            if (LLSize == 0)
            {
                Head = Tail;
            }
            else
            {
                tempNode.NextNode = Tail;
            }
            LLSize++;
        }

        public bool Add(int index, T value)
        {
            if (index < 0 || index > LLSize)
                return false;
            if (index == 0)
                AddFirst(value);
            else if (index == LLSize)
                Add(value);
            else
            {
                //todo: if index >= LLSize/2, start from tail, else start from head
                Node tempNode = Head;

                for (int i = 0; i < index; i++)
                {
                    tempNode = tempNode.NextNode;
                }
                tempNode.PreviousNode.NextNode = new Node(value, tempNode.PreviousNode, tempNode);
                tempNode.PreviousNode = tempNode.PreviousNode.NextNode;
                LLSize++;
            }

            return true;
        }

        public void AddFirst(T value)
        {
            Node tempNode = Head;
            Head = new Node(value, null, tempNode);

            if (LLSize == 0)
            {
                Tail = Head;
            }
            else
            {
                tempNode.PreviousNode = Head;
            }
            LLSize++;
        }

        public void Clear()
        {
            //Some C# black magic:
            Head = null;
            Tail = null;
            LLSize = 0;
        }

        public object Clone()
        {
            AnnLL<T> Dolly = new AnnLL<T>();

            for (int i = 0; i < this.LLSize; i++)
            {
                Dolly.Add((T)this.Get(i).Clone());
            }

            Dolly.LLSize = this.LLSize;
            return Dolly;
        }

        public bool Contains(T value)
        {
            if (this.IsEmpty)
                return false;

            Node tempNode = Head;
            while (tempNode != null)
            {
                if (tempNode.NodeValue.Equals(value))
                {
                    return true;
                }
                tempNode = tempNode.NextNode;
            }
            return false;
        }

        public T Get(int index)
        {
            int i;
            if (!ValidExistingIndex(index))
            {
                throw (new Exception("Invalid index"));
            }

            Node tempNode = Head;
            for (i = 0; i < index; i++)
            {
                tempNode = tempNode.NextNode;
            }

            return tempNode.NodeValue;
        }

        public T GetFirst()
        {
            if (this.IsEmpty)
            {
                throw (new Exception("LL is Empty"));
            }
            return Head.NodeValue;
        }

        public T GetLast()
        {
            if (this.IsEmpty)
            {
                throw (new Exception("LL is Empty"));
            }
            return Tail.NodeValue;
        }

        public int IndexOf(T value)
        {
            if (this.IsEmpty)
                return -1;
            bool found = false;
            int index = -1;
            Node tempNode = Head;

            while (!found && tempNode != null)
            {
                if (tempNode.NodeValue.Equals(value))
                {
                    found = true;
                }
                index++;
                tempNode = tempNode.NextNode;
            }

            if (!found)
                index = -1;
            return index;
        }

        public int LastIndexOf(T value)
        {
            bool found = false;
            int index = LLSize;
            Node tempNode = Tail;

            while (!found && tempNode != null)
            {

                if (tempNode.NodeValue.Equals(value))
                {
                    found = true;
                }
                index--;

                tempNode = tempNode.PreviousNode;
            }
            if (!found)
                return -1;
            return index;
        }

        public bool Remove(T value)
        {
            int index = IndexOf(value);
            if (index != -1)
            {
                Remove(index);
                return true;
            }
            else return false;
        }

        public T Remove(int index)
        {
            if (!ValidExistingIndex(index))
            {
                throw (new Exception("Invalid index "));
            }

            T tempValue;
            if (index == 0)
                tempValue = RemoveFirst();
            else if (index == LLSize - 1)
                tempValue = RemoveLast();
            else
            {
                Node tempNode = Head;
                for (int i = 0; i < index; i++)
                {
                    tempNode = tempNode.NextNode;
                }
                tempValue = tempNode.NodeValue;

                tempNode.PreviousNode.NextNode = tempNode.NextNode;
                tempNode.NextNode.PreviousNode = tempNode.PreviousNode; 

                LLSize--;
            }

            return tempValue;
        }

        public T RemoveFirst()
        {
            if (this.IsEmpty)
            {
                throw (new Exception("Linked List is Empty sad"));
            }
            T tempVal = Head.NodeValue;
            if (LLSize == 1)
            {
                this.Clear();
            }
            else
            {
                Head = Head.NextNode;
                Head.PreviousNode = null;

                if (LLSize == 2)
                {
                    Tail = Head;
                }
                LLSize--;
            }
            return tempVal;
        }

        public T RemoveLast()
        {
            if (this.IsEmpty)
            {
                throw (new Exception("Linked List is Empty sad"));
            }
            T tempVal = Tail.NodeValue;
            if (LLSize == 1)
            {
                this.Clear();
            }

            else
            {
                Tail.PreviousNode.NextNode = null;
                Tail = Tail.PreviousNode;
                if (LLSize == 2)
                {
                    Head = Tail;
                }
                LLSize--;
            }

            return tempVal;
        }

        public T Set(int index, T value)
        {
            if (!ValidExistingIndex(index))
            {
                throw (new Exception("Invalid index "));
            }
            Node tempNode = Head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.NextNode;
            }
            tempNode.NodeValue = value;

            return tempNode.NodeValue;
        }

        public T[] ToArray()
        {

            T[] tempArray = new T[LLSize];
            Node tempNode = Head;
            for (int i = 0; i < LLSize; i++)
            {
                tempArray[i] = (T)tempNode.NodeValue.Clone();
                tempNode = tempNode.NextNode;
            }

            return tempArray;
        }

        private bool ValidExistingIndex(int index)
        {
            return (index >= 0 && index <= LLSize - 1);

        }
    }
}
