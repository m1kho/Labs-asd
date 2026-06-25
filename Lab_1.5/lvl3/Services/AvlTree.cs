using lvl3.Models;
using System;

namespace lvl3.Services
{
    public class AvlTree
    {
        public Node? Root { get; private set; }

        public void Insert(Student student)
        {
            Root = Insert(Root, student);
        }

        private int GetHeight(Node? node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalance(Node? node)
        {
            if (node == null)
            {
                return 0;
            }
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        private Node RotateRight(Node y)
        {
            Node x = y.Left!;
            Node? T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.Right!;
            Node? T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        private Node Insert(Node? node, Student student)
        {
            if (node == null)
            {
                return new Node(student);
            }

            if (student.RecordBookNumber < node.Data.RecordBookNumber)
            {
                node.Left = Insert(node.Left, student);
            }
            else if (student.RecordBookNumber > node.Data.RecordBookNumber)
            {
                node.Right = Insert(node.Right, student);
            }
            else
            {
                return node;
            }

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            int balance = GetBalance(node);

            if (balance > 1 && student.RecordBookNumber < node.Left!.Data.RecordBookNumber)
            {
                return RotateRight(node);
            }

            if (balance < -1 && student.RecordBookNumber > node.Right!.Data.RecordBookNumber)
            {
                return RotateLeft(node);
            }

            if (balance > 1 && student.RecordBookNumber > node.Left!.Data.RecordBookNumber)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && student.RecordBookNumber < node.Right!.Data.RecordBookNumber)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public Node? Search(int recordBookNumber)
        {
            return SearchRecursive(Root, recordBookNumber);
        }

        private Node? SearchRecursive(Node? node, int recordBookNumber)
        {
            if (node == null || node.Data.RecordBookNumber == recordBookNumber)
            {
                return node;
            }

            if (recordBookNumber < node.Data.RecordBookNumber)
            {
                return SearchRecursive(node.Left, recordBookNumber);
            }

            return SearchRecursive(node.Right, recordBookNumber);
        }
    }
}
