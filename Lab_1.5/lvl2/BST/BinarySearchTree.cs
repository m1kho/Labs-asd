using lvl2.Models;

namespace lvl2.BST
{
    public class BinarySearchTree
    {
        public Node? Root { get; private set; }

        public void Insert(Student student)
        {
            Root = InsertAtRoot(Root, student);
        }

        private Node InsertAtRoot(Node? node, Student student)
        {
            if (node == null)
            {
                return new Node(student);
            }

            if (student.RecordBookNumber < node.Data.RecordBookNumber)
            {
                node.Left = InsertAtRoot(node.Left, student);
                return RotateRight(node);
            }
            else
            {
                node.Right = InsertAtRoot(node.Right, student);
                return RotateLeft(node);
            }
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

        private Node RotateRight(Node y)
        {
            Node x = y.Left!;
            y.Left = x.Right;
            x.Right = y;
            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.Right!;
            x.Right = y.Left;
            y.Left = x;
            return y;
        }
    }
}