using ArgocomTRPO.DB;
using ArgocomTRPO.WindowsAdmin;
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
using ArgocomTRPO.WindowsTS;

namespace ArgocomTRPO
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            //new BreakingWindowAdmin().Show();
        }

        private void Button_minimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WrapPanel_mouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        bool check2 = true;

        //Смена языка
        public void Button_language(object sender, RoutedEventArgs e)
        {
            if (check2 == true)
            {
                var uri2 = new Uri(@"Resource/English.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary2 = Application.LoadComponent(uri2) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2);
                check2 = false;
            }
            else
            {
                var uri = new Uri(@"Resource/Russian.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                check2 = true;
            }

        }



        bool check1 = true;

        private void Click_Color(object sender, RoutedEventArgs e)
        {
            if (check1 == true)
            {
                var uri2 = new Uri(@"Resource/Black.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary2 = Application.LoadComponent(uri2) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2);
                check1 = false;
            }
            else
            {
                var uri = new Uri(@"Resource/White.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                check1 = true;
            }

        }

        public void Click_SignIn(object sender, RoutedEventArgs e)
        {
            Employee? employee = null;
            using (TRPOKyrsoContext kyrso = new TRPOKyrsoContext())
            {
                if (TextBox_Password.Password != "" && TextBox_Login.Text != "")
                {
                    string password = TextBox_Password.Password;

                    employee = kyrso.Employees
                        .Where(b => b.Login == TextBox_Login.Text && b.Passwordemployee == password).FirstOrDefault();
                    if (employee != null)
                    {
                        string speciality = kyrso.Specialities
                            .FirstOrDefault(s => s.Idspeciality == employee.Fkspeciality).Speciality1;
                        if (speciality == "Администратор")
                        {
                            ResourceManager.CurrentUser = employee;
                            new TechnologyWindowAdmin().Show();
                            this.Close();
                        }
                        else if (speciality == "Технический специалист")
                        {
                            ResourceManager.CurrentUser = employee;
                            new BreakingWindowTS().Show();
                            this.Close();
                            if (ResourceManager.Notice == true)
                            {
                                if (employee.Surnameemployee ==
                                    ResourceManager.NewMending.FkemployeesNavigation.Surnameemployee)
                                {

                                    new NoticeWindow().ShowDialog();


                                }
                            }
                        }

                    }
                    else
                    {
                        new MassegeAuthorization().ShowDialog();

                    }
                }
                else
                {
                    new MassegeNull().ShowDialog();
                }


            }
        }
    }
}
