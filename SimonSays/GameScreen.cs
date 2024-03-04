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

        #region global variable set up
        Random rng = new Random();

        public static int round = 1;
        int guess = 0;
        int timer = 5;
        int delay = 500;
        int random;

        List<Color> colorList = new List<Color>();
        List<SoundPlayer> soundList = new List<SoundPlayer>();
        List<int> positionList = new List<int>();
        #endregion

        public GameScreen()
        {
            InitializeComponent();

            #region list setup
            colorList.Add(Color.ForestGreen);
            colorList.Add(Color.DarkRed);
            colorList.Add(Color.Goldenrod);
            colorList.Add(Color.DarkBlue);
            colorList.Add(Color.LimeGreen);
            colorList.Add(Color.LightCoral);
            colorList.Add(Color.Yellow);
            colorList.Add(Color.SkyBlue);
            positionList.Add(0);
            positionList.Add(1);
            positionList.Add(2);
            positionList.Add(3);
            soundList.Add(Form1.gSound);
            soundList.Add(Form1.rSound);
            soundList.Add(Form1.ySound);
            soundList.Add(Form1.bSound);
            #endregion
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //resets game variables when screen loads 
            Refresh();
            delay = 500;
            timer = 5;
            round = 1;
            Form1.pattern.Clear();

            //makes timer visable when game mode is selected  
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
            //stops timer while the computer plays the patterns 
            Game_Tick.Stop();
            timer = 5;
            Thread.Sleep(500);

            //makes sure the pattern is the right way when game mode is selected 
            if (MenuScreen.reverse == true)
            {
                Form1.pattern.Reverse();
            }

            //adds a random colour to the pattern
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

            //sets guess number back to zero 
            guess = 0;

            gameMode();

            //restarts timer
            Game_Tick.Start();
        }

        private void gameMode()
        {
            #region speedUp
            //increases the speed of the pattern every 3 turns 
            if (MenuScreen.speed == true)
            {
                if (round % 3 == 0)
                {
                    delay -= 75;
                }

                //limits the speed
                if (delay <= 0)
                {
                    delay = 10;
                }
            }
            #endregion

            #region reverse 
            //reverses the pattern
            if (MenuScreen.reverse == true)
            {
                Form1.pattern.Reverse();
            }
            #endregion

            #region swap 
            if (MenuScreen.swap == true)
            {
                //picks a ramdom position and adds it to list if its not already in it
                positionList.Clear();

                for (int i = 0; i < 4; i++)
                {
                    random = rng.Next(0, 4);

                    while (positionList.Contains(random))
                    {
                        random = rng.Next(0, 4);
                    }

                    positionList.Add(random);
                }

                //changes all the positions 
                changeSpace(positionList[0], redButton);
                changeSpace(positionList[1], blueButton);
                changeSpace(positionList[2], greenButton);
                changeSpace(positionList[3], yellowButton);
            }
            #endregion
        }

        private void changeSpace(int space, Button b)
        {
            //moves the selected colour to the selected spot
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

        private void playerTurn(int colour, Button b)
        {
            //changes the buttons colour
            b.BackColor = colorList[colour + 4];
            Refresh();
            //plays buttons sound
            soundList[colour].Play();
            Thread.Sleep(200);
            //changes the buttons colour back
            b.BackColor = colorList[colour];
            Refresh();

            //if the colour pressed is the same as the one played goes to the next colour in the list
            //if not ends game 
            if (colour == Form1.pattern[guess])
            {
                guess++;
            }
            else
            {
                GameOver();
            }

            //if the number of guess is the same as the round number it goes to the next round 
            if (guess >= round)
            {
                round++;
                ComputerTurn();
            }

        }


        private void greenButton_Click(object sender, EventArgs e)
        {
            playerTurn(0, greenButton);

        }

        private void redButton_Click(object sender, EventArgs e)
        {
            playerTurn(1, redButton);
        }

        private void Game_Tick_Tick(object sender, EventArgs e)
        {
            //decreases the timer every tick 
            if (MenuScreen.timer == true)
            {
                timer--;
                timerLabel.Text = $"{timer}";
                Refresh();
            }

            //ends game if timer reaches 0 
            if (timer == 0)
            {
                GameOver();
            }

        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            playerTurn(2, yellowButton);
        }
        private void blueButton_Click(object sender, EventArgs e)
        {
            playerTurn(3, blueButton);
        }

        public void GameOver()
        {
            // stops timer plays game over sound and switches screens 
            Game_Tick.Stop();

            Form1.lSound.Play();

            Form1.ChangeScreen(this, new GameOverScreen());
        }


    }
}
