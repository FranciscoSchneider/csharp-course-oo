using Eximia.OO.v2.DataAccess;

namespace Eximia.OO.v2.Services
{
    public class ValidateRegistrationService
    {
        public IEnumerable<ClassConfiguration> Validate()
        {
            Student student = new(
               name: "Júlio Castro Correia",
               cpf: "84298736431",
               dateOfBirth: new DateOnly(1996, 11, 11),
               new Address("Rua das Figueiras", "28", "Floresta", "93700-000", "Campo Bom"));

            var classConfigurationDataAccess = new ClassConfigurationDataAccess();
            IEnumerable<ClassConfiguration> configurations = classConfigurationDataAccess.GetConfigurations();

            foreach (var configuration in configurations)
            {
                var result = configuration.CanRegister(student);
                if (result.IsFailure)
                    continue;

                yield return configuration;
            }
        }
    }
}
