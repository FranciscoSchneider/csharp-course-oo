namespace Eximia.OO.v2
{
    public class ClassConfigurationLSP
    {
        public ClassConfigurationLSP(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; }
        public string Description { get; }

        public virtual Result CanRegister(Student student)
        {
            return Result.Success();
        }
    }
}
