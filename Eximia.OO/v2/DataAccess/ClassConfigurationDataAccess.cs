namespace Eximia.OO.v2.DataAccess
{
    public class ClassConfigurationDataAccess
    {
        private List<ClassConfiguration> _classes;

        public ClassConfigurationDataAccess()
        {
            _classes = new List<ClassConfiguration>();
        }

        public IEnumerable<ClassConfiguration> GetConfigurations()
            => _classes;

        public ClassConfiguration GetById(string code)
            => _classes.Single(c => c.Code == code);
    }
}
