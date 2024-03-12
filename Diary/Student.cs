using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDiary
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public ICollection<StudentLesson> studentLessons { get; set; } = new List<StudentLesson>();

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
