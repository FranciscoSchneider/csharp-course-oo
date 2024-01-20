namespace Eximia.OO.v2.DataAccess
{
    public class RegistrationDataAccess : IRegistrationDataAccess
    {
        private List<Registration> _registrations;

        public RegistrationDataAccess()
        {
            _registrations = new List<Registration>();
        }

        public void Add(Registration registration) => _registrations.Add(registration);
    }
}
