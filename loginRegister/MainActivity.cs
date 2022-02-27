using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using AndroidX.CardView.Widget;
using Android.Content;
using Android.Text;
using Android.Graphics;
using Google.Android.Material.TextField;
using System;

namespace loginRegister
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionbar", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        TextInputLayout namecontainer, emailcontainer, usernamecontainer, passwordconatiner;
        TextInputEditText nametext, emailtext, usernametext, passwordtext;
        CardView fb, google;
        Button registerbutton;
        TextView tologin, regitertext;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);
            Uireferences();
            registerbutton.Click += Registerbutton_Click;
            
            TextPaint paint = regitertext.Paint;
            float width = paint.MeasureText(regitertext.Text);

            int[] vs = new int[]{
                        Color.ParseColor("#8446CC"),
                        Color.ParseColor("#64B678"),
                        Color.ParseColor("#FDB54E"),
                        Color.ParseColor("#478AEA"),
                        Color.ParseColor("#F97C3C"),
                    };
            Shader textShader = new LinearGradient(0, 0, width, regitertext.TextSize,
                    vs, null, Shader.TileMode.Clamp);
            regitertext.Paint.SetShader(textShader);
            tologin.Click += Tologin_Click;
            fb.Click += Fb_Click;
            google.Click += Google_Click;
        }

       

        private void Registerbutton_Click(object sender, System.EventArgs e)
        {
            if (passwordok() && emailok() && nameok() && usernameok())
            {
                Toast.MakeText(this, "user successfully loggedin", ToastLength.Long).Show();

            }
        }

        private bool usernameok()
        {
            if (nametext.Text == "")
            {
                Toast.MakeText(this, "name of user is empty", ToastLength.Long).Show();
                nametext.Error = "name of the user is not inserted";
                return false;   
            }
            else
                return true;    
        }

        private bool nameok()
        {
            if (emailtext.Text == "")
            {
                Toast.MakeText(this, "email of user is empty", ToastLength.Long).Show();
                emailtext.Error = "email of the user is not inserted";
                return false;
            }
            else
                return true;
        }

        private bool emailok()
        {
            if (usernametext.Text == "")
            {
                Toast.MakeText(this, "username is empty", ToastLength.Long).Show();
                usernametext.Error = "username of the user is not inserted";
                return false;
            }
            else
                return true;
        }

        private bool passwordok()
        {
            if (passwordtext.Text == "")
            {
                Toast.MakeText(this, "password of user is empty", ToastLength.Long).Show();
                passwordtext.Error = "password of the user is not inserted";
                return false;
            }
            else
                return true;
        }

        private void Tologin_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(login));
            StartActivity(intent);
        }

        private void Google_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Google button clicked", ToastLength.Short).Show();
        }

        private void Fb_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Fb button clicked", ToastLength.Short).Show();
        }

        private void Uireferences()
        {
            fb = FindViewById<CardView>(Resource.Id.view2);
            google = FindViewById<CardView>(Resource.Id.view3);
            tologin = FindViewById<TextView>(Resource.Id.registerbelow2);
            passwordtext = FindViewById<TextInputEditText>(Resource.Id.passwordedittext);
            regitertext = FindViewById<TextView>(Resource.Id.registertext);
            emailtext = FindViewById<TextInputEditText>(Resource.Id.emailedittext);
            nametext = FindViewById<TextInputEditText>(Resource.Id.namedittext);
            usernametext = FindViewById<TextInputEditText>(Resource.Id.usernamedittext);
            namecontainer = FindViewById<TextInputLayout>(Resource.Id.namecontainer);
            emailcontainer = FindViewById<TextInputLayout>(Resource.Id.emailcontainer);
            usernamecontainer = FindViewById<TextInputLayout>(Resource.Id.usernamecontainer);
            passwordconatiner = FindViewById<TextInputLayout>(Resource.Id.passwordcontainer);
            registerbutton = FindViewById<Button>(Resource.Id.registerbutton);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}