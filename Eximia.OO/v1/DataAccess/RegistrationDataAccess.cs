namespace Eximia.OO.v1.Repositories
{
    public class RegistrationDataAccess
    {
        private List<Registration> _registrations;

        public RegistrationDataAccess()
        {
            _registrations = new List<Registration>();
        }

        public void Add(Registration registration) => _registrations.Add(registration);
    }
}
