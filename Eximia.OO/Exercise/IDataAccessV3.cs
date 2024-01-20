namespace Eximia.OO.Exercise
{
    public interface IDataAccessV3
    {
        Result InsertAsync(IEnumerable<EmployeeRecordV3> employees);
    }
}
