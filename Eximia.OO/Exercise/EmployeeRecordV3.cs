namespace Eximia.OO.Exercise
{
    public class EmployeeRecordV3
    {
        public EmployeeRecordV3(string id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public string Id { get; }
        public string Name { get; }
        public decimal Salary { get; }

        public static Result<EmployeeRecordV3> Create(string[] fields)
        {
            if (fields.Length != 3)
                return Result.Failure("Linha inválida.");

            if (fields[0].Length != 6) // id should be 6 chars long
                return Result.Failure("Id inválido.");

            decimal salary;
            if (!decimal.TryParse(fields[2], out salary))
                return Result.Failure("Salário inválido.");

            return new EmployeeRecordV3(fields[0], fields[1], salary);
        }
    }
}
