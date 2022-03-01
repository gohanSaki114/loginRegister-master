using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace loginRegister
{
    [Activity(Label = "login",Theme = "@style/AppTheme.NoActionbar", NoHistory = true)]
    public class login : Activity
    {
        CardView fb, google;
        Button loginbtn;
        TextView toregisterpage , registertex,forgotpass;
        TextInputEditText passworwtext1,usernamete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.loginactivity);
            google = FindViewById<CardView>(Resource.Id.view3);
            fb  = FindViewById<CardView>(Resource.Id.view2);
            toregisterpage = FindViewById<TextView>(Resource.Id.registerbelow2);
            passworwtext1 =  FindViewById<TextInputEditText>(Resource.Id.passwordtext1);
            loginbtn = FindViewById<Button>(Resource.Id.registerbutton);
            usernamete = FindViewById<TextInputEditText>(Resource.Id.usernametex);
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
            loginbtn.Click += Loginbtn_Click;
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if (!passwordok() && !usernameok())
            {
                Toast.MakeText(this, "Task Failed Successfully", ToastLength.Long).Show();
                return;
            }
            if (passwordok() && usernameok())
            {
                Toast.MakeText(this, "user successfully loggedin", ToastLength.Long).Show();

            }
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
        private bool usernameok()
        {
            if (usernamete.Text == "")
            {
                Toast.MakeText(this, "name of user is empty", ToastLength.Long).Show();
                usernamete.Error = "name of the user is not inserted";
                return false;
            }
            else
                return true;
        }
        private bool passwordok()
        {
            var length1 = passworwtext1.Length();
            if (passworwtext1.Text.Length < 8)
            {
                Toast.MakeText(this, "password of user is empty or less than 8", ToastLength.Long).Show();
                passworwtext1.Error = "password of the user is should not be less than 8";
                return false;
            }
            else
                return true;
        }
        private void Toregisterpage_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this,typeof(MainActivity));
            StartActivity(intent);  
        }
    }
}