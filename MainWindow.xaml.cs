using AtorinVladyslavPZ_32Exam.Resources;
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

namespace AtorinVladyslavPZ_32Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FinCalculations dbData;
        List<FinData> financialData;
        public MainWindow()
        {
            InitializeComponent();
            dbData = new FinCalculations();
            financialData = dbData.Expenditures.ToList();
            DataTable.ItemsSource = dbData.Expenditures.ToList();
            categories.ItemsSource = Enum.GetValues(typeof(Category)).Cast<Category>();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            List<FinData> newData = new List<FinData>();
            for(int i=0; i<DataTable.Items.Count; ++i)
            {
                newData.Add(DataTable.Items[i] as FinData);
                if (newData[i] == null)
                {
                    newData.Remove(newData[i]);
                }
            }

            for (int i = 0; i<financialData.Count; ++i)
            {
                bool check = false;
                for (int j = 0; j<newData.Count; ++j)
                {

                    if (financialData[i] == newData[j])
                    {
                        check = true;
                        break;
                    }
                }
                if (check == false)
                {
                    dbData.Expenditures.Remove(financialData[i]);
                }
            }

            for (int i = 0; i<newData.Count; ++i)
            {
                bool check = false;
                for (int j = 0; j<financialData.Count; ++j)
                {
                    if (newData[i] == financialData[j])
                    {
                        check = true;
                        break;
                    }
                }
                if (check == false)
                {
                    dbData.Expenditures.Add(newData[i]);
                }
            }

            dbData.SaveChanges();
        }

        private void categories_DropDownClosed(object sender, EventArgs e)
        {
            double allSum = 0;
            double selCategory = 0;

            string nameCat = categories.SelectedValue.ToString();

            List<FinData> newData = new List<FinData>();
            for (int i = 0; i<DataTable.Items.Count; ++i)
            {
                newData.Add(DataTable.Items[i] as FinData);
                if (newData[i] == null)
                {
                    newData.Remove(newData[i]);
                }
            }

            for (int i = 0; i<newData.Count; ++i)
            {
                if (newData[i].Categories.Equals(nameCat))
                {
                    selCategory += newData[i].expenses;
                }
                allSum += newData[i].expenses;
            }

            int ret = Convert.ToInt32((selCategory/allSum) * 100.0);

            percentBox.Text = Convert.ToString(ret);
            percentBox.Text += '%';
        }

        private void catBox_DropDownClosed(object sender, EventArgs e)
        {
            double Sum = 0;

            int monCat = catBox.SelectedIndex + 1;

            List<FinData> newData = new List<FinData>();
            for (int i = 0; i<DataTable.Items.Count; ++i)
            {
                newData.Add(DataTable.Items[i] as FinData);
                if (newData[i] == null)
                {
                    newData.Remove(newData[i]);
                }
            }

            for (int i = 0; i<newData.Count; ++i)
            {
                if (newData[i].date.Month == monCat)
                {
                    Sum += newData[i].expenses;
                }
            }

            int ret = Convert.ToInt32(Sum);

            monthtBox.Text = Convert.ToString(ret);
        }
    }
}
