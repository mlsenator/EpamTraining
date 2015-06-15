using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBinarySearchTree
{
    public enum OrderType
    {
        Inorder,
        Preorder,
        Postorder
    }
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(T value)
            {
                Value = value;
            }
        }
        public int Count { get; private set; }
        private Comparison<T> comparer;
        private Node root;
        public OrderType TreeOrderType { get; set; }

        public BinarySearchTree() : this(Comparer<T>.Default.Compare){}
        public BinarySearchTree(Comparison<T> comparer)
        {
            this.comparer = comparer;
            TreeOrderType = OrderType.Inorder;
        }
        public BinarySearchTree(IComparer<T> comparer) : this(comparer.Compare){}
        public void Insert(T value)
        {
            Node node = new Node(value);
            if (root == null)
            {
                root = node;
                Count++;
                return;
            }       
            Node parent = root;
            Count++;
            try
            {
                Insert(parent, node);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Not comparable type", ex);
            }
            
        }
        private Node Insert(Node parent, Node node)
        { 
            if (comparer(node.Value, parent.Value) == 0)
            {
                Count--;
                return parent;
            }
                
            if (comparer(node.Value, parent.Value) > 0)
            {
                if (parent.Right == null)
                {
                    parent.Right = node;
                    node.Parent = parent;
                    return parent;
                }
                else return Insert(parent.Right, node);
            }
            else
                if (parent.Left == null)
                {
                    parent.Left = node;
                    node.Parent = parent;
                    return parent;
                }
                else return Insert(parent.Left, node);
        }
        private Node Find(T value)
        {
            Node node = root;
            try
            {
                return Find(node, value);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("Not comparable type", ex);
            }
        }
        private Node Find(Node node, T value)
        {
            if (comparer(value, node.Value) == 0)
                return node;
            if (comparer(value, node.Value) > 0) 
                return Find(node.Right, value);
            else 
                return Find(node.Left, value);
        }
        public bool Contains(T value)
        {
            return (Find(value) != null);
        }
        public void Remove(T value)
        {
            Node nodeToRemove = Find(value);
            if (nodeToRemove == null)
                return;
            Count--;
            Remove(nodeToRemove);
        }
        private void Remove(Node node)
        {
            if (node.Left == null && node.Right == null)
            {
                if (node.Parent.Right == node)
                    node.Parent.Right = null;
                else node.Parent.Left = null;
                return;
            }
                
            if (node.Left == null || node.Right == null)
            {
                if (node.Left == null)
                {
                    node.Value = node.Right.Value;
                    node.Left = node.Right.Left;
                    node.Right = node.Right.Right;
                }

                else
                {
                    node.Value = node.Left.Value;
                    node.Right = node.Left.Right;
                    node.Left = node.Left.Left;
                }
            }
            else
            {
                if (node.Right.Left == null)
                {
                    node.Value = node.Right.Value;
                    node.Right = node.Right.Right;
                }
                else
                {
                    Node temp = node.Left;
                    node.Value = node.Right.Value;
                    node.Left = node.Right.Left;
                    node.Right = node.Right.Right;
                    Insert(node, temp);
                }
                    
            }
        }
        public IEnumerable<T> InOrder()
        {
            foreach (var node in InOrder(root))
            {
                yield return node;
            }
        }
        private IEnumerable<T> InOrder(Node node)
        {
            if (node != null)
            {
                foreach (var temp in InOrder(node.Left))
                {
                    yield return temp;
                }
                yield return node.Value;
                foreach (var temp in InOrder(node.Right))
                {
                    yield return temp;
                }
            }
        }
        public IEnumerable<T> PreOrder()
        {
            foreach (var node in PreOrder(root))
            {
                yield return node;
            }
        }
        private IEnumerable<T> PreOrder(Node node)
        {
            if (node != null)
            {
                yield return node.Value;
                foreach (var temp in PreOrder(node.Left))
                {
                    yield return temp;
                }
                foreach (var temp in PreOrder(node.Right))
                {
                    yield return temp;
                }
            }
        }     
        public IEnumerable<T> PostOrder()
        {
            foreach (var node in PostOrder(root))
            {
                yield return node;
            }
        }
        private IEnumerable<T> PostOrder(Node node)
        {
            if (node != null)
            {
                foreach (var temp in PostOrder(node.Left))
                {
                    yield return temp;
                }
                foreach (var temp in PostOrder(node.Right))
                {
                    yield return temp;
                }
                yield return node.Value;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            //return InOrder().GetEnumerator();
            //with TypeOrder enum enumerators can be private and simpler 
            switch (TreeOrderType)
            {
                case OrderType.Inorder:
                    return InOrder().GetEnumerator();
                case OrderType.Preorder:
                    return PreOrder().GetEnumerator();
                case OrderType.Postorder:
                    return PostOrder().GetEnumerator();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public void Clear()
        {
            root = null;
            Count = 0;
        }
        //TODO:
        //Optimize(){}
       
    }
}
