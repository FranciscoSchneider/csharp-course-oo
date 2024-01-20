using Microsoft.Data.SqlClient;
using System.Data;

namespace Eximia.OO.Exercise
{
    public class EmployeesImporterV1
    {
        public void Import(Stream employeeStream)
        {
            using var reader = new StreamReader(employeeStream);
            string line;
            var linesCount = 0;

            using var dbconn = new SqlConnection("Data Source = (local), InitialCatalog, Integrated Security = True");
            dbconn.Open();

            using var transaction = dbconn.BeginTransaction();

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

                var e = new EmployeeRecord(fields[0], fields[1], salary);

                var command = dbconn.CreateCommand();
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertEmployee";
                command.Parameters.AddWithValue("@id", e.Id);
                command.Parameters.AddWithValue("@name", e.Name);
                command.Parameters.AddWithValue("@salary", e.Salary);
                command.ExecuteNonQuery();
            }

            transaction.Commit();
            dbconn.Close();
        }

        public record struct EmployeeRecord(string Id, string Name, decimal Salary);

    }
}
