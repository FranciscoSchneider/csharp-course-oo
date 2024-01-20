namespace Eximia.OO.v2.Services
{
    public class AdvancedExcelClass : ClassConfigurationLSP
    {
        public AdvancedExcelClass(string code, string description)
            : base(code, description)
        { }

        public new Result CanRegister(Student student)
        {
            return Result.Failure("Error!");
        }
    }
}
