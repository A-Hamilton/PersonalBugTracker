using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBugTracker.ViewModel
{
    class MainViewModel
    {
        protected virtual void OnExit (System.Windows.ExitEventArgs e){
            saveToDatabase();
        }
        
        private void saveToDatabase (){
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Retoggle:<password>@cluster0.d2mcw.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("db");
            var collection = database.GetCollection("BT");
            collection.InsertOne("data");
        }

    }
}
