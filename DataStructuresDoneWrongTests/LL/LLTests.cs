using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresDoneWrong.LL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDoneWrong.LL.Tests {

    [TestClass()]
    public class LLTests {

        private BadLinkedList<string> LL;
        private BadLinkedList<MutableTest> LLM;

        public LLTests() {
            LL = new JimLL<string>();
            LLM = new JimLL<MutableTest>();
        }

        [TestMethod()]
        public void AddTest() {
            Assert.AreEqual(0, LL.Size);
            LL.Add("one");
            Assert.AreEqual(1, LL.Size);
            LL.Add("two");
            Assert.AreEqual(2, LL.Size);
            LL.AddFirst("zero");
            Assert.AreEqual(3, LL.Size);
            LL.Add(2, "Another two");
            Assert.AreEqual(4, LL.Size);
        }

        [TestMethod()]
        public void RemoveTest() {
            LL.Add("one");
            LL.Add("two");
            LL.AddFirst("zero");
            LL.Add(2, "Another two");
            LL.Add(3, "blah");
            Assert.AreEqual(5, LL.Size);
            LL.Remove("blah");
            Assert.AreEqual(4, LL.Size);
            LL.Remove(2);
            Assert.AreEqual(3, LL.Size);
            LL.RemoveFirst();
            Assert.AreEqual(2, LL.Size);
            LL.RemoveLast();
            Assert.AreEqual(1, LL.Size);
        }

        [TestMethod()]
        public void GetTest() {
            LL.Add("one");
            LL.Add("two");
            LL.AddFirst("zero");
            LL.Add(2, "Another two");
            LL.Add(3, "blah");
            // zero -> one -> Another two -> blah -> two
            Assert.AreEqual("zero", LL.GetFirst());
            Assert.AreEqual("one", LL.Get(1));
            Assert.AreEqual("Another two", LL.Get(2));
            Assert.AreEqual("blah", LL.Get(3));
            Assert.AreEqual("two", LL.GetLast());
        }

        [TestMethod()]
        public void RemoveValuesTest() {
            LL.Add("one");
            LL.Add("two");
            LL.AddFirst("zero");
            LL.Add(2, "Another two");
            LL.Add(3, "blah");
            LL.Add("last");
            // zero -> one -> Another two -> blah -> two -> last
            Assert.AreEqual("zero", LL.RemoveFirst());
            // one -> Another two -> blah -> two -> last
            Assert.AreEqual("one", LL.Remove(0));
            // Another two -> blah -> two -> last
            Assert.AreEqual("blah", LL.Remove(1));
            // Another two -> two -> last
            Assert.AreEqual("last", LL.RemoveLast());
            // Another two -> two
            Assert.AreEqual("two", LL.Remove(1));
            // Another two
            Assert.IsTrue(LL.Remove("Another two"));
        }

        [TestMethod()]
        public void IndexOfTest() {
            LL.Add("zero");
            LL.Add("one");
            LL.Add("two");
            LL.Add("three");
            LL.Add("one");
            LL.Add("five");

            Assert.AreEqual(0, LL.IndexOf("zero"));
            Assert.AreEqual(1, LL.IndexOf("one"));
            Assert.AreEqual(3, LL.IndexOf("three"));
            Assert.AreEqual(5, LL.IndexOf("five"));
            Assert.AreEqual(-1, LL.IndexOf("not in list"));
        }

        [TestMethod()]
        public void LastIndexOfTest() {
            LL.Add("zero");
            LL.Add("one");
            LL.Add("two");
            LL.Add("three");
            LL.Add("one");
            LL.Add("five");

            Assert.AreEqual(0, LL.LastIndexOf("zero"));
            Assert.AreEqual(4, LL.LastIndexOf("one"));
            Assert.AreEqual(3, LL.LastIndexOf("three"));
            Assert.AreEqual(5, LL.LastIndexOf("five"));
            Assert.AreEqual(-1, LL.LastIndexOf("not in list"));
        }

        [TestMethod()]
        public void RemoveByValuesTest() {
            LL.Add("zero");
            LL.Add("one");
            LL.Add("two");
            LL.Add("three");
            LL.Add("four");
            LL.Add("five");
            // zero -> one -> two -> three -> four -> five
            Assert.IsTrue(LL.Remove("zero"));
            Assert.IsTrue(LL.Remove("two"));
            Assert.IsTrue(LL.Remove("five"));
            // one -> three -> four
            Assert.AreEqual(3, LL.Size);
            Assert.AreEqual("one", LL.Get(0));
            Assert.AreEqual("three", LL.Get(1));
            Assert.AreEqual("four", LL.Get(2));
        }

        [TestMethod()]
        public void RemoveEmptyTest() {
            LL.Add("zero");
            LL.RemoveFirst();
            Exception exc = null;
            try {
                LL.RemoveFirst();
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception since empty");
        }

        [TestMethod()]
        public void RemoveEmptyLastTest() {
            LL.Add("zero");
            LL.RemoveLast();
            Exception exc = null;
            try {
                LL.RemoveLast();
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception since empty");
        }

        [TestMethod()]
        public void RemoveNegativeIndexTest() {
            LL.Add("zero");
            LL.Add("two");
            Exception exc = null;
            try {
                LL.Remove(-2);
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception for negative index");
        }

        [TestMethod()]
        public void RemoveOutOfRangeTest() {
            LL.Add("zero");
            LL.Add("two");
            Exception exc = null;
            try {
                LL.Remove(3);
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception for out of range index");
        }

        [TestMethod()]
        public void AddOutOfRangeTest() {
            LL.Add("zero");
            Exception exc = null;
            try {
                LL.Add(2, "two");
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception for out of range index");
        }

        [TestMethod()]
        public void GetOutOfRangeTest() {
            LL.Add("zero");
            Exception exc = null;
            try {
                LL.Get(1);
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception for get of range index");
        }

        [TestMethod()]
        public void GetNegativeTest() {
            LL.Add("zero");
            Exception exc = null;
            try {
                LL.Get(-2);
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception for get of range index");
        }

        [TestMethod()]
        public void ContainsGoodTest() {
            LL.Add("zero");
            Assert.IsTrue(LL.Contains("zero"));
        }

        [TestMethod()]
        public void ContainsBadTest() {
            LL.Add("zero");
            Assert.IsFalse(LL.Contains("one"));
        }

        [TestMethod()]
        public void GetFirstEmptyTest() {
            Exception exc = null;
            try {
                LL.GetFirst();
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception for get on empty list");
        }

        [TestMethod()]
        public void GetLastEmptyTest() {
            Exception exc = null;
            try {
                LL.GetLast();
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception for get on empty list");
        }

        [TestMethod()]
        public void RemoveNotInListTest() {
            LL.Add("zero");
            Assert.IsFalse(LL.Remove("one"));
        }

        [TestMethod()]
        public void SetNegativeIndexTest() {
            LL.Add("zero");
            Exception exc = null;
            try {
                LL.Set(-2, "negative two");
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception for out of range index (negative)");
        }

        [TestMethod()]
        public void SetOutOfRangeIndexTest() {
            LL.Add("zero");
            Exception exc = null;
            try {
                LL.Set(2, "two");
            } catch (Exception e) {
                exc = e;
            }
            Assert.IsNotNull(exc, "Should throw exception for out of range index");
        }

        [TestMethod()]
        public void SetFirstTest() {
            LL.Add("zero");
            LL.Add("one");
            LL.Add("two");

            LL.Set(0, "changed");

            Assert.AreEqual("changed", LL.GetFirst());
            Assert.AreEqual("one", LL.Get(1));
            Assert.AreEqual("two", LL.GetLast());
        }

        [TestMethod()]
        public void SetMiddleTest() {
            LL.Add("zero");
            LL.Add("one");
            LL.Add("two");

            LL.Set(1, "changed");

            Assert.AreEqual("zero", LL.GetFirst());
            Assert.AreEqual("changed", LL.Get(1));
            Assert.AreEqual("two", LL.GetLast());
        }

        [TestMethod()]
        public void SetLastTest() {
            LL.Add("zero");
            LL.Add("one");
            LL.Add("two");

            LL.Set(2, "changed");

            Assert.AreEqual("zero", LL.GetFirst());
            Assert.AreEqual("one", LL.Get(1));
            Assert.AreEqual("changed", LL.GetLast());
        }

        [TestMethod()]
        public void ToArrayEmptyTest() {
            string[] ar = LL.ToArray();

            Assert.AreEqual(0, ar.Length);
        }

        [TestMethod()]
        public void ToArrayValuesTest() {
            LL.Add("zero");
            LL.Add("one");
            LL.Add("one");
            LL.Add("two");

            string[] ar = LL.ToArray();

            Assert.AreEqual(4, ar.Length);
            Assert.AreEqual("zero", ar[0]);
            Assert.AreEqual("one", ar[1]);
            Assert.AreEqual("one", ar[2]);
            Assert.AreEqual("two", ar[3]);
        }

        [TestMethod()]
        public void ToArrayValuesDeepCopyTest() {
            LLM.Add(new MutableTest(1));
            LLM.Add(new MutableTest(2));
            MutableTest[] ar = LLM.ToArray();

            Assert.AreEqual(LLM.Get(0), ar[0]);
            Assert.AreNotSame(LLM.Get(0), ar[0]);
            Assert.AreEqual(LLM.Get(1), ar[1]);
            Assert.AreNotSame(LLM.Get(1), ar[1]);
        }

        [TestMethod()]
        public void CloneValuesDeepCopyTest() {
            LLM.Add(new MutableTest(1));
            LLM.Add(new MutableTest(2));
            BadLinkedList<MutableTest> cloned = (BadLinkedList<MutableTest>) LLM.Clone();

            Assert.AreEqual(LLM.Get(0), cloned.Get(0));
            Assert.AreNotSame(LLM.Get(0), cloned.Get(0));
            Assert.AreEqual(LLM.Get(1), cloned.Get(1));
            Assert.AreNotSame(LLM.Get(1), cloned.Get(1));
        }


        private class MutableTest : ICloneable, IEquatable<MutableTest> {
            public int Value;

            public MutableTest(int value) {
                Value = value;
            }

            public object Clone() {
                return new MutableTest(Value);
            }

            public bool Equals(MutableTest other) {
                return Value == other.Value;
            }

            public override bool Equals(object other) {
                if (other == null || GetType() != other.GetType()) {
                    return false;
                }
                return Value == ((MutableTest) other).Value;
            }

            public override int GetHashCode() {
                return Value.GetHashCode();
            }
        }
    }
}