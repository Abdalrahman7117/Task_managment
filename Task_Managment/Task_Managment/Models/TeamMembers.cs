using System.ComponentModel.DataAnnotations;

namespace Task_Managment.Models
{
    public class TeamMembers
    {
        [Key]
        public int Te_Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
        List<Task> tasks = new List<Task>();
    }
}
