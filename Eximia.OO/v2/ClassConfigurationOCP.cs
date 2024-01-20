namespace Eximia.OO.v2
{
    public class ClassConfigurationOCP
    {
        public ClassConfigurationOCP(string code, string description, int ageLimit, IEnumerable<DateTime> times)
        {
            Code = code;
            Description = description;
            AgeLimit = ageLimit;
            Times = times;
        }

        public string Code { get; }
        public string Description { get; }
        public int AgeLimit { get; }
        public IEnumerable<DateTime> Times { get; }

        public Result CanRegister(Student student, DateTime when)
        {
            if (student.Age > AgeLimit)
                return Result.Failure("Idade superior ao permitido para a turma.");

            if (!Times.Contains(when))
                return Result.Failure("A turma não possui o horário desejado.");

            return Result.Success();
        }
    }
}
