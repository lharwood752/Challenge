using System;
using System.Windows.Forms;

namespace Borwell_Challenge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string Width_Input;
        static string Length_Input;
        static string Height_Input;
        static decimal Room_Width;
        static decimal Room_Length;
        static decimal Room_Height;
        static decimal FloorArea;
        static decimal WallAreas; 
        static decimal RoomVolume;
        static decimal Paint_Required;
        static decimal Paint_Coveravge = 12;

        //Paint coverage based on 1L emulsion pot covering 12m squared.

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Calculations()
        {
            FloorArea = Room_Width * Room_Length;

            WallAreas = ((Room_Width * 2) + (Room_Length * 2)) * Room_Height;

            //Uses Width and length as room may not be a cube.
                        
            Paint_Required = WallAreas / Paint_Coveravge;

            RoomVolume = Room_Width * Room_Length * Room_Height;
        }

        public void Clear()
        {
            lstResults.Items.Clear();
            txtWidth.Clear();
            txtLength.Clear();
            txtHeight.Clear();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {                            

           try
           {
                Width_Input = txtWidth.Text;
                Length_Input = txtLength.Text;
                Height_Input = txtHeight.Text;

                Room_Width = Convert.ToDecimal(Width_Input);
                Room_Length = Convert.ToDecimal(Length_Input);
                Room_Height = Convert.ToDecimal(Height_Input);

                lstResults.Items.Clear(); 

                Calculations();

                lstResults.Items.Add("Floor Area: " + decimal.Round(FloorArea, 2, MidpointRounding.AwayFromZero) + " Meters Squared");
                lstResults.Items.Add("Paint Required: " + decimal.Round(Paint_Required, 2, MidpointRounding.AwayFromZero) + " Litres");
                lstResults.Items.Add("Room Volume: " + decimal.Round(RoomVolume, 2, MidpointRounding.AwayFromZero) + " Meters Cubed"); 

           }
           catch (Exception)  //Stops crashing if invalid characters are entered.
           {
               MessageBox.Show("Please enter a number into all fields");
               Clear();
           }             
                           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
