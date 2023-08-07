﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int boruHızı = 8;
        int gravity = 10;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ScoreText_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            BoruAlt.Left -= boruHızı;
            BoruUst.Left -= boruHızı;
            ScoreText.Text = "Score: " + score;

            if (BoruAlt.Left < -150)
            {
                BoruAlt.Left = 800;
                score++;
            }
            if(BoruUst.Left < -180)
            {
                BoruUst.Left = 950;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(BoruAlt.Bounds) || flappyBird.Bounds.IntersectsWith(BoruUst.Bounds) || flappyBird.Bounds.IntersectsWith(Zemin.Bounds))
            {
                endGame();
            }
            if (score > 5)
            {
                boruHızı = 15;
            }
            if(flappyBird.Top<-25){
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            ScoreText.Text = "Game Over !!!";
        }
    }
}
