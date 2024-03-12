using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDiary
{
    public class TeacherGroupSubject 
    {
        public int Id { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }

    }
}
