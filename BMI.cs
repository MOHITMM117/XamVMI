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

namespace XamVMI
{
    public class BMI : Activity
    {
        //Create your fake controls
        EditText txtHeight;
        EditText txtWeight;
        EditText txtResult;
        TextView txtViewMessage;
        Button btnCalculate;
        ImageView img;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BMI);
            InitializeControls();
        }
        public void InitializeControls()
        {
            //Connect the fake controls to the real controls
            txtHeight = FindViewById<EditText>(Resource.Id.editTextHeight);
            txtWeight = FindViewById<EditText>(Resource.Id.editTextweight);
            txtResult = FindViewById<EditText>(Resource.Id.editResult);
            txtViewMessage = FindViewById<TextView>(Resource.Id.txtMessage);
            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            //Create a Button Click Method
            btnCalculate.Click += onBtnCalculateClick;
            img = FindViewById<ImageView>(Resource.Id.imageView1);
        }
        public void onBtnCalculateClick(object sender, EventArgs e)
        {
            if (txtWeight.Text == "")
            {
                Toast.MakeText(this, "Please enter the weight", ToastLength.Long).Show();
                return;
            }
            if (txtHeight.Text == "")
            {
                Toast.MakeText(this, "Please enter the height", ToastLength.Long).Show();
                return;
            }
            CalcBMI();
        }
        private void CalcBMI()
        {
            //Stuff happens here
            double Height = Convert.ToDouble(txtHeight.Text);
            double Weight = Convert.ToDouble(txtWeight.Text); 
        double BMIAnswer = Weight / (Height * Height);
            txtResult.Text = Convert.ToString(Math.Round(BMIAnswer, 2));
            if (BMIAnswer <= 18.5)
            {
                txtViewMessage.Text = "Underweight";
            }
            else if (BMIAnswer >= 18.60 && BMIAnswer <= 24.99)
            {
                txtViewMessage.Text = "Normal";
                img.SetImageResource(Resources.drawable.healthy);
            }
            else if (BMIAnswer > 25 && BMIAnswer <= 29.99)
            {
                txtViewMessage.Text = "Overweight";
            }
            else if (BMIAnswer > 30)
            {
                txtViewMessage.Text = "Obese ";
            }
            //Create a log system, use other tags if you want so you can filter them
            string tag = "BMI";
            Android.Util.Log.Info(tag, "Height = " + Height.ToString());
            Android.Util.Log.Info(tag, "Weight = " + Weight.ToString());
            Android.Util.Log.Info(tag, "Answer = " + BMIAnswer.ToString());
            Android.Util.Log.Info(tag, "Message = " + txtViewMessage.Text);

        }
    }
}