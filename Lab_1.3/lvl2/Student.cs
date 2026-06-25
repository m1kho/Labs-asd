namespace lvl2
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Course { get; set; }
        public uint StudentTicket { get; set; }
        public string CityOfArrival { get; set; }

        public Student(string lastName, string firstName, int course, uint studentTicket, string cityOfArrival)
        {
            LastName = lastName;
            FirstName = firstName;
            Course = course;
            StudentTicket = studentTicket;
            CityOfArrival = cityOfArrival;
        }

        public override string ToString()
        {
            return $"Студент: {LastName,-12} {FirstName,-10} | Курс: {Course} | Квиток: {StudentTicket:D6} | Приїхав з: {CityOfArrival}";
        }
    }
}
