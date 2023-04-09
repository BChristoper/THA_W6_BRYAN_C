using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_BRYAN_C
{
    public partial class Form2 : Form
    {

        public string[] CharQWERTYUIOP = { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" };
        public string[] CharASDFGHJKL = { "A", "S", "D", "F", "G", "H", "J", "K", "L" };
        public string[] CharZXCVBNM = { "Z", "X", "C", "V", "B", "N", "M" };
        int Counter = 0;
        int Counter2 = 0;
        int Counter3 = 0;
        int RowCounter = 0;
        int x = 50;
        int y = 50;
        bool enter = false;
        string[] WordTXTlists = File.ReadAllText("WordleWordList.txt").Split(',');
        string answer;
        string Words;

        List<char> duplicates = new List<char>();

        public List<Button> listofbutton = new List<Button>();


        public Form2()
        {
            InitializeComponent();
            Random random = new Random();
            answer = WordTXTlists[random.Next(0, WordTXTlists.Length - 1)].ToUpper();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            GeneratingKeyboard();

            for (int i = 0; i < Form1.Guessingint; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(x, y);
                    button.Size = new Size(50, 50);
                    button.Tag = Counter2.ToString();
                    button.BackColor = Color.White;    
                    listofbutton.Add(button);
                    x += 52;
                    Counter2 += 1;
                }
                x = 50;
                y += 52;
                Counter2 = 0;
            }

            UpdateButtons();

        }

        private void GeneratingKeyboard()
        {
            Button button = new Button();
            for (int i = 1; i <= 10; i++)
            {
                button = new Button();
                button.Size = new Size(50, 50);
                button.Location = new Point(550 + 55 * i, 100);
                button.Name = "btn" + CharQWERTYUIOP[i - 1];
                button.Text = CharQWERTYUIOP[i - 1];
                button.Enabled = true;
                button.Visible = true;
                button.Click += Btn_Click;
                this.Controls.Add(button);
            }
            for (int i = 1; i <= 9; i++)
            {
                button = new Button();
                button.Size = new Size(50, 50);
                button.Location = new Point(600 + 55 * i, 160);
                button.Name = "btn" + CharASDFGHJKL[i - 1];
                button.Text = CharASDFGHJKL[i - 1];
                button.Enabled = true;
                button.Visible = true;
                button.Click += Btn_Click;
                this.Controls.Add(button);
            }
            for (int i = 1; i <= 7; i++)
            {
                button = new Button();
                button.Size = new Size(50, 50);
                button.Location = new Point(650 + 55 * i, 220);
                button.Name = "btn" + CharZXCVBNM[i - 1];
                button.Text = CharZXCVBNM[i - 1];
                button.Enabled = true;
                button.Visible = true;
                button.Click += Btn_Click;
                this.Controls.Add(button);
            }
            {
                button = new Button();
                button.Size = new Size(90, 50);
                button.Location = new Point(600, 220);
                button.Name = "btnenter";
                button.Text = "Enter";
                button.Enabled = true;
                button.Visible = true;
                button.Click += BtnEnter_Click;
                this.Controls.Add(button);
            }
            {
                button = new Button();
                button.Size = new Size(90, 50);
                button.Location = new Point(1100, 220);
                button.Name = "btndelete";
                button.Text = "Delete";
                button.Enabled = true;
                button.Visible = true;
                button.Click += BtnDelete_Click;
                this.Controls.Add(button);
            }
     
        }

        public void UpdateButtons()
        {
            foreach (Button button in listofbutton)
            {
                this.Controls.Add(button);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (enter == false)
            {
                for (int s = RowCounter; s < RowCounter + 5; s++)
                {
                    Button button = listofbutton[s];
                    if (button.Tag.ToString() == Counter.ToString())
                    {
                        button.Text = btn.Text;
                    }
                }
                Counter += 1;
                UpdateButtons();
            }

            if (Counter % 5 == 0 && Counter != 0)
            {
                enter = true;
            }
        }


        private void BtnEnter_Click(object sender, EventArgs e)
        {
            int Check1 = 0;
            int Check2 = 0;

            for (int s = RowCounter; s < RowCounter + 5; s++)
            {
                Button btnn = listofbutton[s];
                if (btnn.Text == "" || btnn.Text == " ")
                {
                    Check2 = 1;
                }
                else
                {
                    Words += btnn.Text;
                }
            }

            for (int i = 0; i < WordTXTlists.Length - 1; i++)
            {
                if (Words == WordTXTlists[i].ToUpper())
                {
                    Check1 = 1;
                }
            }

            if (Check2 == 1)
            {
                MessageBox.Show("Enter a 5 letter word!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Words = "";
                Check2 = 0;
            }
            else if (Check1 == 0)
            {
                MessageBox.Show(Words + " is is not valid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Words = "";
            }
            else
            {
                for (int j = 0; j < answer.Length; j++)
                {
                    if (Words != "")
                    {
                        if (Words[j] == answer[0] || Words[j] == answer[1] || Words[j] == answer[2] || Words[j] == answer[3] || Words[j] == answer[4])
                        {
                            for (int p = RowCounter; p < RowCounter + 5; p++)
                            {
                                Button button = listofbutton[p];
                                if (Words[j].ToString() == button.Text)
                                {
                                    button.BackColor = Color.LightYellow;
                                    Counter3 += 1;
                                }
                                if (Counter3 > 1 && !duplicates.Contains(Words[j]))
                                {
                                    button.BackColor = Color.White;
                                }
                            }
                            Counter3 = 0;
                        }
                    }
                }

                for (int i = 0; i < answer.Length; i++)
                {
                    if (Words != "")
                    {
                        if (Words[i] == answer[i])
                        {
                            for (int p = RowCounter; p < RowCounter + 5; p++)
                            {
                                Button button = listofbutton[p];
                                if (Words[i].ToString() == button.Text && i == Convert.ToInt32(button.Tag))
                                {
                                    button.BackColor = Color.LightGreen;
                                }
                            }
                        }
                    }
                }

                for (int p = RowCounter; p < RowCounter + 5; p++)
                {
                    Button but = listofbutton[p];
                    char chara = char.Parse(but.Text);
                    if (but.BackColor == Color.LightGreen && !duplicates.Contains(chara))
                    {
                        string duh = but.Text;
                        for (int s = RowCounter; s < RowCounter + 5; s++)
                        {
                            Button but2 = listofbutton[s];
                            if (but2.BackColor == Color.LightYellow && but2.Text == duh)
                            {
                                but2.BackColor = Color.White;
                            }

                        }
                    }
                }


                Counter3 = 0;
                if (Words == answer)
                {
                    MessageBox.Show("You win"," ", MessageBoxButtons.OK);
                    this.Close();
                }
                else if (RowCounter == 5 * Form1.Guessingint - 5)
                {
                    MessageBox.Show("You Lost The Answer is: " + answer);
                    this.Close();
                }

                if (Words != "")
                {
                    RowCounter += 5;
                    Counter = 0;
                }
                Words = "";
                enter = false;

            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            enter = false;
            Words = "";
            if (Counter > 0)
            {
                Counter -= 1;
            }
            for (int s = RowCounter; s < RowCounter + 5; s++)
            {
                Button button = listofbutton[s];
                if (button.Tag.ToString() == Counter.ToString())
                {
                    button.Text = " ";
                }
            }
            UpdateButtons();

        }

    }
}
       
        
    
