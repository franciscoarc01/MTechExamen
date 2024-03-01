using API_Backend.Controllers;
using API_Backend.Enums;
using API_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pruebas
{
    public class EmployeeTest
    {
        private readonly EmployeeController _employeeController;

        public EmployeeTest() 
        { 
            _employeeController = new EmployeeController();
        }

        [Fact]
        public void GetEmployeeList_GenericList()
        {
            //Arrange and Act
            var result = _employeeController.Get();
            //Assert
            Assert.IsType<System.Collections.Generic.List<Employee>>(result);
        }

        [Fact]
        public void GetEmployeeById_Ok()
        {
            //Arrange
            string id = "58fb29b70476";
            //Act
            var result = _employeeController.Get(id);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetEmployeeById_NotFound()
        {
            //Arrange
            string id = "aksdjal";
            //Act
            var result = _employeeController.Get(id);
           //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetSortedEmployeeListByName_GenericList()
        {
            //Arrange
            string name = "Cabo";
            //Act
            var result = _employeeController.GetByName(name);
            //Assert
            Assert.IsType<System.Collections.Generic.List<Employee>>(result);
        }

        [Fact]
        public void ExistRFConDB_Insert()
        {
            //Arrange
            Employee employee = new Employee
            {
                ID = Guid.NewGuid().ToString().Substring(24, 12),
                Name = "Some Name",
                LastName = "Some LastName",
                BornDate = DateTime.Parse("04/12/1998"),
                RFC = "RFC182712388",
                Status = EnumEmployeeStatus.Active,
            };
            //Act
            var result = _employeeController.Post(employee);
            //Assert
            Assert.False(result.Value);
        }

        [Fact]
        public void ExistRFConDB_Update()
        {
            //Arrange
            string id = "58fb29b70476";
            Employee employee = new Employee
            {
                Name = "Cabo",
                LastName = "Pingüino Cañaveral",
                BornDate = DateTime.Parse("12/01/2004"),
                RFC = "RFC182712388",
                Status = EnumEmployeeStatus.Active,
            };
            //Act
            var result = _employeeController.Put(id, employee);
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void NotFoundEmployee_Update()
        {
            //Arrange
            string id = Guid.NewGuid().ToString().Substring(24, 12);
            Employee employee = new Employee
            {
                Name = "Cabo",
                LastName = "Pingüino Cañaveral",
                BornDate = DateTime.Parse("12/01/2004"),
                RFC = "RFC1827122388",
                Status = EnumEmployeeStatus.Active,
            };
            //Act
            var result = _employeeController.Put(id, employee);
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
