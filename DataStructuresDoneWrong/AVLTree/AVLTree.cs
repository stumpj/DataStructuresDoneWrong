using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDoneWrong.AVLTree
{

    /// <summary>
    /// AVLTree Interface 
    /// </summary>
    public interface AVLTree<T> : ICloneable where T : IEquatable<T>, ICloneable, IComparable<T>
    {
        /// <summary>
        /// Add node to tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void Add(T value);

        /// <summary>
        /// Remove all nodes in tree
        /// </summary>
        void Clear();

        /// <summary>
        /// Checks if tree contains value. Returns true if value in tree. False if not.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Contains(T value);

        /// <summary>
        /// Returns Height of the AVL Tree
        /// </summary>
        /// <returns></returns>
        int GetHeight();

        /// <summary>
        /// Returns value at root of the AVL Tree
        /// </summary>
        /// <returns></returns>
        T GetRoot();

        /// <summary>
        /// Returns max value of the AVL Tree
        /// </summary>
        /// <returns></returns>
        T GetMax();

        /// <summary>
        /// Returns min  valuue of the AVL Tree
        /// </summary>
        /// <returns></returns>
        T GetMin();

        /// <summary>
        /// Removes first encountered node containing value
        /// 
        /// Return false if value not in tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Remove(T value);

        /// <summary>
        /// Makes a copy of the AVL tree
        /// 
        /// </summary>
        /// <returns></returns>
        T Copy();

        /// <summary>
        /// Prints Tree in the order designated by order parameter
        /// 0 - Pre-order
        /// 1 - In-order
        /// 2 - Post-order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// 
        void PrintTree(int Order);

        /// <summary>
        /// True if tree is empty
        /// </summary>
        bool IsEmpty
        {
            get;
        }

        /// <summary>
        /// Number of Nodes in the tree
        /// </summary>
        int Size
        {
            get;
        }
    }
}



