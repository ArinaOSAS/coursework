using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArgocomTRPO.DB;
using ArgocomTRPO.WindowsTS;

namespace ArgocomTRPO;

public partial class MendingWindowTS : Window
{
    TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;

    public MendingWindowTS()
    {
        InitializeComponent();
        DataGrid_Mending.ItemsSource = trpoKyrsoContext.Mendings.Where(a => a.FkemployeesNavigation.Surnameemployee == ResourceManager.CurrentUser.Surnameemployee).ToList();
        var TypeList = trpoKyrsoContext.Mendings.Where(d => d.FkemployeesNavigation.Surnameemployee == ResourceManager.CurrentUser.Surnameemployee).ToList();
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

    public void Click_Breaking(object sender, RoutedEventArgs e)
    {
        BreakingWindowTS breakingWindow = new BreakingWindowTS();
        breakingWindow.Show();
        this.Close();
    }

    public void Click_Account(object sender, RoutedEventArgs e)
    {
        AccountWindow accountWindow = new AccountWindow();
        accountWindow.ShowDialog();
    }

    private void ComboBoxSelection_OnSelected(object sender, RoutedEventArgs e)
    {
        if (ComboBoxSelection.SelectedItem == null)
        {
            return;
        }
        var selectDateMending = ComboBoxSelection.SelectedItem as Mending;
        DataGrid_Mending.ItemsSource = trpoKyrsoContext.Mendings.Where(a => a.Datemending == selectDateMending.Datemending &&  a.FkemployeesNavigation.Surnameemployee == ResourceManager.CurrentUser.Surnameemployee ).ToList();


    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (ComboBoxSelection.SelectedItem != null)
        {
            DataGrid_Mending.ItemsSource = trpoKyrsoContext.Mendings.Where(a => a.FkemployeesNavigation.Surnameemployee == ResourceManager.CurrentUser.Surnameemployee).ToList();
            ComboBoxSelection.ItemsSource = null;
            var TypeList = trpoKyrsoContext.Mendings.ToList();
            ComboBoxSelection.ItemsSource = TypeList;
        }
    }

    private void Click_Change(object sender, RoutedEventArgs e)
    {
        var selectMending = DataGrid_Mending.SelectedItem as Mending;
        if (selectMending != null)
        {
            if (selectMending.FkbreakingNavigation.FktechnologyNavigation.Fkstatus == 1)
            {
                var idTechnology = selectMending.FkbreakingNavigation.Fktechnology;
                trpoKyrsoContext.Technologies.First(t => t.Idtechnology == idTechnology).Fkstatus = 2;
                trpoKyrsoContext.SaveChanges();
            
                var breakingDelete = trpoKyrsoContext.Breakings.Where(x => x.Fktechnology == idTechnology).ToList();
                foreach (var breaking in breakingDelete)
                {
                    var mendingDelete = trpoKyrsoContext.Mendings.Where(x => x.Fkbreaking == breaking.Idbreaking).ToList();
                    foreach (var mending in mendingDelete)
                    {
                        trpoKyrsoContext.Mendings.Remove(mending);
                        trpoKyrsoContext.SaveChanges();
                    }
            
                }
                trpoKyrsoContext.Breakings.RemoveRange(breakingDelete);
                trpoKyrsoContext.SaveChanges();
                DataGrid_Mending.ItemsSource = trpoKyrsoContext.Mendings.Where(a => a.FkemployeesNavigation.Surnameemployee == ResourceManager.CurrentUser.Surnameemployee).ToList();

            }
        }
    }

    private void TextBox_Search_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        DataGrid_Mending.ItemsSource = trpoKyrsoContext.Mendings.Where(a => a.FkbreakingNavigation.FktechnologyNavigation.FktypetechnologyNavigation.Typetechnology1.StartsWith(TextBox_Search.Text) 
                                                                            && a.FkemployeesNavigation.Surnameemployee == ResourceManager.CurrentUser.Surnameemployee).ToList();

    }
}