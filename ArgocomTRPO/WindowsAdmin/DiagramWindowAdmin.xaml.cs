using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArgocomTRPO.DB;

namespace ArgocomTRPO.WindowsAdmin;

public partial class DiagramWindowAdmin : Window
{
    TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;
    private Breaking _breaking;
    public DiagramWindowAdmin()
    {
        InitializeComponent();

        var DateList = trpoKyrsoContext.Breakings.Select(a => a.Datebreaking).Distinct().ToList();
        ComboBox_FromDate.ItemsSource = DateList;
        ComboBox_ToDate.ItemsSource = DateList;
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

    public void Click_Back(object sender, RoutedEventArgs e)
    {
        BreakingWindowAdmin breakingWindow = new BreakingWindowAdmin();
        breakingWindow.Show();
        this.Close();
    }
    
    private void ComboBox_FromDate_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectFromDate = ComboBox_FromDate.SelectedItem as DateOnly?;
        DiagramVM.fromDate = selectFromDate;
        
    }

    private void ComboBox_ToDate_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectToDate = ComboBox_ToDate.SelectedItem as DateOnly?;
        DiagramVM.toDate = selectToDate;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (DiagramVM.fromDate == null && DiagramVM.toDate == null)
        {
            return;
        }
        DataContext = new DiagramVM();
    }
}