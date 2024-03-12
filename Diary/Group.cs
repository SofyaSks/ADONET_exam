using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDiary
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<TeacherGroupSubject> teacherGroupSubjects { get; set; } = new List<TeacherGroupSubject>();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
