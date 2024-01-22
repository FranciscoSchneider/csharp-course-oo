namespace Eximia.OO.Exercise
{
    public class EmployeesImporterV3
    {
        private readonly IDataAccessV3 _dataAccess;

        public EmployeesImporterV3(IDataAccessV3 dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void Import(Stream employeeStream)
        {
            using var reader = new StreamReader(employeeStream);
            string line;
            var linesCount = 0;

            var employees = new List<EmployeeRecordV3>();
            while ((line = reader.ReadLine()!) != null)
            {
                linesCount++;
                var fields = line.Split(new[] { ',' });

                var employee = EmployeeRecordV3.Create(fields);
                if (employee.IsFailure)
                {
                    Console.WriteLine(employee.Error);
                    continue;
                }

                employees.Add(employee.Value);
            }

            _dataAccess.InsertAsync(employees);
        }
    }
}
