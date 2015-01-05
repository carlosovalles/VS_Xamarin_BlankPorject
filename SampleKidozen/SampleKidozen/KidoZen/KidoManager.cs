using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Newtonsoft.Json.Linq;
using Kidozen;

#if __IOS__
using Kidozen.iOS;
#else
using Kidozen.Android;
using Android.Content;
#endif

// TODO Create Singleton
namespace SampleKidozen
{
    public class KidoManager
    {
        static object locker = new object();
        static KidoApplication kidozenApplication;

        static KidoManager()
        {
            if (KidoManager.kidozenApplication == null)
            {
                KidoManager.kidozenApplication =  new KidoApplication(KidoSettings.Marketplace, KidoSettings.Application, KidoSettings.Key);
            }
        }

        public static Task<Boolean> Login(string user, string password)
        {

            var authTask = KidoManager.kidozenApplication.Authenticate(user, password, "Kidozen");

            return authTask.ContinueWith(
                t =>
                {
                    // if t fails you could get the exception t.Exception.GetBaseException();
                    return !t.IsFaulted;
                }
            );
        }
      
        // DataSource.DataSource queryDataSource, saveDataSource;


        // queryDataSource = kidozenApplication.DataSource["QueryTodo"];
        // saveDataSource = kidozenApplication.DataSource["AddTodo"];


        // ******************************
        // *** DataSource sample code ***
        // ******************************
        /*
        public IEnumerable<TodoItem> GetItems ()
        {
            lock (locker) {
                var results = queryDataSource.Query().Result.Data;
                return createTodoItemList (results);
            }
        }
        //Ensure that your DataSource can execute an UPSERT
        public void SaveItem (TodoItem item) 
        {
            lock (locker) {
                var result = saveDataSource.Invoke(item).Result;
            }
        }
        IEnumerable<TodoItem> createTodoItemList (JObject results)
        {
            var result = JArray.Parse (results.SelectToken("data").ToString());
            return result.Select ( todo => new TodoItem {
                Name = todo.Value<string>("Name"),
                Notes = todo.Value<string>("Notes") ,
                _id = todo.Value<string>("_id") ,
            }
            ).ToList();
        }
        */
    }
}