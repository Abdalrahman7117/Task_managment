using Microsoft.EntityFrameworkCore;

namespace Task_Managment.Models
{
    public class DBcontext : DbContext
    {
        public DbSet<Ta_sk> ta_Sks { get; set; }
        public DbSet<Projects> projects { get; set; }
        public DbSet<TeamMembers> teamMembers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Task;Persist Security Info=True;User ID=sa;Password=FIATS@2024;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
