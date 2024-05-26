using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Камък__Ножица__Хартия
{
    public partial class КамъкНожицаХартия : Form
    {
        public int rounds = 50;
        public int timePerRound = 6;
        public int playerWins = 0;
        public int AIWins = 0;
        public int draws = 0;
        string[] AIchoice = new string[3] { "ROCK", "PAPER", "SCISSOR" };
        string command;
        public int n;
        Random rnd = new Random();
        string playerChoice;


        public КамъкНожицаХартия()
        {
            InitializeComponent();
            Време.Enabled = true;
            playerChoice = "none";
        }

        private void КамъкНожицаХартия_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Време_Tick(object sender, EventArgs e)
        {
            timePerRound--;
            label9.Text = Convert.ToString(timePerRound);
            label8.Text = Convert.ToString(rounds);

            if (timePerRound < 1)
            {
                Време.Enabled = false;

                timePerRound = 6;
                n = rnd.Next(0, 3);
                command = AIchoice[n];

                switch (command)
                {
                    case "ROCK":
                        pictureBox2.Image = Properties.Resources.rock;
                        break;

                    case "PAPER":
                        pictureBox2.Image = Properties.Resources.paper;
                        break;

                    case "SCISSOR":
                        pictureBox2.Image = Properties.Resources.scissors;
                        break;

                    default:
                        break;
                }

                if (rounds > 1)
                {
                    checkGame();
                }
                else if (rounds == 1)
                {
                    checkGame();
                    decisionEngine();
                }
            }
        }
        private void checkGame()
        {
            if (playerChoice == "ROCK" && command == "SCISSOR")
            {
                MessageBox.Show("Ти победи");
                playerWins += 1;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "ROCK" && command == "PAPER")
            {
                MessageBox.Show("Компютъра победи");
                AIWins += 1;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "PAPER" && command == "ROCK")
            {
                MessageBox.Show("Ти победи");
                playerWins += 1;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "PAPER" && command == "SCISSOR")
            {
                MessageBox.Show("Компютъра победи");
                AIWins += 1;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "SCISSOR" && command == "ROCK")
            {
                MessageBox.Show("Компютъра победи");
                AIWins += 1;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "SCISSOR" && command == "PAPER")
            {
                MessageBox.Show("Ти победи");
                playerWins += 1;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "none")
            {
                MessageBox.Show("ИЗБЕРИ!");
                nextRound();
            }
            else
            {
                MessageBox.Show("Равни");
                draws += 1;
                rounds--;
                nextRound();
            }
        }

        private void decisionEngine()
        {
            if (playerWins > AIWins)
            {
                MessageBox.Show(label1.Text + " спечели играта");
            }
            else if (playerWins < AIWins)
            {
                MessageBox.Show("Компютърът спечели играта");
            }
            else if (playerWins == AIWins)
            {
                MessageBox.Show("Равенство");
            }
        }

        private void nextRound()
        {
            playerChoice = "none";
            pictureBox1.Image = Properties.Resources.qq;
            Време.Enabled = true;
            pictureBox2.Image = Properties.Resources.qq;
            label8.Text = Convert.ToString(rounds);
            label2.Text = Convert.ToString(playerWins);
            label4.Text = Convert.ToString(AIWins);
            label6.Text = Convert.ToString(draws);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            playerChoice = "ROCK";
            pictureBox1.Image = Properties.Resources.rock;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playerChoice = "PAPER";
            pictureBox1.Image = Properties.Resources.paper;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            playerChoice = "SCISSOR";
            pictureBox1.Image = Properties.Resources.scissors;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timePerRound = 6;
            nextRound();
        }
    }
}
