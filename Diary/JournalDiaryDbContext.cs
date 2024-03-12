using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDiary
{
    public class JournalDiaryDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeworkStatus> HomeworkStatuses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherGroupSubject> TeacherGroupSubjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\.;Initial Catalog=JournalDiary;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Group>()
                .HasMany(student => student.Students)
                 .WithOne(group => group.Group)
                 .HasForeignKey(nameof(Student.GroupId))
                 .OnDelete(DeleteBehavior.ClientNoAction)*/

            modelBuilder.Entity<Group>()
           .HasMany(teachergroupsubject => teachergroupsubject.teacherGroupSubjects)
           .WithOne(group => group.Group)
           .HasForeignKey(nameof(TeacherGroupSubject.GroupId))
           .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
