using System.Windows;
using System.Windows.Input;

namespace ArgocomTRPO;

public partial class MassegePassword : Window
{
    public MassegePassword()
    {
        InitializeComponent();
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