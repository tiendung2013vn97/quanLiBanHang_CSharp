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

namespace DACK.Customer
{
    /// <summary>
    /// Interaction logic for WindowAddCustomer.xaml
    /// </summary>
    public partial class WindowAddCustomer : Window
    {
        public delegate void AddHandler();
        public event AddHandler addEvent;
        public WindowAddCustomer()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var db = new quan_li_ban_hangEntities1();

            string newName = txtName.Text.TrimStart();
            newName = newName.TrimEnd();

            string phoneNumber = txtPhoneNumber.Text.TrimStart();
            phoneNumber = phoneNumber.TrimEnd();

            string Address = txtAddess.Text.TrimStart();
            Address = Address.TrimEnd();

            int deleted = 0;

            db.customers.Add(new customer() { name = newName, deleted = 0,phonenumber=phoneNumber,address=Address });
            db.SaveChanges();
            if (addEvent != null)
            {
                this.addEvent();
            }

            txtInform.Text = "Đã thêm customer " + newName;




        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text == "")
            {
                btnAdd.IsEnabled = false;
            }
            else
            {
                btnAdd.IsEnabled = true;
            }

        }
    }
}
