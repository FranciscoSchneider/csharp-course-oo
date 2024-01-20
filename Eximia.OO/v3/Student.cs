namespace Eximia.OO.v3
{
    public class Student
    {
        public Student(string name, Cpf cpf, DateOnly dateOfBirth, Address address)
        {
            Name = name;
            Cpf = cpf;
            DateOfBirth = dateOfBirth;
            Address = address;
        }

        public string Name { get; }
        public Cpf Cpf { get; }
        public DateOnly DateOfBirth { get; }
        public Address Address { get; }
        public int Age => CalculateAge(DateOfBirth);

        private int CalculateAge(DateOnly dateOfBirth)
        {
            var ts = DateTime.Now - dateOfBirth.ToDateTime(TimeOnly.MinValue);
            var daysOfAge = ts.Days;

            if (daysOfAge < 366)
                return 0;

            DateTime age = (new DateTime() + ts).AddYears(-1);
            return age.Year;
        }
    }
}
