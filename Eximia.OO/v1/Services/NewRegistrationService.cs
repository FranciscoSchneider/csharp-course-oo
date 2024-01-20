using Eximia.OO.v1.Classes;
using Eximia.OO.v1.Repositories;

namespace Eximia.OO.v1.Services
{
    public class NewRegistrationService
    {
        public void Register()
        {
            ClassConfiguration classConfiguration = new()
            {
                Code = "01M",
                Description = "Turma de futebol"
            };

            Student student = new()
            {
                Name = "Júlio Castro Correia",
                Cpf = "84298736431",
                DateOfBirth = new DateOnly(1996, 11, 11),
                AddressStreet = "Rua das Figueiras",
                AddressNumber = "28",
                AddressNeighborhood = "Floresta",
                AddressPostalCode = "93700-000",
                AddressCity = "Campo Bom"
            };

            Registration registration = new()
            {
                ClassCode = classConfiguration.Code,
                StudentCpf = student.Cpf,
                RegisteredIn = DateTime.Now
            };

            RegistrationDataAccess registrationDataAccess = new();
            registrationDataAccess.Add(registration);
        }
    }
}
