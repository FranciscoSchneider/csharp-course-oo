namespace Eximia.OO.v2
{
    [Serializable]
    public class StudentCannotRegisterInTheClassException : Exception
    {
        public string? StudentName { get; }
        public string? ClassCode { get; }

        public StudentCannotRegisterInTheClassException() { }

        public StudentCannotRegisterInTheClassException(string message)
            : base(message) { }

        public StudentCannotRegisterInTheClassException(string message, Exception innerException)
            : base(message, innerException) { }

        public StudentCannotRegisterInTheClassException(string message, string studentName, string classCode)
            : this(message)
        {
            StudentName = studentName;
            ClassCode = classCode;
        }
    }
}
