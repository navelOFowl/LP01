using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StroyMat
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        string path;
        bool IsCreate = false;
        List<MaterialSupplier> MS = DatabaseClass.DB.MaterialSupplier.ToList();
        public EditWindow()
        {
            InitializeComponent();
            CbMaterialType.ItemsSource = DatabaseClass.DB.MaterialType.ToList();
            CbMaterialType.SelectedValuePath = "ID";
            CbMaterialType.DisplayMemberPath = "Title";

            LbSupliers.ItemsSource = DatabaseClass.DB.Supplier.ToList();
            LbSupliers.SelectedValuePath = "ID";
            LbSupliers.DisplayMemberPath = "Title";
            IsCreate = true;
        }
        Material MaterialEdit = new Material();
        public EditWindow(Material editImport)
        {
            InitializeComponent();
            MaterialEdit = editImport;

            CbMaterialType.ItemsSource = DatabaseClass.DB.MaterialType.ToList();
            CbMaterialType.SelectedValuePath = "ID";
            CbMaterialType.DisplayMemberPath = "Title";

            TbTitle.Text = MaterialEdit.Title;
            TbCountInStock.Text = MaterialEdit.CountInStock.ToString();
            TbCountInPack.Text = MaterialEdit.CountInPack.ToString();
            TbUnit.Text = MaterialEdit.Unit.ToString();
            TbCost.Text = MaterialEdit.Cost.ToString();
            TbMinCount.Text = MaterialEdit.MinCount.ToString();

            if (MaterialEdit.Image != null)
            {
                BitmapImage BI = new BitmapImage(new Uri(MaterialEdit.Image, UriKind.RelativeOrAbsolute));
                MaterialImage.Source = BI;
            }

            LbSupliers.ItemsSource = DatabaseClass.DB.Supplier.ToList();
            LbSupliers.SelectedValuePath = "ID";
            LbSupliers.DisplayMemberPath = "Title";

            List<MaterialSupplier> materialSuppliers = MS.Where(x => x.ID == MaterialEdit.ID).ToList();
            foreach (Supplier Sup in LbSupliers.Items)
            {
                if(materialSuppliers.FirstOrDefault(x => x.ID == Sup.ID) != null)
                {
                    LbSupliers.SelectedItems.Add(Sup);
                }
            }
        }

        private void ButtEditImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.ShowDialog();
            path = OFD.FileName;
            int n = path.IndexOf("materials");
            path = path.Substring(n);
            var img = new BitmapImage(new Uri(path));
            MaterialImage.Source = img;
        }

        private void ButtUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MaterialEdit.
            }
            catch
            {
                MessageBox.Show("Не удалось записать данные, повторите попытку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
