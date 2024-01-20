namespace Eximia.OO.v3.Strategies
{
    public class CanRegisterStudentWithAgeLimitStrategy : ICanRegisterStudentStrategy
    {
        public CanRegisterStudentWithAgeLimitStrategy(int ageLimit)
        {
            AgeLimit = ageLimit;
        }

        public int AgeLimit { get; }

        public Result CanRegister(Student student)
        {
            if (student.Age > AgeLimit)
                return Result.Failure("Idade superior ao permitido para a turma.");

            return Result.Success();
        }
    }
}
