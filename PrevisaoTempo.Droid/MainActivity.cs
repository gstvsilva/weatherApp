using Android.App;
using Android.Widget;
using Android.OS;
using PrevisaoTempo.Core;

namespace PrevisaoTempo.Droid
{
    [Activity(Label = "PrevisaoTempo.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        WeatherService weatherService = new WeatherService();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var editTextCityName = FindViewById<EditText>(Resource.Id.editTextCityName);
            var buttonSearch = FindViewById<Button>(Resource.Id.buttonSearch);

            var textViewLocation = FindViewById<TextView>(Resource.Id.textViewLocation);
            var textViewTemperature = FindViewById<TextView>(Resource.Id.textViewTemperature);
            var textViewSkytext = FindViewById<TextView>(Resource.Id.textViewSkytext);
            var textViewHumidity = FindViewById<TextView>(Resource.Id.textViewHumidity);
            var textViewWind = FindViewById<TextView>(Resource.Id.textViewWind);
            var textViewDate = FindViewById<TextView>(Resource.Id.textViewDate);
            var textViewDay = FindViewById<TextView>(Resource.Id.textViewDay);


            buttonSearch.Click += async (object sender, System.EventArgs e) => {

                if (!editTextCityName.Text.Equals("")) {
                    textViewLocation.Text = "Aguarde...";
                    textViewTemperature.Text = "";
                    textViewSkytext.Text = "";
                    textViewHumidity.Text = "";
                    textViewWind.Text = "";
                    textViewDate.Text = "";
                    textViewDay.Text = "";

                    var result = await weatherService.GetDataCity(editTextCityName.Text);

                    textViewLocation.Text = "Location: "+result.Location;
                    textViewTemperature.Text = "Temperature: " + result.Temperature;
                    textViewSkytext.Text = "Skytext: " + result.Skytext;
                    textViewHumidity.Text = "Humidity: " + result.Humidity;
                    textViewWind.Text = "Wind: " + result.Wind;
                    textViewDate.Text = "Date: " + result.Date;
                    textViewDay.Text = "Day: " + result.Day;
                }
            };
        }
    }
}

