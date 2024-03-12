using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JournalDiary;

namespace Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Student(object sender, RoutedEventArgs e)
        {
            

            StudentLogin login = new StudentLogin();
            login.ShowDialog();
        }

        private void Button_Click_Teacher(object sender, RoutedEventArgs e)
        {
            TeacherLogin login = new TeacherLogin();
            login.ShowDialog();
        }
    }
}