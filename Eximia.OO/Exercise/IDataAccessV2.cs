using static Eximia.OO.Exercise.EmployeesImporterV2;

namespace Eximia.OO.Exercise
{
    public interface IDataAccessV2
    {
        Result InsertAsync(IEnumerable<EmployeeRecord> employees);
    }
}
