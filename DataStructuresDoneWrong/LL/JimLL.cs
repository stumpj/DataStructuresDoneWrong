using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDoneWrong.LL {

    public class JimLL<T> : BadLinkedList<T> where T : IEquatable<T>, ICloneable {

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
            Add(ListSize, value);
        }

        public bool Add(int index, T value) {
            if (index < 0 || index > ListSize || value == null) {
                throw new ArgumentException("index", string.Format("Index is out of range. Size = {0}, Add index = {1}", ListSize, index));
            } else if (IsEmpty) {
                AddFirstValue(value);
            } else if (index == ListSize) {
                AddAtEnd(value);
            } else if (index == 0) {
                AddAtFront(value);
            } else {
                AddInMiddle(index, value, Head);
            }
            return true;
        }

        public void AddFirst(T value) {
            Add(0, value);
        }

        public void Clear() {
            Head = null;
            Tail = null;
            ListSize = 0;
        }

        public bool Contains(T value) {
            return Contains(value, Head);
        }

        public T Get(int index) {
            if (index < 0 || index >= ListSize) {
                throw new ArgumentOutOfRangeException("index", string.Format("Index is out of range. Size = {0}, Get index = {1}", ListSize, index));
            } else {
                return Get(Head, index);
            }
        }

        public T GetFirst() {
            if (IsEmpty) {
                throw new Exception("The list is empty");
            } else {
                return Head.Value;
            }
        }

        public T GetLast() {
            if (IsEmpty) {
                throw new Exception("The list is empty");
            } else {
                return Tail.Value;
            }
        }

        public int IndexOf(T value) {
            return IndexOf(value, Head, 0);
        }

        public int LastIndexOf(T value) {
            return LastIndexOf(value, Tail, ListSize - 1);
        }

        public bool Remove(T value) {
            int index = IndexOf(value);
            if (index == -1) {
                return false;
            } else {
                Remove(index);
                return true;
            }
        }

        public T Remove(int index) {
            if (index < 0 || index >= ListSize) {
                throw new ArgumentOutOfRangeException("index", string.Format("Index is out of range. Size = {0}, Remove index = {1}", ListSize, index));
            }

            if (ListSize == 1) {
                T value = Get(0);
                Clear();
                return value;
            } else if (index == 0) {
                return RemoveFirstValue();
            } else if(index == ListSize - 1) {
                return RemoveLastValue();
            } else {
                ListSize--;
                return Remove(index, Head);
            }
        }

        public T RemoveFirst() {
            return Remove(0);
        }

        public T RemoveLast() {
            return Remove(ListSize - 1);
        }

        public T Set(int index, T value) {
            if (index < 0 || index >= ListSize) {
                throw new ArgumentOutOfRangeException("index", "Index is out of range");
            } else {
                return Set(index, value, Head);
            }
        }

        public T[] ToArray() {
            T[] listArray = new T[ListSize];
            ToArray(listArray, Head, 0);
            return listArray;
        }

        public object Clone() {
            return AddAllCloned(Head, new JimLL<T>());
        }

        private void AddFirstValue(T value) {
            Head = new Node(value);
            Tail = Head;
            ListSize = 1;
        }

        private void AddAtEnd(T value) {
            Tail = new Node(Tail, value);
            Tail.Prev.Next = Tail;
            ListSize++;
        }

        private void AddAtFront(T value) {
            Head = new Node(value, Head);
            Head.Next.Prev = Head;
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
                listArray[index] = (T)cur.Value.Clone();
                ToArray(listArray, cur.Next, index + 1);
            }
        }

        private int IndexOf(T value, Node cur, int index) {
            if (cur == null) {
                return -1;
            } else if (cur.Value.Equals(value)) {
                return index;
            } else {
                return IndexOf(value, cur.Next, index + 1);
            }
        }

        private int LastIndexOf(T value, Node cur, int index) {
            if (cur == null) {
                return -1;
            } else if (cur.Value.Equals(value)) {
                return index;
            } else {
                return LastIndexOf(value, cur.Prev, index - 1);
            }
        }

        private T Get(Node cur, int index) {
            if (index == 0) {
                return cur.Value;
            } else {
                return Get(cur.Next, index - 1);
            }
        }

        private T Set(int index, T value, Node cur) {
            if (index == 0) {
                T oldValue = cur.Value;
                cur.Value = value;
                return oldValue;
            } else {
                return Set(index - 1, value, cur.Next);
            }
        }

        private T Remove(int index, Node cur) {
            if (index == 0) {
                cur.Prev.Next = cur.Next;
                cur.Next.Prev = cur.Prev;
                return cur.Value;
            } else {
                return Remove(index - 1, cur.Next);
            }
        }

        private T RemoveFirstValue() {
            T removed = Head.Value;
            Head = Head.Next;
            Head.Prev = null;
            ListSize--;
            return removed;
        }

        private T RemoveLastValue() {
            T removed = Tail.Value;
            Tail = Tail.Prev;
            Tail.Next = null;
            ListSize--;
            return removed;
        }

        private JimLL<T> AddAllCloned(Node cur, JimLL<T> clone) {
            if (cur == null) {
                return clone;
            } else {
                clone.Add((T) cur.Value.Clone());
                return AddAllCloned(cur.Next, clone);
            }
        }

        private class Node {
            private T NodeValue;
            private Node NextNode, PrevNode;

            public Node(T value) : this(null, value, null) { }

            public Node(Node prev, T value) : this(prev, value, null) { }

            public Node(T value, Node next) : this(null, value, next) { }

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
