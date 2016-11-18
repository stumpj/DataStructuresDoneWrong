using System;

namespace DataStructuresDoneWrong.LL
{
    public class AnnLL<T> : BadLinkedList<T>
    {

        /// <summary>
        /// Add at a position in list.
        /// 
        /// Return false if out of range).
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Add(int index, T value);

        /// <summary>
        /// Add at end of list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void Add(T value);

        /// <summary>
        /// Add value at front of list
        /// </summary>
        /// <param name="value"></param>
        void AddFirst(T value);

        /// <summary>
        /// Remove all elements
        /// </summary>
        void Clear();

        /// <summary>
        /// Checks if list contains a value. Returns true if value in list. False if not.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Contains(T value);

        /// <summary>
        /// Gets value at index.
        /// 
        /// Throw exception if out of range;
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T Get(int index);

        /// <summary>
        /// Returns first value in the list
        /// </summary>
        /// <returns></returns>
        T GetFirst();

        /// <summary>
        /// Returns last value in the list
        /// </summary>
        /// <returns></returns>
        T GetLast();

        /// <summary>
        /// Returns first occurrence of value, or -1 if not in list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int IndexOf(T value);

        /// <summary>
        /// Returns last occurrence of value, or -1 if not in list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int LastIndexOf(T value);

        /// <summary>
        /// Removes object at position.
        /// 
        /// Throw exception if out of range
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T Remove(int index);

        /// <summary>
        /// Removes first occurrence of object in list. Return true if removed.
        /// 
        /// Return false if object not in list
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Remove(T value);

        /// <summary>
        /// Returns first value in the list
        /// </summary>
        /// <returns></returns>
        T RemoveFirst();

        /// <summary>
        /// Returns last value in the list
        /// </summary>
        /// <returns></returns>
        T RemoveLast();

        /// <summary>
        /// Sets the value at the given position to the new value. Returns the old value.
        /// 
        /// Throw exception if out of range
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        T Set(int index, T value);

        /// <summary>
        /// Returns an array representing the list
        /// </summary>
        /// <returns></returns>
        T[] ToArray();

        /// <summary>
        /// True if list is empty, false if not
        /// </summary>
        bool IsEmpty
        {
            get;
        }

        /// <summary>
        /// Size of list
        /// </summary>
        int Size
        {
            get;
        }
    }
}

