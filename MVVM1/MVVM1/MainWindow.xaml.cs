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
using MVVM1.Models;
using System.Collections.ObjectModel;

namespace MVVM1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        readonly ObservableCollection<Inventory> _cars;
        public MainWindow()
        {
            InitializeComponent();
            _cars = new ObservableCollection<Inventory>
            {
                new Inventory {CarId=1,Color="Blue",Make="Chevy",PetName="Kit", IsChanged=false },
                new Inventory {CarId=2,Color="Red",Make="Ford",PetName="Red Rider", IsChanged=false },
            };
            cboCars.ItemsSource = _cars;
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            var maxCount = _cars?.Max(x => x.CarId) ?? 0;
            _cars?.Add(new Inventory { CarId = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie" });
        }

        private void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            var car = _cars.FirstOrDefault(x => x.CarId == ((Inventory)cboCars.SelectedItem)?.CarId);
            if (car != null)
            {
                car.Color = "Pink";
            }
        }

        private void btnRemoveCar_Click(object sender, RoutedEventArgs e)
        {
            _cars.RemoveAt(0);
        }
    }
}
