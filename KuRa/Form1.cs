using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KuRa
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p = new Pen(Color.Black, 3);
        Pen penPlayer = new Pen(Color.Black, 3);
        Pen penAI = new Pen(Color.Black, 3);
        int i, j, k, imax, jmax, max;
        int[,] ground = new int[6, 6];
        bool flag;
        public static bool activeGround;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ground = Actions.LoadGame("AutoSave.txt", ground);
            Actions.Update(Width, Height);
            ContinueGameButton.PreviewKeyDown += MenuGroupBox_PreviewKeyDown;
            StartNewGameButton.PreviewKeyDown += MenuGroupBox_PreviewKeyDown;
            SaveGameButton.PreviewKeyDown += MenuGroupBox_PreviewKeyDown;
            LoadGameButton.PreviewKeyDown += MenuGroupBox_PreviewKeyDown;
            ExitButton.PreviewKeyDown += MenuGroupBox_PreviewKeyDown;
            SaveGameTextBox.PreviewKeyDown += MenuGroupBox_PreviewKeyDown;
            LoadComboBox.PreviewKeyDown += MenuGroupBox_PreviewKeyDown;
            ButtonColorEnemy.PreviewKeyDown += MenuGroupBox_PreviewKeyDown;
            ButtonColorMe.PreviewKeyDown += MenuGroupBox_PreviewKeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Escape == e.KeyCode)
            {
                SaveGameTextBox.Text = "Название";
                Controls.Add(MenuGroupBox);
                MenuGroupBox.BringToFront();
                ContinueGameButton.Focus();
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Actions.SaveGame("AutoSave.txt", ground);
            Application.Exit();
        }

        private void StartNewGameButton_Click(object sender, EventArgs e)
        {
            activeGround = true;
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
                {
                    ground[i, j] = 0;
                }
            Controls.Remove(MenuGroupBox);
            Refresh();
        }

        private void SaveGameButton_Click(object sender, EventArgs e)
        {
            if (SaveGameTextBox.Text != "")
                Actions.SaveGame(SaveGameTextBox.Text + ".txt", ground);
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            if (LoadComboBox.SelectedItem != null)
                ground = Actions.LoadGame(LoadComboBox.SelectedItem.ToString() + ".txt", ground);
            Controls.Remove(MenuGroupBox);
            Refresh();
        }

        private void MenuGroupBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (Keys.Escape == e.KeyCode)
            {
                Controls.Remove(MenuGroupBox);
                Focus();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (activeGround)
            {
                g = CreateGraphics();
                imax = jmax = 0;
                max = -1;
                flag = false;
                for (i = 0; i < 6; i++)
                {
                    if (e.X - 1 < Actions.widlen + Actions.part * (i + 2) & e.X - 1 > Actions.widlen + Actions.part * (i + 1))
                        for (j = 0; j < 6; j++)
                        {
                            if (e.Y - 1 < Actions.heilen + Actions.part * (j + 2) & e.Y - 1 > Actions.heilen + Actions.part * (j + 1))
                            {
                                if (ground[i, j] == -1 || ground[i, j] == -2) return;
                                ground[i, j] = -1;
                                flag = true;
                                Actions.DrawCross(g, penPlayer, i, j);
                            }
                        }
                }
                if (flag)
                {
                    if (ClassAI.Check(ref ground))
                    {
                        for (i = 0; i < 6; i++)
                            for (j = 0; j < 6; j++)
                                if (ground[i, j] != -3) ground[i,j] = 0;
                        activeGround = false;
                        Refresh();
                        return;
                    }
                    ground = ClassAI.TurnAI(ground);
                    for (i = 0; i < 6; i++)
                        for (j = 0; j < 6; j++)
                            if (ground[i, j] > max)
                            {
                                max = ground[i, j];
                                imax = i;
                                jmax = j;
                            }
                    ground[imax, jmax] = -2;
                    Actions.DrawCircle(g, penAI, imax, jmax);
                    if (ClassAI.Check(ref ground))
                    {
                        for (i = 0; i < 6; i++)
                            for (j = 0; j < 6; j++)
                                if (ground[i, j] != -4) ground[i, j] = 0;
                        activeGround = false;
                        Refresh();
                        return;
                    }
                }
            }
            if (ClassAI.CheckDraw(ground))
            {
                for (i = 0; i < 6; i++)
                    for (j = 0; j < 6; j++)
                        ground[i, j] -= 2;
            activeGround = false;
            Refresh();
            }
            //Refresh();
        }

        private void ContinueGameButton_Click(object sender, EventArgs e)
        {
            Controls.Remove(MenuGroupBox);
        }

        private void SaveGameTextBox_Enter(object sender, EventArgs e)
        {
            SaveGameTextBox.Text = "";
        }

        private void MenuGroupBox_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawLine(new Pen(penAI.Color, 16), 7, 310, 119, 310);
            g.DrawLine(new Pen(penPlayer.Color, 16), 121, 310, 233, 310);
        }

        private void ButtonColorEnemy_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
            penAI.Color = colorDialog1.Color;
            Refresh();
        }

        private void ButtonColorMe_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
            penPlayer.Color = colorDialog1.Color;
            Refresh();
        }

        private void LoadComboBox_Enter(object sender, EventArgs e)
        {
            LoadComboBox.Items.Clear();
            var names = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Saves/", "*.txt");
            foreach (var name in names)
                LoadComboBox.Items.Add(Path.GetFileName(name).Remove(Path.GetFileName(name).Length - 4));
            if (names.Count() < 7) LoadComboBox.DropDownHeight = names.Count() * 20 + 2; else LoadComboBox.DropDownHeight = 142;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Actions.SaveGame("AutoSave.txt", ground);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Actions.Update(Width, Height);
            MenuGroupBox.Location = new Point(Width / 2 - MenuGroupBox.Width / 2, Height / 2 - MenuGroupBox.Height / 2);
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Actions.DrawGrid(g, p);
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
                {
                    switch (ground[i, j])
                    {
                        case -1:
                            Actions.DrawCross(g, penPlayer, i, j);
                            break;
                        case -2:
                            Actions.DrawCircle(g, penAI, i, j);
                            break;
                        case -3:
                            Actions.DrawCross(g, new Pen(Color.Red, 5), i, j);
                            break;
                        case -4:
                            Actions.DrawCircle(g, new Pen(Color.Red, 5), i, j);
                            break;
                    }

                    //Font f = new Font("Times New Roman", 30);
                    //Brush b = new SolidBrush(Color.Black);
                    //g.DrawString(ground[i, j].ToString(), f, b, Width / 2 - Actions.length / 2 + Actions.part * (i + 1), Height / 2 - Actions.length / 2 + Actions.part * (j + 1));
                }
        }
    }
}