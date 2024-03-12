using JournalDiary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Main
{
    /// <summary>
    /// Interaction logic for TeacherJournal.xaml
    /// </summary>
    public partial class TeacherJournal : Window
    {

        private ObservableCollection<TeacherGroupSubjectsVm> TGSvms = new();

        JournalDiaryDbContext db = new JournalDiaryDbContext();

        public TeacherJournal(int id)
        {
            Teacher teacher = db.Teachers.Where(teacher => teacher.Id == id).Single();

            InitializeComponent();

            IReadOnlyList<Group> groups = db.Groups
                .OrderBy(group=>group.Id)
                .ToArray();

            IReadOnlyList<Subject> subjects = db.Subjects                
                .OrderBy(subject => subject.Id)
                .ToArray();

            IReadOnlyList<Teacher> teachers = db.Teachers
                .OrderBy(teacher=>teacher.Id)
                .ToArray();

            IReadOnlyList<TeacherGroupSubjectsVm> teacherGroupSubjectsVms = db.TeacherGroupSubjects
                .ToArray()
                .Select(teacherGroupSubjects => new TeacherGroupSubjectsVm(teacherGroupSubjects, teachers, groups, subjects))
                .ToArray();

            foreach (TeacherGroupSubjectsVm vm in teacherGroupSubjectsVms)
                TGSvms.Add(vm);

            DataContext = TGSvms;           
                
        }
    }
}
