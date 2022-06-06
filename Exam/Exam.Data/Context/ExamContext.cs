using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data.Context
{
    public class ExamContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ExamSongs;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
