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

namespace PersonalBugTracker
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void SaveData_Click(object sender, RoutedEvent e)
        {
            String name = this.dataName;
            String adata = this.dataInfo;
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Retoggle:<password>@cluster0.d2mcw.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("db");
            var collection = database.getCollection("BT");
            collection.insertOne("Name", name);
            collection.insertOne("Additional", adata);
        }
        
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        private void Minimise_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

    }
}
