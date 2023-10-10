using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using ArgocomTRPO.DB;

namespace ArgocomTRPO;

public partial class AccountWindow : Window
{
   TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;
    public AccountWindow()
    {
        InitializeComponent();
        if (ResourceManager.CurrentUser != null)
        {
            if (ResourceManager.CurrentUser.Patronymicemployee != null)
            {
                TextBlock_FIO.Text = ResourceManager.CurrentUser.Surnameemployee + " "
                    + ResourceManager.CurrentUser.Nameemployee.Substring(0,1) + "."
                    + ResourceManager.CurrentUser.Patronymicemployee.Substring(0,1)  + ". ";
            }
            else
            {
                TextBlock_FIO.Text = ResourceManager.CurrentUser.Surnameemployee + " "
                    + ResourceManager.CurrentUser.Nameemployee.Substring(0,1) + ".";
            }
            

            TextBlock_Number.Text = ResourceManager.CurrentUser.Phonenumber;
            TextBlock_Speciality.Text = ResourceManager.CurrentUser.FkspecialityNavigation.Speciality1;
            TextBlock_Login.Text = ResourceManager.CurrentUser.Login;  
        }
        
        //this.OnClosed + Closing();
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
    public void Click_Exit(object sender, RoutedEventArgs e)
    {
        AuthorizationWindow authorizationWindow = new AuthorizationWindow();
        authorizationWindow.Show();
        List<Window> listWindows = new List<Window>();
        foreach (Window window in App.Current.Windows)
        {
            listWindows.Add(window);
        }
        foreach (Window window in listWindows)
        {
            if (window is AuthorizationWindow authorization)
            {
                
            }
            else
            {
                window.Close();
            }
        }

        ResourceManager.CurrentUser = null;
    }
    
    public void Click_Password(object sender, RoutedEventArgs e)
    {
        PasswordWindow passwordWindow = new PasswordWindow();
        passwordWindow.ShowDialog();
    }
    
   
}