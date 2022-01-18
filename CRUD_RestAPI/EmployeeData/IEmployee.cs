using CRUD_RestAPI.Modeld;

namespace CRUD_RestAPI.EmployeeData
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(Guid id);
        Employee AddEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee Employee(Employee employee);
    }
}
