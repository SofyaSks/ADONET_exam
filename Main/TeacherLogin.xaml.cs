using JournalDiary;
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

namespace Main
{
    /// <summary>
    /// Interaction logic for TeacherLogin.xaml
    /// </summary>
    public partial class TeacherLogin : Window
    {
        JournalDiaryDbContext db = new JournalDiaryDbContext();
        public TeacherLogin()
        {
            InitializeComponent();
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            IReadOnlyList<Teacher> students = db.Teachers.ToArray();


            Teacher? teacher = db.Teachers.Where(teacher => teacher.Name == tb_name.Text && teacher.Password == tb_password.Password).SingleOrDefault();

            if (students.Contains(teacher))
            {
                TeacherJournal teacherJournal = new TeacherJournal(teacher.Id);
                teacherJournal.ShowDialog();
            }
            else
                MessageBox.Show("Неправильный логин или пароль");
        }
    }
}
