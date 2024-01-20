namespace Eximia.OO.v2
{
    public abstract class ClassConfiguration
    {
        protected ClassConfiguration(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; }
        public string Description { get; }

        public abstract Result CanRegister(Student student);

        protected virtual bool IsOpen()
            => true;
    }
}
