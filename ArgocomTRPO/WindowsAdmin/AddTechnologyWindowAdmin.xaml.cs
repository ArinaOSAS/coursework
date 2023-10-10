using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ArgocomTRPO.DB;

namespace ArgocomTRPO.WindowsAdmin;

public partial class AddTechnologyWindowAdmin : Window
{
   TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;
    
    public AddTechnologyWindowAdmin()
    {
        InitializeComponent();
        var TypeList = trpoKyrsoContext.Typetechnologies.ToList();
        ComboBox_Typetechnology.ItemsSource = TypeList;
        var DepartmentList = trpoKyrsoContext.Departments.ToList();
        ComboBox_Department.ItemsSource = DepartmentList;
        if (ResourceManager.ChangeT == true)
        {
            TextBox_NumberTechnology.IsReadOnly = true;
            ComboBox_Typetechnology.IsReadOnly = true;
            TextBox_NumberTechnology.Text = ResourceManager.ChangeTechnology.Uniquecode.ToString();
            TextBox_Characteristics.Text = ResourceManager.ChangeTechnology.Сharacteristic;
            ComboBox_Typetechnology.Text =
                ResourceManager.ChangeTechnology.FktypetechnologyNavigation.Typetechnology1;
            ComboBox_Department.Text = ResourceManager.ChangeTechnology.FkdepartmentNavigation.Numberdepartment;
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
    public void Click_Technology(object sender, RoutedEventArgs e)
    {
        TechnologyWindowAdmin technologyWindow = new TechnologyWindowAdmin();
        technologyWindow.Show();
        this.Close();
    }
    public void Click_AddTechnology(object sender, RoutedEventArgs e)
    {
        if (ResourceManager.ChangeT == false)
        {
            if (TextBox_NumberTechnology.Text != "" && TextBox_Characteristics.Text != "" && ComboBox_Typetechnology.SelectedItem != null && ComboBox_Department.SelectedItem != null )
            {
                Technology technology = new Technology();
                technology.Uniquecode = int.Parse(TextBox_NumberTechnology.Text);
                technology.Сharacteristic = TextBox_Characteristics.Text;
                technology.Fkstatus = 2;
                technology.Fkdepartment = ((Department ) ComboBox_Department.SelectedItem).Iddepartment;
                technology.Fktypetechnology = ((Typetechnology ) ComboBox_Typetechnology.SelectedItem).Idtypetechnology;

                trpoKyrsoContext.Technologies.Add(technology);
                trpoKyrsoContext.SaveChanges();

                TechnologyWindowAdmin technologyWindow = new TechnologyWindowAdmin();
                technologyWindow.Show();
                this.Close();
            }
            else
            {
                new MassegeNull().Show();
            }
        }
        else
        {
            if (TextBox_Characteristics.Text != "")
            {
                foreach (var technology in trpoKyrsoContext.Technologies.ToList())
                {
                    if (technology.Uniquecode == int.Parse(TextBox_NumberTechnology.Text))
                    {
                        technology.Сharacteristic = TextBox_Characteristics.Text;
                        technology.Fkdepartment = ((Department)ComboBox_Department.SelectedItem).Iddepartment;
                        technology.Fktypetechnology =
                            ((Typetechnology)ComboBox_Typetechnology.SelectedItem).Idtypetechnology;
                        
                        trpoKyrsoContext.SaveChanges();
                        TechnologyWindowAdmin technologyWindow = new TechnologyWindowAdmin();
                        technologyWindow.Show();
                        this.Close();
                    }

                }
            }
            else
            {
                new MassegeNull().Show();
            }
            
        }
        
    }
}