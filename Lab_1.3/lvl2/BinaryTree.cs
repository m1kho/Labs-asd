namespace lvl2
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
    }
}
