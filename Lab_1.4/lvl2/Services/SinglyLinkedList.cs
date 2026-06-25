using lvl2.Models;

namespace lvl2.Services
{
    public class SinglyLinkedList
    {
        public Node? Head { get; private set; }

        public void Append(Student student)
        {
            var newNode = new Node(student);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public void InsertionSort()
        {
            if (Head == null || Head.Next == null)
            {
                return;
            }

            Node? sorted = null;
            var current = Head;
            while (current != null)
            {
                var next = current.Next;
                InsertSorted(current, ref sorted);
                current = next;
            }
            Head = sorted;
        }

        private void InsertSorted(Node newNode, ref Node? sorted)
        {
            if (sorted == null || CompareStudents(newNode.Value, sorted.Value) < 0)
            {
                newNode.Next = sorted;
                sorted = newNode;
            }
            else
            {
                var current = sorted;
                while (current.Next != null && CompareStudents(newNode.Value, current.Next.Value) >= 0)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        private int CompareStudents(Student s1, Student s2)
        {
            var culture = System.Globalization.CultureInfo.GetCultureInfo("uk-UA");
            int groupComparison = string.Compare(s1.Group, s2.Group, culture, System.Globalization.CompareOptions.None);
            if (groupComparison != 0)
            {
                return groupComparison;
            }
            return s1.StudentTicket.CompareTo(s2.StudentTicket);
        }
    }
}
