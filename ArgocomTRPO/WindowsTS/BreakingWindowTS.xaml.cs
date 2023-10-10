using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArgocomTRPO.DB;
using ArgocomTRPO.WindowsAdmin;

namespace ArgocomTRPO.WindowsTS;

public partial class BreakingWindowTS : Window
{
    TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;
    public BreakingWindowTS()
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

    public void Click_Mending(object sender, RoutedEventArgs e)
    {
        MendingWindowTS mendingWindow = new MendingWindowTS();
        mendingWindow.Show();
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
}