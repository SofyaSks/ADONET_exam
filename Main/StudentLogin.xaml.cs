using JournalDiary;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    public partial class StudentLogin : Window
    {
        JournalDiaryDbContext db = new JournalDiaryDbContext();
        public StudentLogin()
        {
            InitializeComponent();


        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            IReadOnlyList<Student> students = db.Students.ToArray();


            Student? student = db.Students.Where(s => s.Name == tb_name.Text && s.Password == tb_password.Password).SingleOrDefault();

            if (students.Contains(student))
            {                 
                StudentDiary studentDiary = new StudentDiary(student.Id);
                studentDiary.ShowDialog();
            }
            else
                MessageBox.Show("Неправильный логин или пароль");

        }
    }
}
