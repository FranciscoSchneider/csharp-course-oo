using Eximia.OO.v2.DataAccess;

namespace Eximia.OO.v2.Services
{
    public class NewRegistrationService
    {
        private readonly IRegistrationDataAccess _registrationDataAccess;

        public NewRegistrationService(IRegistrationDataAccess registrationDataAccess)
        {
            _registrationDataAccess = registrationDataAccess;
        }

        public Result<Registration> Register()
        {
            Student student = new(
                name: "Júlio Castro Correia",
                cpf: "84298736431",
                dateOfBirth: new DateOnly(1996, 11, 11),
                address: new Address("Rua das Figueiras", "28", "Floresta", "93700-000", "Campo Bom"));

            SoccerClass soccerClass = new("01F", "Turma de Futebol A", 17);
            Result result = soccerClass.CanRegister(student);
            if (result.IsFailure)
                return result;

            Registration registration = new("12345", soccerClass.Code, student.Cpf);
            _registrationDataAccess.Add(registration);
            return registration;
        }
    }
}
