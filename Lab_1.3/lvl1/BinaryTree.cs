namespace lvl1
{
    using System;

    public class BinaryTree
    {
        private TreeNode root;

        public void Insert(Student student)
        {
            root = InsertRec(root, student);
        }

        private TreeNode InsertRec(TreeNode root, Student student)
        {
            if (root == null)
            {
                return new TreeNode(student);
            }

            if (student.StudentTicket < root.Data.StudentTicket)
            {
                root.Left = InsertRec(root.Left, student);
            }
            else if (student.StudentTicket > root.Data.StudentTicket)
            {
                root.Right = InsertRec(root.Right, student);
            }

            return root;
        }

        public void Inorder()
        {
            InorderRec(root);
            Console.WriteLine();
        }

        private void InorderRec(TreeNode root)
        {
            if (root != null)
            {
                InorderRec(root.Left);
                Console.WriteLine(root.Data);
                InorderRec(root.Right);
            }
        }

        public void Preorder()
        {
            PreorderRec(root);
            Console.WriteLine();
        }

        private void PreorderRec(TreeNode root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Data);
                PreorderRec(root.Left);
                PreorderRec(root.Right);
            }
        }

        public void Postorder()
        {
            PostorderRec(root);
            Console.WriteLine();
        }

        private void PostorderRec(TreeNode root)
        {
            if (root != null)
            {
                PostorderRec(root.Left);
                PostorderRec(root.Right);
                Console.WriteLine(root.Data);
            }
        }
    }
}
