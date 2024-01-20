using Eximia.OO.v3.Strategies;

namespace Eximia.OO.v3
{
    public class ClassConfiguration
    {
        public ClassConfiguration(string code, string description, ICanRegisterStudentStrategy canRegisterStudentStrategy)
        {
            Code = code;
            Description = description;
            CanRegisterStudentStrategy = canRegisterStudentStrategy;
        }

        public string Code { get; }
        public string Description { get; }
        public ICanRegisterStudentStrategy CanRegisterStudentStrategy { get; }

        public static ClassConfiguration Create(string code, string description)
            => new ClassConfiguration(
                code,
                description,
                new CanRegisterStudentDefaultStrategy());

        public static ClassConfiguration CreateWithAgeLimit(string code, string description, int ageLimit)
            => new ClassConfiguration(
                code,
                description,
                new CanRegisterStudentWithAgeLimitStrategy(ageLimit));
    }
}
