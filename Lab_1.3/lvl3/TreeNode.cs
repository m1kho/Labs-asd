namespace lvl3
{
    public class TreeNode
    {
        public Student Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(Student student)
        {
            Data = student;
            Left = null;
            Right = null;
        }
    }
}
