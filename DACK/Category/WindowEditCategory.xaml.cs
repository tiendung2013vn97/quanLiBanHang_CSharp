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

namespace DACK.Category
{
    /// <summary>
    /// Interaction logic for WindowEditCategory.xaml
    /// </summary>
    public partial class WindowEditCategory : Window
    {
        public delegate void EditHandler();
        public event EditHandler editEvent;
        int ID;
        public WindowEditCategory(int id)
        {
            ID = id;
            InitializeComponent();
            txtId.Text = id + "";
            txtId.IsEnabled = false;
            var db = new quan_li_ban_hangEntities1();
            category cat = db.categories.Where(item => item.id == ID).FirstOrDefault();
            txtName.Text = cat.name;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {


            var text = txtName.Text.TrimEnd();
            text = text.TrimStart();
            if (text == "")
            {
                txtInform.Text = "Vui lòng nhập name khác rỗng !";
            }
            else
            {
                var db = new quan_li_ban_hangEntities1();
                bool isExist = false;
                foreach (var item in db.categories.ToList())
                {
                    if (item.name == text && item.id != ID)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (isExist)
                {
                    txtInform.Text = "Name đã tồn tại ! Vui lòng chọn name khác!";
                }
                else
                {
                    category cat = db.categories.Where(item => item.id == ID).FirstOrDefault();
                    category catReplace = new category() { name = text, id = cat.id, deleted = 0 };
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
}
