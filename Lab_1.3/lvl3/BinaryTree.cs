namespace lvl3
{
    using System;
    using System.Collections.Generic;

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

        public List<Student> SearchMatchingStudents(string universityCity)
        {
            List<Student> result = new List<Student>();
            SearchMatchingRec(root, universityCity, result);
            return result;
        }

        private void SearchMatchingRec(TreeNode node, string universityCity, List<Student> result)
        {
            if (node == null) return;

            SearchMatchingRec(node.Left, universityCity, result);

            if (node.Data.Course == 1 && node.Data.CityOfArrival != universityCity)
            {
                result.Add(node.Data);
            }

            SearchMatchingRec(node.Right, universityCity, result);
        }

        public void Delete(uint ticket)
        {
            root = DeleteRec(root, ticket);
        }

        private TreeNode DeleteRec(TreeNode root, uint ticket)
        {
            if (root == null) return root;

            if (ticket < root.Data.StudentTicket)
            {
                root.Left = DeleteRec(root.Left, ticket);
            }
            else if (ticket > root.Data.StudentTicket)
            {
                root.Right = DeleteRec(root.Right, ticket);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }

                root.Data = MinValue(root.Right);
                root.Right = DeleteRec(root.Right, root.Data.StudentTicket);
            }

            return root;
        }

        private Student MinValue(TreeNode root)
        {
            Student minval = root.Data;
            while (root.Left != null)
            {
                minval = root.Left.Data;
                root = root.Left;
            }
            return minval;
        }
    }
}
