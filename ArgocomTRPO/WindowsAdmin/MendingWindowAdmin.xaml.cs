using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ArgocomTRPO.DB;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ArgocomTRPO.WindowsAdmin;

public partial class MendingWindowAdmin : Window
{
    TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;

    public MendingWindowAdmin()
    {
        InitializeComponent();
        DataGrid_Mending.ItemsSource = trpoKyrsoContext.Mendings.ToList();
        var TypeList = trpoKyrsoContext.Employees.Where(a => a.Fkspeciality == 2).ToList();
        ComboBoxSelection.ItemsSource = TypeList;
        if (ResourceManager.Notice == true)
        {
            var mendingMaxId = trpoKyrsoContext.Mendings.Max(t => t.Idmending);
            foreach (var mending in trpoKyrsoContext.Mendings.ToList())
            {
                if (mending.Idmending == mendingMaxId )
                {
                    ResourceManager.NewMending = mending;
                }
            }
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

    public void Click_Breaking(object sender, RoutedEventArgs e)
    {
        BreakingWindowAdmin breakingWindow = new BreakingWindowAdmin();
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

        var selectTypeMending = ComboBoxSelection.SelectedItem as Employee;
        DataGrid_Mending.ItemsSource = trpoKyrsoContext.Mendings
            .Where(a => a.Fkemployees == selectTypeMending.Idemployees).ToList();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (ComboBoxSelection.SelectedItem != null)
        {
            DataGrid_Mending.ItemsSource = trpoKyrsoContext.Mendings.ToList();
            ComboBoxSelection.ItemsSource = null;
            var TypeList = trpoKyrsoContext.Employees.Where(a => a.Fkspeciality == 2).ToList();
            ComboBoxSelection.ItemsSource = TypeList;
        }
    }

    private void TextBox_Search_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        DataGrid_Mending.ItemsSource = trpoKyrsoContext.Mendings.Where(a => a.FkbreakingNavigation.FktechnologyNavigation.FktypetechnologyNavigation.Typetechnology1.StartsWith(TextBox_Search.Text)).ToList();

    }

    private void Click_Report(object sender, RoutedEventArgs e)
    {
        PdfPTable table = new PdfPTable(DataGrid_Mending.Columns.Count);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 0, 0, 42, 35);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string ttf =
                System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE,
                iTextSharp.text.Font.NORMAL);
            Font font1 = new iTextSharp.text.Font(baseFont, 24, iTextSharp.text.Font.NORMAL);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            PdfWriter.GetInstance(doc, new FileStream($"{path}\\ReportMending.pdf", FileMode.Create));
            doc.Open();

            PdfPCell headerpdf = new PdfPCell(new Phrase("Отчет ", font1));
            PdfPCell headerpdf1 = new PdfPCell(new Phrase("Ремонта в организации", font1));
            PdfPCell cell1 = new PdfPCell(new Phrase(" "));
            headerpdf.Border = 0;
            headerpdf.VerticalAlignment = 1;

            headerpdf.HorizontalAlignment = 1;
            headerpdf.Colspan = 5;
            headerpdf1.Border = 0;
            headerpdf1.HorizontalAlignment = 1;
            headerpdf1.Colspan = 5;
            table.AddCell(headerpdf);
            table.AddCell(headerpdf1);
            table.HeaderRows = 1;
            float[] widths = new float[] { 130f, 200f, 300f, 200f, 160f };
            table.SetWidths(widths);

            for (int j = 0; j < DataGrid_Mending.Columns.Count; j++)
            {
                table.AddCell(new Phrase(DataGrid_Mending.Columns[j].Header.ToString(), font));
            }

            table.HeaderRows = 1;

            IQueryable Data = DataGrid_Mending.ItemsSource.AsQueryable();
            if (Data != null)
            {
                foreach (var item in Data)
                {
                    DataGridRow row = DataGrid_Mending.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = ResourceManager.FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < DataGrid_Mending.Columns.Count; ++i)
                        {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt != null)
                            {
                                 table.AddCell(new Phrase(txt.Text, font));
                                
                            }
                        }
                        
                    }
                }

                table.HeaderRows = 1;
                var today = DateOnly.FromDateTime(DateTime.Today).ToString("d");
                PdfPCell employee = new PdfPCell(new Phrase("Козлова", font1));
                employee.HorizontalAlignment = 2;
                employee.Border = 0;
                table.AddCell(employee);
                table.AddCell(today);

                doc.Add(table);
                doc.Close();
                MessageBox.Show($"Отчет создан по пути {path}" + @"\" + "ReportMending.pdf");
            }
    }

    private void DataGrid_Mending_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ResourceManager.ChangeM = true;
        var item = DataGrid_Mending.SelectedItem as Mending;
        ResourceManager.ChangeMending = item;
        new AddMendingWindowAdmin().Show();
        this.Close();
    }
}