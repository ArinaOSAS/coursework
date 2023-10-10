using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace ArgocomTRPO.DB
{
    public static class ResourceManager
    {
        public static TRPOKyrsoContext trpoKyrsoContext = new TRPOKyrsoContext();
        public static Employee CurrentUser { get; set; }

        public static Mending NewMending { get; set; }
        public static Technology ChangeTechnology { get; set; }
        public static Breaking ChangeBreaking { get; set; }
        public static Mending ChangeMending { get; set; }
        public static bool  ChangeT { get; set; }
        public static bool  ChangeB { get; set; }
        public static bool  ChangeM { get; set; }

        public static bool Notice { get; set; }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
            where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }
    }
}
