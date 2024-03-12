using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDiary
{
    public class HomeworkStatus
    {
        public int Id { get; set; } 
        public string Status { get; set; }

        public override string ToString()
        {
            return $"{Status}";
        }

    }
}
