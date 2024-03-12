using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JournalDiary
{
    public class Homework
    {
        public int Id { get; set; }  
        public HomeworkStatus Status { get; set; }
        public int HomeworkStatusId { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public string Task { get; set; }
        public int? Grade { get; set; }
        public string? Comment { get; set; }

        public override string ToString()
        {
            return $"{Theme} {Status.Status} {Date.ToString("dd.MM.yy")} {Task} {Grade} {Comment}";
        }
    }
}
