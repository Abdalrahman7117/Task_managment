using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Managment.Models
{
    public class Ta_sk
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        Projects Projects = new Projects();
        [ForeignKey("Projects")]
        public int Pr_id { get; set; }
        TeamMembers TeamMembers = new TeamMembers();
        [ForeignKey("TeamMembers")]
        public int Te_id { get; set; }

    }
}
