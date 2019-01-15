using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DACK.Customer
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
      GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection;
        ListSortDirection direction;
        int numberRowInSingPage;
        string curViewMode;
        void GridViewColumnHeaderClickedHandler(object sender,
                                            RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;


            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = "";
                    if (columnBinding != null)
                    {
                        sortBy = columnBinding.Path.Path;
                    }

                    Sort(sortBy, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header  
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(lvcustomer.ItemsSource);
            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }
        public CustomerPage()
        {
            InitializeComponent();
        }
        private List<customer> LoadAll()
        {
            curViewMode = "All";
            var db = new quan_li_ban_hangEntities1();
            List<customer> list = new List<customer>();
            foreach (var item in db.customers.ToList())
            {
                if (item.deleted == 0)
                {
                    list.Add(item);
                }
            }
            LoadFollowPageNumber(list);
            return list;
        }
        private List<customer> LoadById()
        {
            curViewMode = "ID";
            var txt = txtFilter.Text.ToLower();
            var db = new quan_li_ban_hangEntities1();
            List<customer> list = new List<customer>();
            foreach (var item in db.customers.ToList())
            {
                if (item.deleted == 0)
                {
                    list.Add(item);
                }
            }
            List<customer> list2 = new List<customer>();
            foreach (customer item in list)
            {
                
                int i = 0;
                if (!Int32.TryParse(txt, out i))
                {
                    i = -1;
                }
                if (item.id == i)
                {
                    list2.Add(item);
                }
            }
            LoadFollowPageNumber(list2);
            return list2;
        }
        private List<customer> LoadByName()
        {
            curViewMode = "Name";
            var txt = txtFilter.Text.ToLower();
            var db = new quan_li_ban_hangEntities1();
            List<customer> list = new List<customer>();
            foreach (var item in db.customers.ToList())
            {
                if (item.deleted == 0)
                {
                    list.Add(item);
                }
            }
            List<customer> list2 = new List<customer>();
            foreach (customer item in list)
            {
                if (item.name.ToLower().Contains(txt))
                {
                    list2.Add(item);
                }
            }
            LoadFollowPageNumber(list2);
            return list2;
        }
        private List<customer> LoadByPhoneNumber()
        {
            curViewMode = "Phone Number";
            var txt = txtFilter.Text.ToLower();
            var db = new quan_li_ban_hangEntities1();
            List<customer> list = new List<customer>();
            foreach (var item in db.customers.ToList())
            {
                if (item.deleted == 0)
                {
                    list.Add(item);
                }
            }
            List<customer> list2 = new List<customer>();
            foreach (customer item in list)
            {
                if (item.phonenumber.ToLower().Contains(txt))
                {
                    list2.Add(item);
                }
            }
            LoadFollowPageNumber(list2);
            return list2;
        }
        private List<customer> LoadByAddress()
        {
            curViewMode = "Address";
            var txt = txtFilter.Text.ToLower();
            var db = new quan_li_ban_hangEntities1();
            List<customer> list = new List<customer>();
            foreach (var item in db.customers.ToList())
            {
                if (item.deleted == 0)
                {
                    list.Add(item);
                }
            }
            List<customer> list2 = new List<customer>();
            foreach (customer item in list)
            {
                if (item.address.ToLower().Contains(txt))
                {
                    list2.Add(item);
                }
            }
            LoadFollowPageNumber(list2);
            return list2;
        }
        private void LoadByCurViewMode()
        {
            if (curViewMode == "All")
            {
                LoadAll();
            }
            if (curViewMode == "ID")
            {
                LoadById();
            }
            if (curViewMode == "Name")
            {
                LoadByName();
            }
            if (curViewMode == "Phone Number")
            {
                LoadByPhoneNumber();
            }
            if (curViewMode == "Address")
            {
                LoadByAddress();
            }

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            numberRowInSingPage = 16;
            txtPageNumber.Text = "1";
            LoadAll();
            direction = ListSortDirection.Ascending;
            Sort("id", direction);
            List<string> content = new List<string>();
            content.Add("All");
            content.Add("ID");
            content.Add("Name");
            content.Add("Phone Number");
            content.Add("Address");
            combobox.ItemsSource = content;
            combobox.SelectedIndex = 0;
            txtFilter.IsEnabled = false;

            btnFirst.Content = "<<";
            btnPrevious.Content = "<";
            btnNext.Content = ">";
            btnLast.Content = ">>";
            txtPageNumber.Text = "1";

        }




        private void combobox_DropDownClosed(object sender, EventArgs e)
        {
            txtFilter.Clear();
            if (combobox.SelectedItem as string != "All")
            {
                txtFilter.IsEnabled = true;
            }
            else
            {
                txtFilter.IsEnabled = false;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
           
            var txt = txtFilter.Text.ToLower();
            txtPageNumber.Text = 1+"";
            if (combobox.SelectedItem as string == "All")
            {                
                LoadAll();
            }
            if (combobox.SelectedItem as string == "Name")
            {
                LoadByName();
            }
            if (combobox.SelectedItem as string == "ID")
            {
                LoadById();       
            }
            if (combobox.SelectedItem as string == "Phone Number")
            {
                LoadByPhoneNumber();
            }
            if (combobox.SelectedItem as string == "Address")
            {
                LoadByAddress();
            }
        }
        private void LoadFollowPageNumber(List<customer> list)
        {
            int count = list.Count();
            int maxPage = count / numberRowInSingPage;
            if (count % numberRowInSingPage != 0)
            {
                maxPage++;
            }
            int selectedPage = 1;
            if (!Int32.TryParse(txtPageNumber.Text, out selectedPage))
            {
                selectedPage = 1;
                
            }
            
            if (selectedPage < 1)
            {
                selectedPage = 1;
            }
            if (selectedPage > maxPage)
            {
                selectedPage = maxPage;
            }

            List<customer> list2 = new List<customer>();            
            if (count % numberRowInSingPage != 0 && count / numberRowInSingPage == selectedPage - 1)
            {
                for (int i = (selectedPage - 1) * numberRowInSingPage;i>=0&& i <= (selectedPage - 1) * numberRowInSingPage + count % numberRowInSingPage - 1; i++)
                {
                    list2.Add(list[i]);
                }
            }
            else
            {
               
                for (int i = (selectedPage - 1) * numberRowInSingPage; i <= (selectedPage) * numberRowInSingPage - 1 &&i>=0; i++)
                {
                    list2.Add(list[i]);
                }
            }
            if (count == 0) { selectedPage = 1; }
            txtPageNumber.Text = selectedPage + "";
            lvcustomer.ItemsSource = list2;
            txtPageNumber.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

            if (selectedPage == 1)
            {
                btnPrevious.IsEnabled = false;
            }
            else
            {
                btnPrevious.IsEnabled = true;
            }

            if (selectedPage == maxPage)
            {
                btnNext.IsEnabled = false;
            }
            else
            {
                btnNext.IsEnabled = true;
            }
        }
        private void txtPageNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoadByCurViewMode();
                foreach(var item in combobox.Items ){
                    if (item as string == curViewMode)
                    {
                        combobox.SelectedItem = item;
                        if (curViewMode == "All")
                        {
                            txtFilter.IsEnabled = false;
                        }
                        else
                        {
                            txtFilter.IsEnabled = true;
                        }
                    }
                }
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            if (!Int32.TryParse(txtPageNumber.Text, out i))
            {
                i = 1;
            }else{
                i--;
            }

            txtPageNumber.Text = i + "";
            LoadByCurViewMode();
           
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            txtPageNumber.Text = 1+"";
            LoadByCurViewMode();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            if (!Int32.TryParse(txtPageNumber.Text, out i))
            {
                i = 1;
            }
            else
            {
                i++;
            }

            txtPageNumber.Text = i + "";
            LoadByCurViewMode();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            txtPageNumber.Text = "99999";
            LoadByCurViewMode();
        }
        public void Update()
        {
            LoadByCurViewMode();
        }

        private void clickBtnDelete(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            int id=Int32.Parse(bt.CommandParameter.ToString());
            var db = new quan_li_ban_hangEntities1();
            customer cat=db.customers.Where(item => item.id == id).FirstOrDefault();
            customer catReplace=new customer(){name=cat.name,id=cat.id,deleted=1};
            if(cat!=null){
                db.Entry(cat).CurrentValues.SetValues(catReplace);
                db.SaveChanges();                
                Update();
                MessageBox.Show("Deleted successfully");
            }
            else
            {
                MessageBox.Show("Deleted fail");
            }
        }

        private void clickBtnEdit(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            int id = Int32.Parse(bt.CommandParameter.ToString());
            var window = new DACK.Customer.WindowEditCustomer(id);
            window.editEvent += () =>
            {
                Update();
            };
            window.Show();
        }
    }
}
