namespace lvl2.Models
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Group { get; set; }
        public uint StudentTicket { get; set; }

        public Student(string lastName, string firstName, string group, uint studentTicket)
        {
            LastName = lastName;
            FirstName = firstName;
            Group = group;
            StudentTicket = studentTicket;
        }

        public override string ToString()
        {
            return $"| {Group,-8} | {StudentTicket,-12} | {LastName,-12} {FirstName,-10} |";
        }
    }
}