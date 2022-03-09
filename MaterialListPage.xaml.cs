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
        List<MaterialSupplier> MatSup = DatabaseClass.DB.MaterialSupplier.ToList();
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
    }
}
