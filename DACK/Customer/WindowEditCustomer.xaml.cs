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
    /// Interaction logic for WindowEditCustomer.xaml
    /// </summary>
    public partial class WindowEditCustomer : Window
    {
        public delegate void EditHandler();
        public event EditHandler editEvent;
        int ID;
        public WindowEditCustomer(int id)
        {
            ID = id;
            InitializeComponent();
            txtId.Text = id + "";
            txtId.IsEnabled = false;

            var db = new quan_li_ban_hangEntities1();
             customer cat = db.customers.Where(item => item.id == ID).FirstOrDefault();
             txtName.Text = cat.name;
             txtPhoneNumber.Text = cat.phonenumber;
             txtAddress.Text = cat.address;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {


            var text = txtName.Text.TrimEnd();
            text = text.TrimStart();
            var textPhoneNumber = txtPhoneNumber.Text.TrimEnd();
            textPhoneNumber = textPhoneNumber.TrimStart();
            var textAddress = txtAddress.Text.TrimEnd();
            textAddress = textAddress.TrimStart();

            if (text == "")
            {
                txtInform.Text = "Vui lòng nhập name khác rỗng !";
            }
            else
            {
                var db = new quan_li_ban_hangEntities1();

                customer cat = db.customers.Where(item => item.id == ID).FirstOrDefault();
                customer catReplace = new customer() { name = text, id = cat.id, deleted = 0,address=textAddress,phonenumber=textPhoneNumber };
                db.Entry(cat).CurrentValues.SetValues(catReplace);
                db.SaveChanges();
                txtInform.Text = "Editted !";
                if (editEvent != null)
                {
                    this.editEvent();
                }

            }

        }
    }
}
