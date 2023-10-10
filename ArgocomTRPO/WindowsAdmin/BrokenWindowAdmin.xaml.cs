using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ArgocomTRPO.DB;

namespace ArgocomTRPO.WindowsAdmin;

public partial class BrokenWindowAdmin : Window
{
    TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;
    
    public BrokenWindowAdmin()
    {
        InitializeComponent();
        var TypeList = trpoKyrsoContext.Typebreakings.ToList();
        ComboBox_TypeBreaking.ItemsSource = TypeList;
        if (ResourceManager.ChangeB == true)
        {
            ComboBox_TypeBreaking.Text = ResourceManager.ChangeBreaking.FktypebreakingNavigation.Typebreaking1;
            TextBox_DescriptionBreaking.Text = ResourceManager.ChangeBreaking.Description;
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

    public void Click_Add(object sender, RoutedEventArgs e)
    {
        if (ResourceManager.ChangeB == false)
        {
            if (ComboBox_TypeBreaking.SelectedItem != null && TextBox_DescriptionBreaking.Text != "")
            {
                var breakingMaxId = trpoKyrsoContext.Breakings.Max(a => a.Idbreaking);
                foreach (var breaking in trpoKyrsoContext.Breakings.ToList())
                {
                    if (breaking.Idbreaking == breakingMaxId)
                    {
                        breaking.Fktypebreaking = ((Typebreaking)ComboBox_TypeBreaking.SelectedItem).Idtypebreaking;
                        breaking.Description = TextBox_DescriptionBreaking.Text;
                        trpoKyrsoContext.SaveChanges();
                        new TechnologyWindowAdmin().Show();
                        this.Close();
                    }
                }
            }
            else
            {
                new MassegeNull().Show();
            }

        }
        else
        {
            if (TextBox_DescriptionBreaking.Text != "")
            {
                foreach (var breaking in trpoKyrsoContext.Breakings.ToList())
                {
                    if (breaking.Idbreaking == ResourceManager.ChangeBreaking.Idbreaking)
                    {
                        breaking.Fktypebreaking = ((Typebreaking)ComboBox_TypeBreaking.SelectedItem).Idtypebreaking;
                        breaking.Description = TextBox_DescriptionBreaking.Text;
                        trpoKyrsoContext.SaveChanges();
                        new BreakingWindowAdmin().Show();
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

    public void Click_Cancel(object sender, RoutedEventArgs e)
    {
        if (ResourceManager.ChangeB == false)
        {
            var breakingMaxId = trpoKyrsoContext.Breakings.Max(a => a.Idbreaking);
            foreach (var breaking in trpoKyrsoContext.Breakings.ToList())
            {
                if (breaking.Idbreaking == breakingMaxId )
                {
                    trpoKyrsoContext.Technologies.First(a => a.Idtechnology == breaking.Fktechnology).Fkstatus = 2;
                    trpoKyrsoContext.Breakings.Remove(breaking);
                    trpoKyrsoContext.SaveChanges();
                    new TechnologyWindowAdmin().Show();
                    this.Close();
                    
                }
            }
        }
        else
        {
            new BreakingWindowAdmin().Show();
            this.Close();
        }
       
       
    }
}