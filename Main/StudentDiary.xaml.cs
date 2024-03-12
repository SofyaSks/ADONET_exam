using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using JournalDiary;
using Microsoft.EntityFrameworkCore;

namespace Main
{
    /// <summary>
    /// Interaction logic for StudentDiary.xaml
    /// </summary>
    public partial class StudentDiary : Window
    {
        JournalDiaryDbContext db = new JournalDiaryDbContext();
        public StudentDiary(int id)
        {
            InitializeComponent();

            Student student = db.Students.Where(student => student.Id == id).Single();

            IReadOnlyList<Homework> homeworks = db.Homeworks
                .Include(status => status.Status)
                .Include(lesson => lesson.Lesson)
                .OrderBy(homework => homework.Date)
                .ToArray();


            IReadOnlyList<StudentLesson> studentLessons = db.StudentLessons
                .Where(sl => sl.StudentId == student.Id)
                .Include(lesson => lesson.Lesson)
                    .ThenInclude(subject => subject.TeacherGroupSubject)
                        .ThenInclude(subject => subject.Subject)
                .Include(lesson => lesson.Lesson)
                    .ThenInclude(teacher => teacher.TeacherGroupSubject)
                        .ThenInclude(teacher => teacher.Teacher)

                .ToArray();

            lb_lesson.ItemsSource = studentLessons;

            lb_homework.ItemsSource = homeworks;
        }



    }
}
