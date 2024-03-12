using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDiary
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<TeacherGroupSubject> teacherGroups { get; set; } = new List<TeacherGroupSubject>();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
