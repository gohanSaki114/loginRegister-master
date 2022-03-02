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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionbar", NoHistory = true, MainLauncher = false, WindowSoftInputMode = Android.Views.SoftInput.AdjustPan)]
    public class MainActivity : AppCompatActivity
    {
        TextInputLayout nameContainer, emailContainer, userNameContainer, passwordConatiner;
        TextInputEditText nameEditText, emailEditText, usernameEditText, passworwEditText;
        CardView fb, google;
        Button registerButton;
        TextView loginTextview, regiterTextview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);
            uireferences();
            uiclick();
            setgradient();

        }

        private void uiclick()
        {
            registerButton.Click += Registerbutton_Click1;

            loginTextview.Click += Tologin_Click;
            fb.Click += Fb_Click;
            google.Click += Google_Click;
        }

        private void setgradient()
        {
            TextPaint paint = regiterTextview.Paint;
            float width = paint.MeasureText(regiterTextview.Text);

            int[] vs = new int[]{
                        Color.ParseColor("#8446CC"),
                        Color.ParseColor("#64B678"),
                        Color.ParseColor("#FDB54E"),
                        Color.ParseColor("#478AEA"),
                        Color.ParseColor("#F97C3C"),
                    };
            Shader textShader = new LinearGradient(0, 0, width, regiterTextview.TextSize,
                    vs, null, Shader.TileMode.Clamp);
            regiterTextview.Paint.SetShader(textShader);
        }

        private void uireferences()
        {
            fb = FindViewById<CardView>(Resource.Id.view2);
            google = FindViewById<CardView>(Resource.Id.view3);
            loginTextview = FindViewById<TextView>(Resource.Id.registerbelow2);
            regiterTextview = FindViewById<TextView>(Resource.Id.registertext);
            passworwEditText = FindViewById<TextInputEditText>(Resource.Id.passwordedittext);
            emailEditText = FindViewById<TextInputEditText>(Resource.Id.emailedittext);
            nameEditText = FindViewById<TextInputEditText>(Resource.Id.namedittext);
            usernameEditText = FindViewById<TextInputEditText>(Resource.Id.usernamedittext);
            nameContainer = FindViewById<TextInputLayout>(Resource.Id.namecontainer);
            emailContainer = FindViewById<TextInputLayout>(Resource.Id.emailcontainer);
            userNameContainer = FindViewById<TextInputLayout>(Resource.Id.usernamecontainer);
            passwordConatiner = FindViewById<TextInputLayout>(Resource.Id.passwordcontainer);
            registerButton = FindViewById<Button>(Resource.Id.registerbutton);
        }

        private void Registerbutton_Click1(object sender, EventArgs e)
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
            if (nameEditText.Text == "")
            {
                Toast.MakeText(this, "name of user is empty", ToastLength.Long).Show();
                nameContainer.Error = "name of the user is not inserted";
                return false;
            }
            else
                return true;
        }

        private bool isValidEmail()
        {
            bool isEmail = Regex.IsMatch(emailEditText.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (emailEditText.Text.Trim().Equals(""))
            {
                Toast.MakeText(this, "email of user is empty", ToastLength.Long).Show();
                emailContainer.Error = "email of the user is not inserted";
                return false;
            }
            if (!isEmail)
            {
                Toast.MakeText(this, "Invalid Email", ToastLength.Long).Show();
                emailContainer.Error = "Invalid email address";
                return false;
            }
            return true;
        }

        private bool isValidUserName()
        {

            if (usernameEditText.Text == "")
            {
                Toast.MakeText(this, "username is empty", ToastLength.Long).Show();
                userNameContainer.Error = "username of the user is not inserted";
                return false;
            }
            else
                return true;
        }

        private bool isValidPassword()
        {
            var length1 = passworwEditText.Length();
            if (passworwEditText.Text.Length < 8)
            {
                Toast.MakeText(this, "password of user is empty or less than 8", ToastLength.Long).Show();
                passwordConatiner.Error = "password of the user is should not be less than 8";
                return false;
            }
            else
                return true;
        }

        private void Tologin_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(login));
            StartActivity(intent);
            FinishAffinity();
        }

        private void Google_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Google button clicked", ToastLength.Short).Show();
        }

        private void Fb_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Fb button clicked", ToastLength.Short).Show();
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}