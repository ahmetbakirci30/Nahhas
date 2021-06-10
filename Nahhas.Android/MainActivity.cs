using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Nahhas.Business.Repositories;
using System.Linq;
using Xamarin.Essentials;

namespace Nahhas.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Init();
        }

        private async void Init()
        {
            var nahhas = new NahhasRepositories();
            var videos = (await nahhas.VideoRepository.Get()).ToList();

            Toast.MakeText(this, videos[0].Title, ToastLength.Short).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}