using System.Linq;
using System.Windows;
using System.Windows.Input;
using ArgocomTRPO.DB;

namespace ArgocomTRPO.WindowsAdmin;

public partial class AddMendingWindowAdmin : Window
{
    TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;
    
    public AddMendingWindowAdmin()
    {
        InitializeComponent();
        var DepartmentList = trpoKyrsoContext.Departments.Where(x => x.Namedepartment != "Мастерская").ToList();
        ComboBox_Department.ItemsSource = DepartmentList;
        var EngineerList = trpoKyrsoContext.Employees.Where(x => x.FkspecialityNavigation.Speciality1 == "Технический специалист").ToList();
        ComboBox_Engineer.ItemsSource = EngineerList;
        if (ResourceManager.ChangeM == true)
        {
            ComboBox_Engineer.Text = ResourceManager.ChangeMending.FkemployeesNavigation.Surnameemployee;
            ComboBox_Department.Text = ResourceManager.ChangeMending.FkdepartmentNavigation.Numberdepartment;
        }
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
    public void Click_Cancel(object sender, RoutedEventArgs e)
    {
        if (ResourceManager.ChangeM == false)
        {
            var mendingMaxId = trpoKyrsoContext.Mendings.Max(t => t.Idmending);
            foreach (var mending in trpoKyrsoContext.Mendings.ToList())
            {
                if (mending.Idmending == mendingMaxId )
                {
                    trpoKyrsoContext.Mendings.Remove(mending);
                    trpoKyrsoContext.SaveChanges();
                    new BreakingWindowAdmin().Show();
                    this.Close();
                    
                }
            }
        }
        else
        {
            new MendingWindowAdmin().Show();
            this.Close();
        }
        
    }
    public void Click_AddMending(object sender, RoutedEventArgs e)
    {

        if (ResourceManager.ChangeM == false)
        {
            if (ComboBox_Engineer.SelectedItem != null && ComboBox_Department.SelectedItem != null)
            {
                var mendingMaxId = trpoKyrsoContext.Mendings.Max(t => t.Idmending);
                foreach (var mending in trpoKyrsoContext.Mendings.ToList())
                {
                    if (mending.Idmending == mendingMaxId)
                    {
                        ResourceManager.Notice = true;
                        mending.Fkemployees = ((Employee)ComboBox_Engineer.SelectedItem).Idemployees;
                        mending.Fkdepartment = ((Department)ComboBox_Department.SelectedItem).Iddepartment;
                        trpoKyrsoContext.SaveChanges();
                        new BreakingWindowAdmin().Show();
                        this.Close();
                    }
                }
            }
            else
            {
                new MassegeNull().ShowDialog();
            }
        }
        else
        {

            foreach (var mending in trpoKyrsoContext.Mendings.ToList())
            {
                if (mending.Idmending == ResourceManager.ChangeMending.Idmending)
                {
                    mending.Fkdepartment = ((Department)ComboBox_Department.SelectedItem).Iddepartment;
                    mending.Fkemployees = ((Employee)ComboBox_Engineer.SelectedItem).Idemployees;
                    trpoKyrsoContext.SaveChanges();
                    new MendingWindowAdmin().Show();
                    this.Close();

                }
            }
        }
        
       
    }
}