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
    /// Interaction logic for WindowAddCategory.xaml
    /// </summary>
    public partial class WindowAddCategory : Window
    {
        public delegate void AddHandler();
        public event AddHandler addEvent;
        public WindowAddCategory()
        {
            InitializeComponent();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var db = new quan_li_ban_hangEntities1();
            string newName = txtName.Text.TrimStart();
            newName = newName.TrimEnd();
             bool isExist=false;
             int deleted=0;
            foreach (var item in db.categories.ToList())
            {
                if (item.name == newName)
                {
                    deleted = (int)item.deleted;
                    isExist = true;
                    break;
                }
            }
            if (isExist == false)
            {
                db.categories.Add(new category() { name = newName,deleted=0 });
                db.SaveChanges();
                if (addEvent != null)
                {
                    this.addEvent();
                }
              
                txtInform.Text = "Đã thêm category " + newName;
            }
            else
            {
                if (deleted == 0)
                {
                    txtInform.Text = "Category  " + newName + " đã tồn tại !";
                    
                }
                else
                {
                    category cat = db.categories.Where(item => item.name == newName).FirstOrDefault();
                    category catReplace = new category() { name = newName, id = cat.id, deleted = 0 };
                    db.Entry(cat).CurrentValues.SetValues(catReplace);
                    db.SaveChanges();
                    txtInform.Text = "Đã thêm category " + newName;
                    if (addEvent != null)
                    {
                        this.addEvent();
                    }
                }
                
            }

                     

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
