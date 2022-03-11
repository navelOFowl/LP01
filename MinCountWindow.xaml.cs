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
    /// Логика взаимодействия для MinCountWindow.xaml
    /// </summary>
    public partial class MinCountWindow : Window
    {
        public MinCountWindow(double max)
        {
            InitializeComponent();
            TbNewMinCount.Text = max.ToString();

        }

        double newMinCount = 0;

        private void ButtOk_Click(object sender, RoutedEventArgs e)
        {
            newMinCount = Convert.ToDouble(TbNewMinCount.Text);
            this.Close();
        }

        public double NewMinCount
        {
            get
            {
                return newMinCount;
            }
        }
    }
}
