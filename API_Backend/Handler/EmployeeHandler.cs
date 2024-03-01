using API_Backend.Enums;
using API_Backend.Models;
using Biblioteca;

namespace API_Backend.Handler
{
    public static class EmployeeHandler
    {
        private static List<Employee> employees;
        private static List<Employee> sortedEmployes;

        private static List<Employee> convertData()
        {
            List<Employee> employees = new List<Employee>();
            string[] data = Lectura.Lista("");
            foreach (string dataElement in data)
            {
                string[] properties = dataElement.Split(',');
                // "ID: {0},Name: {1},LastName: {2},BornDate: {3},RFC: {4},Status: {5}"
                employees.Add(new Employee
                    { 
                        ID = properties[0].Split(":")[1].Replace(" ", string.Empty),
                        Name = properties[1].Split(":")[1].Replace(" ", string.Empty),
                        LastName = properties[2].Split(":")[1].Replace(" ", string.Empty),
                        BornDate = DateTime.Parse(properties[3].Split(":")[1].Replace(" ", string.Empty)),
                        RFC = properties[4].Split(":")[1].Replace(" ", string.Empty),
                        Status = Enum.Parse<EnumEmployeeStatus>(properties[5].Split(":")[1].Replace(" ", string.Empty))
                    }
                );
            }
            return employees;
        }

        public static List<Employee> Employees()
        {

            if (employees == null)
            {
                return employees = convertData();
            }
            else
            {
                return employees;
            }

        }

        private static bool insertData(string[] arrayRAWData)
        {
            try
            {
                for (uint index = 0; index < employees.Count; index++)
                {
                    Employee employeeAux = employees[Convert.ToInt32(index)];
                    arrayRAWData[index] = String.Format("ID: {0},Name: {1},LastName: {2},BornDate: {3},RFC: {4},Status: {5}",
                        employeeAux.ID,
                        employeeAux.Name,
                        employeeAux.LastName,
                        employeeAux.BornDate.ToString(),
                        employeeAux.RFC,
                        employeeAux.Status
                    );
                }
                Escritura.EscrituraFuncion("", arrayRAWData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool InsertEmployee(Employee employee)
        {
            //if(employee.RFC.Length == )
            if(employees == null)
            {
                employees = convertData();
            }
            employees.Add(employee);
            return insertData(new string [employees.Count]);
        }

        public static Employee FindEmployee(string id)
        {
            if (employees == null)
            {
                employees = convertData();
            }
            foreach (Employee employee in employees)
            {
                if(id == employee.ID)
                {
                    return employee;
                }
            }
            return null;
        }

        public static void UpdateEmployee(string id, Employee updateEmployee)
        {
            Employee employee = FindEmployee(id);
            employee.BornDate = updateEmployee.BornDate;
            employee.RFC = updateEmployee.RFC;
            employee.Status = updateEmployee.Status;
            employee.LastName = updateEmployee.LastName;
            employee.Name = updateEmployee.Name;
            if(!insertData(new string[employees.Count]))
            {
                throw new Exception("Error insert/update");
            }
            
        }

        public static bool DeleteEmployee(string id)
        {
            Employee employee = FindEmployee(id);
            employees.Remove(employee);
            return insertData(new string[employees.Count]);
        }

        public static List<Employee> FindEmployeeByNames(string name)
        {
            if (employees == null)
            {
                employees = convertData();
            }
            sortedEmployes = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (name == employee.Name.Substring(0, name.Length))
                {
                    sortedEmployes.Add(employee);
                }
            }
            return sortedEmployes.OrderBy(employee => employee.BornDate).ToList();
        }
    }
    
}
