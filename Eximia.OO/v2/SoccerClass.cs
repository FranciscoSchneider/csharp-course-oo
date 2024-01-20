namespace Eximia.OO.v2
{
    public class SoccerClass : ClassConfiguration
    {
        public SoccerClass(string code, string description, int ageLimit)
            : base(code, description)
        {
            AgeLimit = ageLimit;
        }

        public int AgeLimit { get; }

        public override Result CanRegister(Student student)
        {
            if (!IsOpen())
                return Result.Failure("Turma não está aberta.");

            if (student.Age > AgeLimit)
                return Result.Failure("Idade superior ao permitido para a turma.");

            return Result.Success();
        }

        protected override bool IsOpen()
            => false;
    }
}
