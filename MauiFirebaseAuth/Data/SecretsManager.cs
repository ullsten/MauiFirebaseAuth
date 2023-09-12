using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFirebaseAuth.Data
{
    public class SecretsManager
    {
        public static string GetWebApiKey()
        {
            try
            {
                var assembly = typeof(SecretsManager).Assembly;
                var resourceName = "MauiFirebaseAuth.appsettings.json";

                using(Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        dynamic secrets = JsonConvert.DeserializeObject<dynamic>(json);
                        return secrets.WebApiKey;
                    }
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                return null;
            }
        }
    }
}
