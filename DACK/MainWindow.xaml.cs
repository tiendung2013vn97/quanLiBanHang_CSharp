using Fluent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DACK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow 
    {
        ObservableCollection<TabItem> screens;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
             screens = new ObservableCollection<TabItem>()
            {
                new TabItem() {
                    Header ="Loại sản phẩm",
                    Content = new Frame() {
                        Content = new DACK.Category.CategoryPage()
                    },
                },
                new TabItem() {
                    Header ="Sản phẩm",
                    Content = new Frame() {
                        Content = new DACK.Product.ProductPage()
                    },
                },
                new TabItem() {
                    Header ="Khách hàng",
                    Content = new Frame() {
                        Content = new DACK.Customer.CustomerPage()
                    },
                },
                new TabItem() {
                    Header ="Hóa đơn",
                    Content = new Frame() {
                        Content = new DACK.Bill.BillPage()
                    },
                },
                new TabItem() {
                    Header ="Khuyến mãi",
                    Content = new Frame() {
                        Content = new DACK.Promotions.PromotionsPage()
                    },
                },
                new TabItem() {
                    Header ="Thống kê",
                    Content = new Frame() {
                        Content = new DACK.Statistic.StatisticPage()
                    },
                }
             };

            tabs.ItemsSource = screens;
            tabs.SelectedIndex = 0;
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            var window = new DACK.Category.WindowAddCategory();
            window.addEvent += () =>
            {
                var tb=screens.ElementAt(0) as TabItem;
                var fr = tb.Content as Frame;
                var cat=fr.Content as DACK.Category.CategoryPage;
                cat.Update();
            };
            window.Show();

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var window = new DACK.Customer.WindowAddCustomer();
            window.addEvent += () =>
            {
                var tb = screens.ElementAt(2) as TabItem;
                var fr = tb.Content as Frame;
                var cat = fr.Content as DACK.Customer.CustomerPage;
                cat.Update();
            };
            window.Show();
        }
    }
}
