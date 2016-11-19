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
            get { return (Head == null); }
        }

        public int Size
        {
            get { return (LLSize); }
        }

        public void Add(T value)
        {
            Node tempNode = Tail;
            Tail = new Node(value, tempNode, null);
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
            }

            LLSize++;
            return true;
        }

        public void AddFirst(T value)
        {
            Node tempNode = Head;
            Head = new Node(value, null, tempNode.NextNode);
            tempNode.NextNode.PreviousNode = Head;
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
            bool found = false;
            Node tempNode = Head;
            while (!found && tempNode != null) 
            {
                if (tempNode.NodeValue.Equals(value))
                {
                    found = true;
                }

                tempNode = tempNode.NextNode;
            }
            return found;
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
            return Head.NodeValue;
        }

        public T GetLast()
        {
            return Tail.NodeValue;
        }

        public int IndexOf(T value)
        {
            if (this.IsEmpty)
                return -1;
            bool found = false;
            int index = -1;
            Node tempNode = Head;

            while (!found && tempNode.NextNode != null) 
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
            if (index != -1) //just in case I am dumb 
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
            }
            LLSize--;
            return tempValue;
        }

        public T RemoveFirst()
        {
            if (this.IsEmpty)
            {
                throw (new Exception("Linked List is Empty sad"));
            }
            T tempVal = Head.NodeValue;
            Head = Head.NextNode;
            Head.PreviousNode = null;
            LLSize--; 
            return tempVal;
        }

        public T RemoveLast()
        {
            if (this.IsEmpty)
            {
                throw (new Exception("Linked List is Empty sad"));
            }

            T tempVal = Tail.NodeValue;
            Tail.PreviousNode.NextNode = null;
            Tail = Tail.PreviousNode;
            LLSize--;
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
            //todo: figure out how to declare an array in C#, too lazy right now
            T tempArray[LLSize]; //NO IDEA HOW TO DECLARE ARRAY in c#
             
        }

        private bool ValidExistingIndex(int index)
        {
            if (index < 0 || index > LLSize - 1)
                return false;
            else
                return true;

           
        }
    }
}

