using CRUD_RestAPI.Modeld;
using CRUD_RestAPI.Models;

namespace CRUD_RestAPI.EmployeeData
{
    public class SqlEmployeeData : IEmployee
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employee.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
                _employeeContext.Employee.Remove(employee);
                _employeeContext.SaveChanges();
            
        }

        public Employee EditEmployee(Employee employee)
        {
            var existedEmployee = _employeeContext.Employee.Find(employee.Id);

            if (existedEmployee != null)
            {
                existedEmployee.Name = employee.Name;
                _employeeContext.Employee.Update(existedEmployee);
                _employeeContext.SaveChanges();
            }
            return employee;
        }

        public Employee Employee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(Guid id)
        {
            var employee = _employeeContext.Employee.Find(id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
           return _employeeContext.Employee.ToList();
        }
    }
}
