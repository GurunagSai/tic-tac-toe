﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        public int player = 2;
        public int turns = 0;
        public int s1 = 0;
        public int s2 = 0;
        public int sd = 0;

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                if (player % 2 == 0)
                {
                    button.Text = "X";
                    player++;
                    turns++;
                }
                else
                {
                    button.Text = "O";
                    player++;
                    turns++;
                }
                if ((CheckDraw() == true) && (CheckWinner() == false))
                {
                    MessageBox.Show("Tie !!");
                    sd++;
                    Draws.Text = "Draws: " + sd;
                    NewGame();
                }
                if (CheckWinner() == true)
                {
                    if (button.Text == "X")
                    {
                        MessageBox.Show("X Won!!");
                        s1++;
                        XWins.Text ="X: "+ s1;
                        NewGame();
                    }
                    else
                    {
                        MessageBox.Show("O Won!!");
                        s2++;
                        OWins.Text = "O: " + s2;
                        NewGame();
                    }

                }
            }
        }

        private void EButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            XWins.Text = "X: " + s1;
            OWins.Text = "O: " + s2;
            Draws.Text = "Draws: " + sd;
        }
        void NewGame()
        {
            player = 2;
            turns = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
        }

        private void NButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        bool CheckDraw()
        {
            if (turns == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool CheckWinner()
        {
            //horizontal
            if ((A00.Text == A01.Text) && (A01.Text == A02.Text) && A00.Text != "")
            {
                return true;
            }
            else if ((A10.Text == A11.Text) && (A11.Text == A12.Text) && A10.Text != "")
            {
                return true;
            }
            else if ((A20.Text == A21.Text) && (A21.Text == A22.Text) && A20.Text != "")
            {
                return true;
            }
            //vertical
            if ((A00.Text == A10.Text) && (A10.Text == A20.Text) && A00.Text != "")
            {
                return true;
            }
            else if ((A01.Text == A11.Text) && (A11.Text == A21.Text) && A01.Text != "")
            {
                return true;
            }
            else if ((A02.Text == A12.Text) && (A12.Text == A22.Text) && A02.Text != "")
            {
                return true;
            }
            //diagonal
            if ((A00.Text == A11.Text) && (A11.Text == A22.Text) && A00.Text != "")
            {
                return true;
            }
            else if ((A02.Text == A11.Text) && (A11.Text == A20.Text) && A02.Text != "")
            {
                return true;
            }
            else
                return false;
        }

        private void RButton_Click(object sender, EventArgs e)
        {
            NewGame();
            s1 = 0;
            s2 = 0;
            sd = 0;
            XWins.Text = "X: " + s1;
            OWins.Text = "O: " + s2;
            Draws.Text = "Draws: " + sd;
        }
    }
}
