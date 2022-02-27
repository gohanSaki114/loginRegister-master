using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace loginRegister
{
    [Activity(Label = "splashactivity", Theme = "@style/AppTheme.NoActionbar", NoHistory = true, MainLauncher = true)]
    public class splashactivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        protected override void OnResume()

        {
        base.OnResume();
            StartActivity(typeof(MainActivity));
        }
        
    }
}