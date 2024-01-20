namespace Eximia.OO.v3.Strategies
{
    public class CanRegisterStudentDefaultStrategy : ICanRegisterStudentStrategy
    {
        public Result CanRegister(Student student)
            => Result.Success();
    }
}
