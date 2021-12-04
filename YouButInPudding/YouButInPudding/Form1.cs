using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YouButInPudding
{
    public partial class Form1 : Form
    {
        static string[] weights =
            {"kg","lb"};
        static string[] puddins =
            {"Chocolate","Chocolate Sugar Free","Vanilla","Vanilla Sugar Free"};
        static double UserWeight;
        static string calories;
        static string WeighType;
        static string PuddinType;
        static string weightGain;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(weights);
            comboBox2.Items.AddRange(puddins);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object WeighTypeSelec = comboBox1.SelectedItem;
             WeighType = WeighTypeSelec.ToString();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            object PuddinTypeSelec = comboBox2.SelectedItem;
            PuddinType = PuddinTypeSelec.ToString();
        }

        private void caloriCalc()
        {
            double calMultiplier=1;
            double calafterCalc;
            switch (PuddinType)
            {
                case "Chocolate":
                    calMultiplier = 1.087;
                    break;
                case "Vanilla":
                    calMultiplier = 1.087;
                    break;
                case "Chocolate Sugar Free":
                    calMultiplier = .761;
                    break;
                case "Vanilla Sugar Free":
                    calMultiplier = .652;
                    break;
            }
            calafterCalc = calMultiplier * UserWeight; 
            calories = calafterCalc.ToString("F2").TrimEnd('0');
        }

        private void weightGainmeth()
        {
            double weightDivider;
            if (WeighType == "lb")
                weightDivider = 3500;
            else
                weightDivider = 7700;

            double weightGainbfrestr = (Double.Parse(calories)/weightDivider);
            weightGain = weightGainbfrestr.ToString("F2").TrimEnd('0');
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            UserWeight = Double.Parse(textBox1.Text);
            if (WeighType == "lb")
                UserWeight /= 2.205;
            UserWeight *= 1000;
            caloriCalc();
            weightGainmeth();
            richTextBox2.Text = "Calories: " + calories
                +"\nIf eaten you would gain " + weightGain +
                " " + WeighType;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
/* Snack Pack puddings
 *   Chocolate Sugar Free
 *      70 Cal for 92g
 *          ~.761 calories a gram
 *   Vanilla Sugar Free
 *      60 Cal for 92g
 *          ~.652 Calories a gram
 *   Chocolate
 *      100 Cal for 92g
 *          ~1.087 Calories a gram
 *   Vanilla
 *      100 Cal for 92g
 *          ~1.087 Calories a gram
 */