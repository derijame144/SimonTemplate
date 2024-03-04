using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        //sets up variables 
        public static List<int> pattern = new List<int>();
        public static SoundPlayer bSound = new SoundPlayer(Properties.Resources.blue);
        public static SoundPlayer rSound = new SoundPlayer(Properties.Resources.red);
        public static SoundPlayer ySound = new SoundPlayer(Properties.Resources.yellow);
        public static SoundPlayer gSound = new SoundPlayer(Properties.Resources.green);
        public static SoundPlayer lSound = new SoundPlayer(Properties.Resources.mistake);
        public Form1()
        {
            InitializeComponent();
            //changes screens 
            ChangeScreen(this, new MenuScreen());
        }

        public static void ChangeScreen(object sender, UserControl next)
        {

            Form f;

            if (sender is Form)
            {
                f = (Form)sender;
            }

            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
            (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);

            next.Focus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Launch MenuScreen

        }
    }
}
