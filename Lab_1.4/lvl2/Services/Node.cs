using lvl2.Models;

namespace lvl2.Services
{
    public class Node
    {
        public Student Value { get; set; }
        public Node? Next { get; set; }

        public Node(Student value)
        {
            Value = value;
            Next = null;
        }
    }
}
