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
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
            
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //displays gameover message and pattern length
            patternLabel.Text = "Your pattern length was:";
            lengthLabel.Text = $"{GameScreen.round - 1}";
            Refresh();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //changes screens 
            Form1.ChangeScreen(this, new MenuScreen());
        }
    }
}
