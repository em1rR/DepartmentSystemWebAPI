using DepartmentSystemWebAPI.Enums;

namespace DepartmentSystemWebAPI.Entities
{
    public class Student
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int department_id { get; set; }
        public int graduate_id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public DateTime delete_date { get; set; }
        public Boolean is_deleted { get; set; }
        //public Gender gender { get; set; }
        public byte gender { get; set; }
    }
}
