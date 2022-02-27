using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace loginRegister
{
    public class sudent
    {
        
        public string userame { get; set; }
        public string password { get; set; }
         
        public int id { get; set; } 
        public string user { get; set; }
        public string email { get; set; }
    }
}