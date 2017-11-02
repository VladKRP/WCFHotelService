using HotelService.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace HotelDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connectUrl = "http://localhost:52786/RoomService.svc/RestJson/";
        private IEnumerable<Room> rooms = null;
        public MainWindow()
        {
            InitializeComponent();
            HandleRequest();
            foreach (var room in rooms)
                this.ListOfData.Items.Add(room);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var l = 0;
        }

        private void HandleRequest()
        {
            string response = "";
            using (var client = new HttpClient())
            {
                response = client.GetStringAsync(connectUrl).Result; 
            }
            if(!string.IsNullOrEmpty(response))
                rooms = JsonConvert.DeserializeObject<IEnumerable<Room>>(response);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
