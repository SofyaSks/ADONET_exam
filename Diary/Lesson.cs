using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDiary
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }
        public TeacherGroupSubject TeacherGroupSubject { get; set; }
        public int TeacherGroupSubjectId { get; set; }
        public ICollection<StudentLesson> studentLessons { get; set; } = new List<StudentLesson>();
        public override string ToString()
        {
            return $"{Theme} {Date.ToString("dd.MM.yy")} {Grade} {TeacherGroupSubject.Teacher.Name}";
        }

    }
}
