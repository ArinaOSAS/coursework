using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArgocomTRPO.DB;

namespace ArgocomTRPO.WindowsAdmin;

public partial class BreakingWindowAdmin : Window
{
    TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;

    public BreakingWindowAdmin()
    {
        InitializeComponent();
        DataGrid_Breaking.ItemsSource = trpoKyrsoContext.Breakings.ToList();
        var TypeList = trpoKyrsoContext.Typebreakings.ToList();
        ComboBoxSelection.ItemsSource = TypeList;
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

    public void Click_Mending(object sender, RoutedEventArgs e)
    {
        MendingWindowAdmin mendingWindow = new MendingWindowAdmin();
        mendingWindow.Show();
        this.Close();
    }

    bool a = false;
    public void Click_AddMending(object sender, RoutedEventArgs e)
    {
        ResourceManager.ChangeM = false;
        var selectMending = DataGrid_Breaking.SelectedItem as Breaking ;
        if (selectMending != null)
        {
            foreach (var mendingFk in trpoKyrsoContext.Mendings.ToList())
            {
                if (selectMending.Idbreaking == mendingFk.Fkbreaking )
                {
                    a = true;
                }
                
            }

            if (a == false)
            {
                ResourceManager.Notice = true;
                var today = DateOnly.FromDateTime(DateTime.Today);
                Mending mending = new Mending();
                mending.Datemending = today;
                mending.Fkemployees = 1;
                mending.Fkbreaking = selectMending.Idbreaking;
                mending.Fkdepartment = 1;
        
                trpoKyrsoContext.Mendings.Add(mending);
                trpoKyrsoContext.SaveChanges();
                ResourceManager.NewMending = mending;
                AddMendingWindowAdmin addMendingWindow = new AddMendingWindowAdmin();
                addMendingWindow.Show();
                this.Close();
            }
           
            
        }
    }

    public void Click_Diagram(object sender, RoutedEventArgs e)
    {
        DiagramWindowAdmin diagram = new DiagramWindowAdmin();
        diagram.Show();
        this.Close();
    }

    public void Click_Account(object sender, RoutedEventArgs e)
    {
        AccountWindow account = new AccountWindow();
        account.ShowDialog();
    }
    

    private void ComboBoxSelection_OnSelected(object sender, RoutedEventArgs e)
    {
        if (ComboBoxSelection.SelectedItem == null)
        {
            return;
        }

        var selectTypebreaking = ComboBoxSelection.SelectedItem as Typebreaking;
        DataGrid_Breaking.ItemsSource = trpoKyrsoContext.Breakings
            .Where(a => a.Fktypebreaking == selectTypebreaking.Idtypebreaking).ToList();


    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (ComboBoxSelection.SelectedItem != null)
        {
            DataGrid_Breaking.ItemsSource = new TRPOKyrsoContext().Breakings.ToList();
            ComboBoxSelection.ItemsSource = null;
            var TypeList = trpoKyrsoContext.Typebreakings.ToList();
            ComboBoxSelection.ItemsSource = TypeList;
        }
    }

    private void TextBox_Search_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        DataGrid_Breaking.ItemsSource = trpoKyrsoContext.Breakings.Where(a => a.FktechnologyNavigation.FktypetechnologyNavigation.Typetechnology1.StartsWith(TextBox_Search.Text)).ToList();

    }

    private void DataGrid_Breaking_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ResourceManager.ChangeB = true;
        var item = DataGrid_Breaking.SelectedItem as Breaking;
        ResourceManager.ChangeBreaking = item;
        new BrokenWindowAdmin().Show();
        this.Close();
    }
}