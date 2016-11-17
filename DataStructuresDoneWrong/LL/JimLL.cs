using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDoneWrong.LL {

    public class JimLL<T> : BadLinkedList<T> {

        private Node Head, Tail;
        private int ListSize;

        public JimLL() {
            Head = null;
            Tail = null;
            ListSize = 0;
        }

        public int Size {
            get {
                return ListSize;
            }
        }

        public bool IsEmpty {
            get {
                return ListSize == 0;
            }
        }

        public void Add(T value) {
            if (ListSize == 0) {
                AddFirstValue(value);
            } else {
                AddAtEnd(value);
            }
        }

        public bool Add(int index, T value) {
            if (index < 0 || index > ListSize || value == null) {
                return false;
            } else {
                if (index == ListSize) {
                    Add(value);
                } else {
                    AddInMiddle(index, value, Head);
                }
                return true;
            }
        }

        public void AddFirst(T value) {
            Add(0, value);
        }

        public void Clear() {
            Head = null;
            Tail = null;
            ListSize = 0;
        }

        public T Clone() {
            throw new NotImplementedException();
        }

        public bool Contains(T value) {
            return Contains(value, Head);
        }

        public T Get(int index) {
            throw new NotImplementedException();
        }

        public T GetFirst() {
            throw new NotImplementedException();
        }

        public T GetLast() {
            throw new NotImplementedException();
        }

        public int IndexOf(T value) {
            throw new NotImplementedException();
        }

        public int LastIndexOf(T value) {
            throw new NotImplementedException();
        }

        public bool Remove(T value) {
            throw new NotImplementedException();
        }

        public T Remove(int index) {
            throw new NotImplementedException();
        }

        public T RemoveFirst() {
            throw new NotImplementedException();
        }

        public T RemoveLast() {
            throw new NotImplementedException();
        }

        public T Set(int index, T value) {
            throw new NotImplementedException();
        }

        public T[] ToArray() {
            T[] listArray = new T[ListSize];
            ToArray(listArray, Head, 0);
            return listArray;
        }

        private void AddFirstValue(T value) {
            Head = new Node(value);
            Tail = Head;
            Head.Next = Tail;
            Tail.Prev = Head;
            ListSize = 1;
        }

        private void AddAtEnd(T value) {
            Tail = new Node(Tail.Prev, value);
            ListSize++;
        }

        private void AddInMiddle(int index, T value, Node cur) {
            if (index == 0) {
                Node newNode = new Node(cur.Prev, value, cur);
                newNode.Prev.Next = newNode;
                cur.Prev = newNode;
                ListSize++;
            } else {
                AddInMiddle(index - 1, value, cur.Next);
            }
        }

        private bool Contains(T value, Node cur) {
            if (cur == null) {
                return false;
            } else if (value.Equals(cur.Value)) {
                return true;
            } else {
                return Contains(value, cur.Next);
            }
        }

        private void ToArray(T[] listArray, Node cur, int index) {
            if (cur != null) {
                listArray[index] = cur.Value;
                ToArray(listArray, cur.Next, index + 1);
            }
        }

        private class Node {
            private T NodeValue;
            private Node NextNode, PrevNode;

            public Node(T value) : this(null, value, null) { }

            public Node(Node prev, T value) : this(prev, value, null) { }

            public Node(Node prev, T value, Node next) {
                PrevNode = prev;
                NodeValue = value;
                NextNode = next;
            }

            public Node Next {
                get {
                    return NextNode;
                }
                set {
                    NextNode = value;
                }
            }

            public Node Prev {
                get {
                    return PrevNode;
                }
                set {
                    PrevNode = value;
                }
            }

            public T Value {
                get {
                    return NodeValue;
                }

                set {
                    NodeValue = value;
                }
            }
        }
    }
}
