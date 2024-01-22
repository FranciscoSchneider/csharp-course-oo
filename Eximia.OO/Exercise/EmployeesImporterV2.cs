namespace Eximia.OO.Exercise
{
    public class EmployeesImporterV2
    {
        private readonly IDataAccessV2 _dataAccess;

        public EmployeesImporterV2(IDataAccessV2 dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void Import(Stream employeeStream)
        {
            using var reader = new StreamReader(employeeStream);
            string line;
            var linesCount = 0;

            var employees = new List<EmployeeRecord>();
            while ((line = reader.ReadLine()!) != null)
            {
                linesCount++;
                var fields = line.Split(new[] { ',' });

                if (fields.Length != 3)
                {
                    Console.WriteLine($"Line {linesCount}: invalid record");
                    continue;
                }

                if (fields[0].Length != 6) // id should be 6 chars long
                {
                    Console.WriteLine($"Line {linesCount}: invalid record.");
                    continue;
                }

                decimal salary;
                if (decimal.TryParse(fields[2], out salary))
                {
                    Console.WriteLine($"Line {linesCount}: invalid record");
                    continue;
                }

                employees.Add(new EmployeeRecord(fields[0], fields[1], salary));
            }

            _dataAccess.InsertAsync(employees);
        }

        public record struct EmployeeRecord(string Id, string Name, decimal Salary);
    }
}
