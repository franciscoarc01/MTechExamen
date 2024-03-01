using API_Backend.Enums;

namespace API_Backend.Models
{
    public class Employee
    {
        public int ID { get; set; }



        public string Name { get; set; }



        public string LastName { get; set; }



        public string RFC { get; set; }



        public DateTime BornDate { get; set; }



        public EnumEmployeeStatus Status { get; set; }
    }
}
