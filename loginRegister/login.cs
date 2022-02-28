using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace loginRegister
{
    [Activity(Label = "login",Theme = "@style/AppTheme.NoActionbar")]
    public class login : Activity
    {
        CardView fb, google;
        TextView toregisterpage , registertex,forgotpass;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.loginactivity);
            google = FindViewById<CardView>(Resource.Id.view3);
            fb  = FindViewById<CardView>(Resource.Id.view2);
            toregisterpage = FindViewById<TextView>(Resource.Id.registerbelow2);
            registertex = FindViewById<TextView>(Resource.Id.registertext);
            forgotpass = FindViewById<TextView>(Resource.Id.forgotpass);
            forgotpass.Click += Forgotpass_Click;
            TextPaint paint = registertex.Paint;
            float width = paint.MeasureText(registertex.Text);

            int[] vs = new int[]{
                        Color.ParseColor("#8446CC"),
                        Color.ParseColor("#64B678"),
                        Color.ParseColor("#FDB54E"),
                        Color.ParseColor("#478AEA"),
                        Color.ParseColor("#F97C3C"),
                    };
            Shader textShader = new LinearGradient(0, 0, width, registertex.TextSize,
                    vs, null, Shader.TileMode.Clamp);
            registertex.Paint.SetShader(textShader);
            fb.Click += Fb_Click;
            google.Click += Google_Click;
            toregisterpage.Click += Toregisterpage_Click;
            // Create your application here
        }

        private void Forgotpass_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this,"forgot password clicked",ToastLength.Short).Show();    
        }

        private void Fb_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "fb button clicked", ToastLength.Short).Show();
        }

        private void Google_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this,"google button clicked",ToastLength.Short).Show();
        }

        private void Toregisterpage_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this,typeof(MainActivity));
            StartActivity(intent);  
        }
    }
}