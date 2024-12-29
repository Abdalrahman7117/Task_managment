using System.ComponentModel.DataAnnotations;

namespace Task_Managment.Models
{
    public class Projects
    {
        [Key]
        public int Pr_Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public int Description { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        List<Task> tasks = new List<Task>();
    }
}
