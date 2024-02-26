using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create an int guess variable to track what part of the pattern the user is at

        Random rng = new Random();
        public static int round = 1;
        int guess = 0;
        int timer = 5;
        int delay = 500;
        int rSpace, bSpace, gSpace, ySpace;
        List<Color> colorList = new List<Color>();

        public GameScreen()
        {
            InitializeComponent();
            colorList.Add(Color.ForestGreen);
            colorList.Add(Color.DarkRed);
            colorList.Add(Color.Goldenrod);
            colorList.Add(Color.DarkBlue);
            colorList.Add(Color.LimeGreen);
            colorList.Add(Color.LightCoral);
            colorList.Add(Color.Yellow);
            colorList.Add(Color.SkyBlue);
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Refresh();
            delay = 500;
            timer = 5;
            round = 1;
            Form1.pattern.Clear();

            if (MenuScreen.timer == true)
            {
                timerLabel.Visible = true;
            }
            else
            {
                timerLabel.Visible = false;
            }

            ComputerTurn();
        }

        private void ComputerTurn()
        {
            Game_Tick.Stop();
            timer = 5;
            Thread.Sleep(500);


            if (MenuScreen.reverse == true)
            {
                Form1.pattern.Reverse();
            }

            Form1.pattern.Add(rng.Next(0, 4));


            #region lights up colour
            for (int i = 0; i < round; i++)
            {
                Thread.Sleep(delay);

                switch (Form1.pattern[i])
                {
                    case 0:
                        greenButton.BackColor = Color.LimeGreen;
                        Refresh();
                        Thread.Sleep(delay);
                        greenButton.BackColor = Color.ForestGreen;
                        Refresh();
                        break;
                    case 1:
                        redButton.BackColor = Color.LightCoral;
                        Refresh();
                        Thread.Sleep(delay);
                        redButton.BackColor = Color.DarkRed;
                        Refresh();
                        break;
                    case 2:
                        yellowButton.BackColor = Color.Yellow;
                        Refresh();
                        Thread.Sleep(delay);
                        yellowButton.BackColor = Color.Goldenrod;
                        Refresh();
                        break;
                    case 3:
                        blueButton.BackColor = Color.SkyBlue;
                        Refresh();
                        Thread.Sleep(delay);
                        blueButton.BackColor = Color.DarkBlue;
                        Refresh();
                        break;
                }
            }
            #endregion

            guess = 0;

            gameMode();

            Game_Tick.Start();
        }

        private void gameMode()
        {
            #region speedUp
            if (MenuScreen.speed == true)
            {
                if (round % 3 == 0)
                {
                    delay -= 75;
                }

                if (delay <= 0)
                {
                    delay = 10;
                }
            }
            #endregion

            #region reverse 
            if (MenuScreen.reverse == true)
            {
                Form1.pattern.Reverse();
            }
            #endregion

            #region swap 
            if (MenuScreen.swap == true)
            {
                rSpace = rng.Next(0, 4);
                changeSpace(rSpace, redButton);
                bSpace = rng.Next(0, 4);
                while (bSpace == rSpace)
                {
                    bSpace = rng.Next(0, 4);
                }
                changeSpace(bSpace, blueButton);
                ySpace = rng.Next(0, 4);
                while (ySpace == rSpace || ySpace == bSpace)
                {
                    ySpace = rng.Next(0, 4);
                }
                changeSpace(ySpace, yellowButton);
                gSpace = rng.Next(0, 4);
                while (gSpace == rSpace || gSpace == ySpace || gSpace == bSpace)
                {
                    gSpace = rng.Next(0, 4);
                }
                changeSpace(gSpace, greenButton);
            }
            #endregion
        }

        private void changeSpace(int space, Button b)
        {
            switch (space)
            {
                case 0:
                    b.Location = new Point(40, 38);
                    break;
                case 1:
                    b.Location = new Point(152, 38);
                    break;
                case 2:
                    b.Location = new Point(40, 150);
                    break;
                case 3:
                    b.Location = new Point(152, 150);
                    break;
            }
        }

        private void playerTurn(int colour, SoundPlayer sound, Button b)
        {
            b.BackColor = colorList[colour + 4];
            Refresh();
            sound.Play();
            Thread.Sleep(200);
            b.BackColor = colorList[colour];
            Refresh();

            if (colour == Form1.pattern[guess])
            {
                guess++;
            }
            else
            {
                GameOver();
            }

            if (guess >= round)
            {
                round++;
                ComputerTurn();
            }

        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            playerTurn(0, Form1.gSound, greenButton);

        }

        private void redButton_Click(object sender, EventArgs e)
        {
            playerTurn(1, Form1.rSound, redButton);
        }

        private void Game_Tick_Tick(object sender, EventArgs e)
        {
            if (MenuScreen.timer == true)
            {
                timer--;
                timerLabel.Text = $"{timer}";
                Refresh();
            }


            if (timer == 0)
            {
                GameOver();
            }

        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            playerTurn(2, Form1.ySound, yellowButton);
        }
        private void blueButton_Click(object sender, EventArgs e)
        {
            playerTurn(3, Form1.bSound, blueButton);
        }

        public void GameOver()
        {
            Game_Tick.Stop();

            Form1.lSound.Play();

            Form1.ChangeScreen(this, new GameOverScreen());
        }


    }
}
