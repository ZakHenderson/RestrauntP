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
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;

namespace RestrauntP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Company> restaurantDataList;
        public double MinSales { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            string JsonPath = File.ReadAllText("RestrauntInformationFile.json");

            List<Company> CompanyData = JsonConvert.DeserializeObject<List<Company>>(JsonPath);

            foreach (Company company in CompanyData)
            {
                lstCompany.Items.Add(company);
            }
            


    }

        private void lstCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string JsonPath = File.ReadAllText("RestrauntInformationFile.json");

            List<Company> CompanyData = JsonConvert.DeserializeObject<List<Company>>(JsonPath);

            int selectIndex = lstCompany.SelectedIndex;

            if(selectIndex >= 0 && selectIndex < CompanyData.Count)
            {
                Company SelectedCompany = CompanyData[selectIndex];
                string imageUrl = CompanyData[selectIndex].LOGO;
                string rank = (selectIndex + 1).ToString();
                double sales = SelectedCompany.SALES_MILLIONS_2018_US;
                string category = SelectedCompany.CATEGORY;

                if (!string.IsNullOrWhiteSpace(imageUrl))
                {
                    try
                    {
                        BitmapImage image = new BitmapImage(new Uri(imageUrl));
                        imgLogo.Source = image;
                    }
                    catch {
                    
                    imgLogo.Source = null;
                    }
                }
                lblRank.Content = $"Rank: {rank}";
                lblSales.Content = $"Sales (Millions): {sales}";
                lblCategory.Content = $"Category: {category}";
            }



        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            string JsonPath = File.ReadAllText("RestrauntInformationFile.json");

            List<Company> CompanyData = JsonConvert.DeserializeObject<List<Company>>(JsonPath);

            if (double.TryParse(txtBox.Text, out double minSales))
            {
                List<string> filteredCompanies = restaurantDataList
                    .Where(Company => Company.SALES_MILLIONS_2018_US >= minSales)
                    .Select(Company => Company.COMPANY)
                    .ToList();

                lstCompany.ItemsSource = filteredCompanies;
            }
            else
            {
                MessageBox.Show("Please enter a valid minimum sales value.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
