using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KuRa
{
    public partial class Form1 : Form
    {
        Pen p = new Pen(Color.Black, 3);
        Pen penPlayer = new Pen(Color.Black, 3);
        Pen penAI = new Pen(Color.Black, 3);
        int i, j;
        int[,] ground = new int[6, 6];
        public static bool isActiveGround;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ground = Actions.LoadGame("AutoSave.txt", ground);
            Actions.UpdateWindowSize(Width, Height);
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
            isActiveGround = true;
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
                {
                    ground[i, j] = 0;
                }
            Controls.Remove(MenuGroupBox);
            Invalidate();
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
            Invalidate();
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
            if (isActiveGround)
            {
                if (PlayerDoneTurn(e.X, e.Y))
                {
                    if (ClassAI.HasWinner(ref ground))
                    {
                        ShowWin(-3);
                        return;
                    }

                    ground = ClassAI.DoMachineTurn(ground);

                    if (ClassAI.HasWinner(ref ground))
                    {
                        ShowWin(-4);
                        return;
                    }

                    if (ClassAI.IsDraw(ground))
                    {
                        for (i = 0; i < 6; i++)
                            for (j = 0; j < 6; j++)
                                ground[i, j] -= 2;
                        isActiveGround = false;
                    }
                }
            }

            Invalidate();
        }

        bool PlayerDoneTurn(int cursorX, int cursorY)
        {
            bool playerDoneTurn = false;

            for (i = 0; i < 6; i++)
                if (cursorX - 1 < Actions.widlen + Actions.part * (i + 2)
                    && cursorX - 1 > Actions.widlen + Actions.part * (i + 1))//по горизонтали
                    for (j = 0; j < 6; j++)//здесь я ищу, в какую клетку кликнул пользователь
                        if (cursorY - 1 < Actions.heilen + Actions.part * (j + 2)
                            && cursorY - 1 > Actions.heilen + Actions.part * (j + 1))//по вертикали
                        {
                            if (ground[i, j] == -1 || ground[i, j] == -2) return false;
                            ground[i, j] = -1;
                            playerDoneTurn = true;
                        }

            return playerDoneTurn;
        }

        void ShowWin(int whoseTurn)
        {
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
                    if (ground[i, j] != whoseTurn) ground[i, j] = 0;
            isActiveGround = false;
            Invalidate();
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
            Graphics g = e.Graphics;
            //рисуются полоски в меню, чтобы было видно цвет игрока и машины
            g.DrawLine(new Pen(penAI.Color, 16), 7, 310, 119, 310);
            g.DrawLine(new Pen(penPlayer.Color, 16), 121, 310, 233, 310);
        }

        private void ButtonColorEnemy_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
            penAI.Color = colorDialog1.Color;
            Invalidate();
        }

        private void ButtonColorMe_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
            penPlayer.Color = colorDialog1.Color;
            Invalidate();
        }

        private void LoadComboBox_Enter(object sender, EventArgs e)
        {
            LoadComboBox.Items.Clear();
            var names = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Saves/", "*.txt");
            foreach (var name in names)
                LoadComboBox.Items.Add(Path.GetFileName(name).Remove(Path.GetFileName(name).Length - 4));
            if (names.Count() < 7) 
                LoadComboBox.DropDownHeight = names.Count() * 20 + 2; //чтобы при раскрытии списка, всё было красиво
            else 
                LoadComboBox.DropDownHeight = 142;//на столько пикселей раскрывается список, елси в нём много элементов
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Actions.SaveGame("AutoSave.txt", ground);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Actions.UpdateWindowSize(Width, Height);
            MenuGroupBox.Location = new Point(Width / 2 - MenuGroupBox.Width / 2, Height / 2 - MenuGroupBox.Height / 2);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Actions.DrawGrid(g, p);
            for (i = 0; i < 6; i++)
                for (j = 0; j < 6; j++)
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
        }
    }
}