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
using System.Text.RegularExpressions;


namespace loginRegister
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionbar", NoHistory = true, MainLauncher = false)]
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
            if (!isValidName() && !isValidEmail() && !isValidUserName() && !isValidPassword())
            {
                Toast.MakeText(this, "Task Failed Successfully", ToastLength.Long).Show();
                return;
            }

            if (isValidName() && isValidEmail() && isValidUserName() && isValidPassword())
            {
                Toast.MakeText(this, "user successfully loggedin", ToastLength.Long).Show();

            }
        }

        private bool isValidName()
        {
            if (nametext.Text == "")
            {
                Toast.MakeText(this, "name of user is empty", ToastLength.Long).Show();
                namecontainer.Error = "name of the user is not inserted";
                return false;
            }
            else
                return true;
        }

        private bool isValidEmail()
        {
            bool isEmail = Regex.IsMatch(emailtext.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (emailtext.Text.Trim().Equals(""))
            {
                Toast.MakeText(this, "email of user is empty", ToastLength.Long).Show();
                emailcontainer.Error = "email of the user is not inserted";
                return false;
            }
            if (!isEmail)
            {
                Toast.MakeText(this, "Invalid Email", ToastLength.Long).Show();
                emailcontainer.Error = "Invalid email address";
                return false;
            }
            return true;
        }

        private bool isValidUserName()
        {

            if (usernametext.Text == "")
            {
                Toast.MakeText(this, "username is empty", ToastLength.Long).Show();
                usernamecontainer.Error = "username of the user is not inserted";
                return false;
            }
            else
                return true;
        }

        private bool isValidPassword()
        {
            var length1 = passwordtext.Length();
            if (passwordtext.Text.Length <8)
            {
                Toast.MakeText(this, "password of user is empty or less than 8", ToastLength.Long).Show();
                passwordconatiner.Error = "password of the user is should not be less than 8";
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
            regitertext = FindViewById<TextView>(Resource.Id.registertext);
            passwordtext = FindViewById<TextInputEditText>(Resource.Id.passwordedittext);
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