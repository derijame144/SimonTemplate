using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class MenuScreen : UserControl
    {
        bool all = false;
        public static bool swap = false;
        public static bool reverse = false;
        public static bool speed = false;
        public static bool timer = false;

        public MenuScreen()
        {
            InitializeComponent();
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            //makes sure the button colours are right when screen loads 
            if (swap == true)
            {
                swapButton.BackColor = Color.Green;
            }
            else
            {
                swapButton.BackColor = Color.Crimson;
            }

            if (reverse == true)
            {
                reverseButton.BackColor = Color.Green;
            }
            else
            {
                reverseButton.BackColor = Color.Crimson;
            }

            if (speed == true)
            {
                speedButton.BackColor = Color.Green;
            }
            else
            {
                speedButton.BackColor = Color.Crimson;
            }

            if (timer == true)
            {
                timerButton.BackColor = Color.Green;
            }
            else
            {
                timerButton.BackColor = Color.Crimson;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // turns on and off the differnt game modes
        private void hardButton_Click(object sender, EventArgs e)
        {
            if (swap == false)
            {
                swap = true;
                swapButton.BackColor = Color.Green;
            }
            else
            {
                swap = false;
                swapButton.BackColor = Color.Crimson;
            }
        }

        private void reverseButton_Click(object sender, EventArgs e)
        {
            if (reverse == false)
            {
                reverse = true;
                reverseButton.BackColor = Color.Green;
            }
            else
            {
                reverse = false;
                reverseButton.BackColor = Color.Crimson;
            }
        }

        private void speedButton_Click(object sender, EventArgs e)
        {
            if (speed == false)
            {
                speed = true;
                speedButton.BackColor = Color.Green;
            }
            else
            {
                speed = false;
                speedButton.BackColor = Color.Crimson;
            }
        }

        private void timerButton_Click(object sender, EventArgs e)
        {
            if (timer == false)
            {
                timer = true;
                timerButton.BackColor = Color.Green;
            }
            else
            {
                timer = false;
                timerButton.BackColor = Color.Crimson;
            }
        }

        //toggles on and off all the game modes at the same time
        private void allButton_Click(object sender, EventArgs e)
        {
            if (all == false)
            {
                if (timer == true && reverse == true && speed == true && swap == true)
                {
                    all = false;

                    reverse = false;
                    reverseButton.BackColor = Color.Crimson;
                    speed = false;
                    speedButton.BackColor = Color.Crimson;
                    speed = false;
                    speedButton.BackColor = Color.Crimson;
                    swap = false;
                    swapButton.BackColor = Color.Crimson;
                    timer = false;
                    timerButton.BackColor = Color.Crimson;
                }
                else
                {
                    all = true;

                    reverse = true;
                    reverseButton.BackColor = Color.Green;
                    speed = true;
                    speedButton.BackColor = Color.Green;
                    speed = true;
                    speedButton.BackColor = Color.Green;
                    swap = true;
                    swapButton.BackColor = Color.Green;
                    timer = true;
                    timerButton.BackColor = Color.Green;
                }

            }
            else
            {
                if (timer == false && reverse == false && speed == false && swap == false)
                {
                    all = true;

                    reverse = true;
                    reverseButton.BackColor = Color.Green;
                    speed = true;
                    speedButton.BackColor = Color.Green;
                    speed = true;
                    speedButton.BackColor = Color.Green;
                    swap = true;
                    swapButton.BackColor = Color.Green;
                    timer = true;
                    timerButton.BackColor = Color.Green;
                }
                else
                {
                    all = false;

                    reverse = false;
                    reverseButton.BackColor = Color.Crimson;
                    speed = false;
                    speedButton.BackColor = Color.Crimson;
                    speed = false;
                    speedButton.BackColor = Color.Crimson;
                    swap = false;
                    swapButton.BackColor = Color.Crimson;
                    timer = false;
                    timerButton.BackColor = Color.Crimson;
                }
            }
        }


    }
}
