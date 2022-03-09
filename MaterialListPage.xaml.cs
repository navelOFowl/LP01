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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StroyMat
{
    /// <summary>
    /// Логика взаимодействия для MaterialListPage.xaml
    /// </summary>
    public partial class MaterialListPage : Page
    {
        List<Material> MatStart = DatabaseClass.DB.Material.ToList();
        public MaterialListPage()
        {
            InitializeComponent();
            LVMaterial.ItemsSource = MatStart;
        }
        private void TbSupplier_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<MaterialSupplier> mtList = DatabaseClass.DB.MaterialSupplier.Where(x => x.MaterialID == index).ToList();
            string str = "";
            foreach (MaterialSupplier item in mtList)
            {
                str += item.Supplier.Title + ", ";
            }
            if(mtList.Count == 0)
            {
                tb.Text = "Поставщики: отсутствуют";
            }
            else
            {
                tb.Text = "Поставщики: " + str.Substring(0, str.Length - 2);
            }
        }
        List<Material> MatFilter = DatabaseClass.DB.Material.ToList();
        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(CbSort.SelectedIndex)
            {
                case 1:
                    MatFilter.Sort((x, y) => x.Title.CompareTo(y.Title));
                    LVMaterial.ItemsSource = MatFilter;
                    LVMaterial.Items.Refresh();
                    break;
                case 2:
                    MatFilter.Sort((x, y) => x.Title.CompareTo(y.Title));
                    MatFilter.Reverse();
                    LVMaterial.ItemsSource = MatFilter;
                    LVMaterial.Items.Refresh();
                    break;
                case 3:
                    MatFilter.Sort((x, y) => x.Cost.CompareTo(y.Cost));
                    LVMaterial.ItemsSource = MatFilter;
                    LVMaterial.Items.Refresh();
                    break;
                case 4:
                    MatFilter.Sort((x, y) => x.Cost.CompareTo(y.Cost));
                    MatFilter.Reverse();
                    LVMaterial.ItemsSource = MatFilter;
                    LVMaterial.Items.Refresh();
                    break;
                case 5:
                    MatFilter.Sort((x, y) => x.CountInStock.CompareTo(y.CountInStock));
                    LVMaterial.ItemsSource = MatFilter;
                    LVMaterial.Items.Refresh();
                    break;
                case 6:
                    MatFilter.Sort((x, y) => x.CountInStock.CompareTo(y.CountInStock));
                    MatFilter.Reverse();
                    LVMaterial.ItemsSource = MatFilter;
                    LVMaterial.Items.Refresh();
                    break;
            }
        }
    }
}
