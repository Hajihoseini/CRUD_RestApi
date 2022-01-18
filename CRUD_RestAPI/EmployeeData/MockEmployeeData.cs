using CRUD_RestAPI.EmployeeData;

namespace CRUD_RestAPI.Modeld
{
    public class MockEmployeeData : IEmployee
    {

        private List<Employee> _employees = new List<Employee>()
        {
            new Employee(){Id = Guid.NewGuid(),Name = "Employee No. one"},
            new Employee(){Id = Guid.NewGuid(),Name = "Employee No. two"},
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existedEmployee = GetEmployee(employee.Id);
            existedEmployee.Name = employee.Name;
            return existedEmployee;
        }

        public Employee Employee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(Guid id)
        {
            return _employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}
