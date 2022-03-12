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

            CbSupplier.ItemsSource = DatabaseClass.DB.Supplier.ToList();
            CbSupplier.SelectedValuePath = "ID";
            CbSupplier.DisplayMemberPath = "Title";
            IsCreate = true;
            LbSupliers.SelectedValuePath = "ID";
            LbSupliers.DisplayMemberPath = "Title";
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

            CbSupplier.ItemsSource = DatabaseClass.DB.Supplier.ToList();
            CbSupplier.SelectedValuePath = "ID";
            CbSupplier.DisplayMemberPath = "Title";
            LbSupliers.SelectedValuePath = "ID";
            LbSupliers.DisplayMemberPath = "Title";
        }

        private void ButtSupplierAdd_Click(object sender, RoutedEventArgs e)
        {
            List<Supplier> sup = DatabaseClass.DB.Supplier.ToList();
            LbSupliers.Items.Add(sup.FirstOrDefault(x => x.ID == CbSupplier.SelectedIndex + 1));
        }

        private void ButtSupplierRemove_Click(object sender, RoutedEventArgs e)
        {
            LbSupliers.Items.Remove(LbSupliers.SelectedItem);
        }

        private void ButtEditImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                path = OFD.FileName;
                int n = path.IndexOf("materials");
                path = path.Substring(n);
                BitmapImage img = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                MaterialImage.Source = img;
            }
            catch
            {
                MessageBox.Show("Картинка не выбрана", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ButtUpdate_Click(object sender, RoutedEventArgs e)
        {

                MaterialEdit.Title = TbTitle.Text;
                MaterialEdit.MaterialTypeID = CbMaterialType.SelectedIndex + 1;
                MaterialEdit.CountInStock = Convert.ToSingle(TbCountInStock.Text);
                MaterialEdit.Unit = TbUnit.Text;
                MaterialEdit.CountInPack = Convert.ToInt32(TbCountInPack.Text);
                MaterialEdit.MinCount = Convert.ToInt32(TbMinCount.Text);
                MaterialEdit.Cost = Convert.ToInt32(TbCost.Text);
                MaterialEdit.Description = TbDescription.Text;
                MaterialEdit.Image = path;
                if(IsCreate == true)
                {
                    DatabaseClass.DB.Material.Add(MaterialEdit);
                }
                DatabaseClass.DB.SaveChanges();
                MessageBox.Show(MaterialEdit.ID.ToString());
                List<MaterialSupplier> materialSuppliersOld = MS.Where(x => x.MaterialID == MaterialEdit.ID).ToList();
                if(materialSuppliersOld.Count != 0)
                {
                    foreach (MaterialSupplier ms in materialSuppliersOld)
                    {
                        DatabaseClass.DB.MaterialSupplier.Remove(ms);
                    }
                }
                foreach (Supplier t in LbSupliers.Items)
                {
                    MaterialSupplier ms = new MaterialSupplier();
                    ms.MaterialID = MaterialEdit.ID;
                    ms.SupplierID = t.ID;
                    DatabaseClass.DB.MaterialSupplier.Add(ms);
                    MessageBox.Show(ms.ID.ToString());
                }
                DatabaseClass.DB.SaveChanges();
                MessageBox.Show("Данные записаны", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //}
            //catch
            //{
            //    MessageBox.Show("Не удалось записать данные, повторите попытку", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void ButtDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
