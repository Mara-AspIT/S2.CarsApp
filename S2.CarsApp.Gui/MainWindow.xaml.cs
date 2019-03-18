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

using S2.CarsApp.DataAccess;
using S2.CarsApp.Entities;

namespace S2.CarsApp.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CarRepository repository = new CarRepository();
            dataGrid.ItemsSource = repository.GetAllCars();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Car newCar = new Car();
            if(textBoxId.Text == String.Empty)
            {
                MessageBox.Show("Fejl");
            }
            else
            {
                newCar.Id = Convert.ToInt32(textBoxId.Text);
                newCar.Make = textBoxMake.Text;
                newCar.Model = textBoxModel.Text;
                newCar.LicencePlate = textBoxLicencePlate.Text;
                CarRepository repository = new CarRepository();
                repository.Save(newCar);
                dataGrid.ItemsSource = repository.GetAllCars();
            }            
        }
    }
}