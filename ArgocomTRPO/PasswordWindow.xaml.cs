using System.Linq;
using System.Windows;
using System.Windows.Input;
using ArgocomTRPO.DB;

namespace ArgocomTRPO;

public partial class PasswordWindow : Window
{
    TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;
    public PasswordWindow()
    {
        InitializeComponent();
        
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
    string password = "";

    public void Click_Account(object sender, RoutedEventArgs e)
    {
        if (TextBox_NewPassword.Password != "" && TextBox_CurrentPassword.Password != "")
        {
            if (ResourceManager.CurrentUser.Passwordemployee == TextBox_CurrentPassword.Password)
            {
                foreach (var Current in trpoKyrsoContext.Employees.ToList())
                {
                    if (Current.Passwordemployee == ResourceManager.CurrentUser.Passwordemployee)
                    {
                        Current.Passwordemployee = TextBox_NewPassword.Password;
                        trpoKyrsoContext.SaveChanges();
                        this.Close();
                    }
                }
            }
            else
            {
                new MassegePassword().Show();
            }
        }
        else
        {
            new MassegeNull().Show();
        }
    }
}