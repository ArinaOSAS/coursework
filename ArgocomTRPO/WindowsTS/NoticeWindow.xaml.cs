using System.Windows;
using System.Windows.Input;
using ArgocomTRPO.DB;

namespace ArgocomTRPO.WindowsTS;

public partial class NoticeWindow : Window
{
    TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;
    public NoticeWindow()
    {
        
        InitializeComponent();
        if (ResourceManager.NewMending != null)
        {
            TextBlock_Type.Text = ResourceManager.NewMending.FkbreakingNavigation.FktechnologyNavigation
                .FktypetechnologyNavigation.Typetechnology1;
            TextBlock_Departament.Text = ResourceManager.NewMending.FkdepartmentNavigation.Numberdepartment;
            TextBlock_Date.Text = ResourceManager.NewMending.Datemending.ToString();
            ResourceManager.Notice = false;
        }
        
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
}