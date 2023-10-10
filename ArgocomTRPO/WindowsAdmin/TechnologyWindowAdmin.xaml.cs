using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ArgocomTRPO.DB;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ArgocomTRPO.WindowsAdmin
{
    /// <summary>
    /// Логика взаимодействия для TechnologyWindowAdmin.xaml
    /// </summary>
    public partial class TechnologyWindowAdmin : Window
    {
        TRPOKyrsoContext trpoKyrsoContext = ResourceManager.trpoKyrsoContext;

        public TechnologyWindowAdmin()
        {
            InitializeComponent();
            Grid_Technology.ItemsSource = trpoKyrsoContext.Technologies.ToList();
            var TypeList = trpoKyrsoContext.Departments.ToList();
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
            BreakingWindowAdmin breakingWindow = new BreakingWindowAdmin();
            breakingWindow.Show();
            this.Close();
        }

        public void Click_AddTechnology(object sender, RoutedEventArgs e)
        {
            ResourceManager.ChangeT = false;
            AddTechnologyWindowAdmin addTechnologyWindow = new AddTechnologyWindowAdmin();
            addTechnologyWindow.Show();
            this.Close();
        }

        public void Click_Account(object sender, RoutedEventArgs e)
        {
            AccountWindow accountWindow = new AccountWindow();
            accountWindow.ShowDialog();
        }

        

       

        public void Click_Delete(object sender, RoutedEventArgs e)
        {
            var selectTechnology = Grid_Technology.SelectedItem as Technology;
            if (selectTechnology != null)
            {
                var breakingDelete = trpoKyrsoContext.Breakings
                    .Where(x => x.Fktechnology == selectTechnology.Idtechnology)
                    .ToList();
                foreach (var breaking in breakingDelete)
                {
                    var mendingDelete = trpoKyrsoContext.Mendings.Where(x => x.Fkbreaking == breaking.Idbreaking)
                        .ToList();
                    foreach (var mending in mendingDelete)
                    {
                        trpoKyrsoContext.Mendings.Remove(mending);
                        trpoKyrsoContext.SaveChanges();
                    }

                }

                trpoKyrsoContext.Breakings.RemoveRange(breakingDelete);
                trpoKyrsoContext.SaveChanges();
                trpoKyrsoContext.Technologies.Remove(selectTechnology);
                trpoKyrsoContext.SaveChanges();
                if (ComboBoxSelection.SelectedItem != null)
                {
                    var selectDepartment = ComboBoxSelection.SelectedItem as Department;
                    Grid_Technology.ItemsSource = trpoKyrsoContext.Technologies
                        .Where(a => a.Fkdepartment == selectDepartment.Iddepartment).ToList();
                }
                else
                {
                    var TechnologyList = trpoKyrsoContext.Technologies.ToList();
                    Grid_Technology.ItemsSource = TechnologyList;
                }
            }


        }

        private void ComboBoxSelection_OnSelected(object sender, RoutedEventArgs e)
        {
            if (ComboBoxSelection.SelectedItem == null)
            {
                return;
            }

            var selectDepartment = ComboBoxSelection.SelectedItem as Department;
            Grid_Technology.ItemsSource = trpoKyrsoContext.Technologies
                .Where(a => a.Fkdepartment == selectDepartment.Iddepartment).ToList();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (ComboBoxSelection.SelectedItem != null)
            {
                Grid_Technology.ItemsSource = trpoKyrsoContext.Technologies.ToList();
                ComboBoxSelection.ItemsSource = null;
                var TypeList = trpoKyrsoContext.Departments.ToList();
                ComboBoxSelection.ItemsSource = TypeList;
            }
        }


        public void Click_Broken(object sender, RoutedEventArgs e)
        {
            ResourceManager.ChangeB = false;
           var selectTechnology = Grid_Technology.SelectedItem as Technology;

            if (selectTechnology != null)
            {
                if (selectTechnology.Fkstatus == 2)
                {
                    trpoKyrsoContext.Technologies.First(a => a.Idtechnology == selectTechnology.Idtechnology).Fkstatus = 1;
                    trpoKyrsoContext.SaveChanges();
                    var today = DateOnly.FromDateTime(DateTime.Today);
                    Breaking breaking = new Breaking();
                    breaking.Datebreaking = today;
                    breaking.Fktechnology = selectTechnology.Idtechnology;
                    breaking.Fktypebreaking = 1;
                    breaking.Description = "Не работает";
                    trpoKyrsoContext.Breakings.Add(breaking);
                    trpoKyrsoContext.SaveChanges();
                    Grid_Technology.ItemsSource = trpoKyrsoContext.Technologies.ToList();
                    new BrokenWindowAdmin().Show();
                    this.Close();

                }
            }
        }

        private void TextBox_Search_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Grid_Technology.ItemsSource = trpoKyrsoContext.Technologies
                .Where(a => a.FktypetechnologyNavigation.Typetechnology1.StartsWith(TextBox_Search.Text)).ToList();

        }

        private void Grid_Technology_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ResourceManager.ChangeT = true;
            var item = Grid_Technology.SelectedItem as Technology;
            ResourceManager.ChangeTechnology = item;
            new AddTechnologyWindowAdmin().Show();
            this.Close();
        }

        private void Click_Report(object sender, RoutedEventArgs e)
        {

            PdfPTable table = new PdfPTable(Grid_Technology.Columns.Count);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 0, 0, 42, 0);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string ttf =
                System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE,
                iTextSharp.text.Font.NORMAL);
            Font font1 = new iTextSharp.text.Font(baseFont, 24, iTextSharp.text.Font.NORMAL);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            PdfWriter.GetInstance(doc, new FileStream($"{path}\\Report.pdf", FileMode.Create));
            doc.Open();

            PdfPCell headerpdf = new PdfPCell(new Phrase("Отчет ", font1));
            PdfPCell headerpdf1 = new PdfPCell(new Phrase("Техника в организации", font1));
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
            float[] widths = new float[] { 130f, 200f, 400f, 100f, 200f };

            table.SetWidths(widths);

            for (int j = 0; j < Grid_Technology.Columns.Count; j++)
            {
                table.AddCell(new Phrase(Grid_Technology.Columns[j].Header.ToString(), font));
            }

            table.HeaderRows = 1;

            IQueryable Data = Grid_Technology.ItemsSource.AsQueryable();
            if (Data != null)
            {
                foreach (var item in Data)
                {
                    DataGridRow row = Grid_Technology.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                       DataGridCellsPresenter presenter = ResourceManager.FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < Grid_Technology.Columns.Count; ++i)
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

                
                var today = DateOnly.FromDateTime(DateTime.Today).ToString("d");
                PdfPCell employee = new PdfPCell(new Phrase(ResourceManager.CurrentUser.Surnameemployee, font1));
                employee.HorizontalAlignment = 2;
                employee.Border = 0;
                employee.Border = 0;
                table.AddCell(employee);
                //table.AddCell(today);

                doc.Add(table);
                doc.Add(employee);
                doc.Close();
                MessageBox.Show($"Отчет создан по пути {path}" + @"\" + "Report.pdf");
            }
        }
    }
}
    

