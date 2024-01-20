namespace Eximia.OO.v3
{
    public class Registration
    {
        public Registration(string number, string classCode, Cpf studentCpf)
        {
            Number = number;
            ClassCode = classCode;
            StudentCpf = studentCpf;
            RegisteredIn = DateTime.Now;
        }

        public string Number { get; }
        public string ClassCode { get; private set; }
        public Cpf StudentCpf { get; }
        public DateTime RegisteredIn { get; }

        public void ChangeClass(string classCode)
        {
            ClassCode = classCode;
        }
    }
}
