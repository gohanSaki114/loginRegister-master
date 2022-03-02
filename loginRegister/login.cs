using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.CardView.Widget;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace loginRegister
{
    [Activity(Label = "login", Theme = "@style/AppTheme.NoActionbar", NoHistory = true, WindowSoftInputMode = SoftInput.AdjustPan)]
    public class login : AppCompatActivity
    {
        CardView fb, google;
        Button loginbutton;
        TextView ToRegisterpageTextivew, RegisterTextView, ForgotPassTextView;
        TextInputEditText passworwEditText, usernameEditText;
        TextInputLayout passwordContainer, usernameContainer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.loginactivity);
            uireferences();
            uiclick();
            setgradient();


        }

        private void uiclick()
        {
            ForgotPassTextView.Click += Forgotpass_Click;
            fb.Click += Fb_Click;
            google.Click += Google_Click;
            ToRegisterpageTextivew.Click += Toregisterpage_Click;
            // Create your application here
            loginbutton.Click += Loginbtn_Click;
        }

        private void setgradient()
        {
            TextPaint paint = RegisterTextView.Paint;
            float width = paint.MeasureText(RegisterTextView.Text);

            int[] vs = new int[]{
                        Color.ParseColor("#8446CC"),
                        Color.ParseColor("#64B678"),
                        Color.ParseColor("#FDB54E"),
                        Color.ParseColor("#478AEA"),
                        Color.ParseColor("#F97C3C"),
                    };
            Shader textShader = new LinearGradient(0, 0, width, RegisterTextView.TextSize,
                    vs, null, Shader.TileMode.Clamp);
            ForgotPassTextView.Paint.SetShader(textShader);
        }

        private void uireferences()
        {
            google = FindViewById<CardView>(Resource.Id.view3);
            passwordContainer = FindViewById<TextInputLayout>(Resource.Id.passwordcontainer);
            usernameContainer = FindViewById<TextInputLayout>(Resource.Id.usernamecontainer);
            fb = FindViewById<CardView>(Resource.Id.view2);
            ToRegisterpageTextivew = FindViewById<TextView>(Resource.Id.registerbelow2);
            passworwEditText = FindViewById<TextInputEditText>(Resource.Id.passwordtext1);
            loginbutton = FindViewById<Button>(Resource.Id.registerbutton);
            usernameEditText = FindViewById<TextInputEditText>(Resource.Id.usernametex);
            RegisterTextView = FindViewById<TextView>(Resource.Id.registertext);
            ForgotPassTextView = FindViewById<TextView>(Resource.Id.forgotpass);
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

            Toast.MakeText(this, "forgot password clicked", ToastLength.Short).Show();
        }

        private void Fb_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "fb button clicked", ToastLength.Short).Show();
        }

        private void Google_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "google button clicked", ToastLength.Short).Show();
        }
        private bool usernameok()
        {
            if (usernameEditText.Text == "")
            {
                Toast.MakeText(this, "name of user is empty", ToastLength.Long).Show();
                usernameContainer.Error = "name of the user is not inserted";
                return false;
            }
            else
                return true;
        }
        private bool passwordok()
        {
            var length1 = passworwEditText.Length();
            if (passworwEditText.Text.Length < 8)
            {
                Toast.MakeText(this, "password of user is empty or less than 8", ToastLength.Long).Show();
                passwordContainer.Error = "password of the user is should not be less than 8";
                return false;
            }
            else
                return true;
        }
        private void Toregisterpage_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            FinishAffinity();
        }
    }
}