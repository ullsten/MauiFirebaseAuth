using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using MauiFirebaseAuth.Models; // Import your custom models namespace

namespace MauiFirebaseAuth.Data
{
    public class SecretsManager
    {
        public static AppSettings GetAppSettings()
        {
            try
            {
                var assembly = typeof(SecretsManager).Assembly;
                var resourceName = "MauiFirebaseAuth.appsettings.json";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        AppSettings settings = JsonConvert.DeserializeObject<AppSettings>(json);
                        return settings;
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
