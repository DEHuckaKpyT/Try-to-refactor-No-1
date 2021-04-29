namespace KuRa
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuGroupBox = new System.Windows.Forms.GroupBox();
            this.ButtonColorMe = new System.Windows.Forms.Button();
            this.ButtonColorEnemy = new System.Windows.Forms.Button();
            this.LoadComboBox = new System.Windows.Forms.ComboBox();
            this.SaveGameTextBox = new System.Windows.Forms.TextBox();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveGameButton = new System.Windows.Forms.Button();
            this.StartNewGameButton = new System.Windows.Forms.Button();
            this.ContinueGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.MenuGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuGroupBox
            // 
            this.MenuGroupBox.BackColor = System.Drawing.Color.White;
            this.MenuGroupBox.Controls.Add(this.ButtonColorMe);
            this.MenuGroupBox.Controls.Add(this.ButtonColorEnemy);
            this.MenuGroupBox.Controls.Add(this.LoadComboBox);
            this.MenuGroupBox.Controls.Add(this.SaveGameTextBox);
            this.MenuGroupBox.Controls.Add(this.LoadGameButton);
            this.MenuGroupBox.Controls.Add(this.ExitButton);
            this.MenuGroupBox.Controls.Add(this.SaveGameButton);
            this.MenuGroupBox.Controls.Add(this.StartNewGameButton);
            this.MenuGroupBox.Controls.Add(this.ContinueGameButton);
            this.MenuGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuGroupBox.Location = new System.Drawing.Point(237, 191);
            this.MenuGroupBox.Name = "MenuGroupBox";
            this.MenuGroupBox.Size = new System.Drawing.Size(240, 360);
            this.MenuGroupBox.TabIndex = 0;
            this.MenuGroupBox.TabStop = false;
            this.MenuGroupBox.Text = "Крестики-нолики";
            this.MenuGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuGroupBox_Paint);
            this.MenuGroupBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MenuGroupBox_PreviewKeyDown);
            // 
            // ButtonColorMe
            // 
            this.ButtonColorMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonColorMe.Location = new System.Drawing.Point(120, 279);
            this.ButtonColorMe.Name = "ButtonColorMe";
            this.ButtonColorMe.Size = new System.Drawing.Size(114, 22);
            this.ButtonColorMe.TabIndex = 7;
            this.ButtonColorMe.Text = "Мой цвет";
            this.ButtonColorMe.UseVisualStyleBackColor = true;
            this.ButtonColorMe.Click += new System.EventHandler(this.ButtonColorMe_Click);
            // 
            // ButtonColorEnemy
            // 
            this.ButtonColorEnemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonColorEnemy.Location = new System.Drawing.Point(6, 279);
            this.ButtonColorEnemy.Name = "ButtonColorEnemy";
            this.ButtonColorEnemy.Size = new System.Drawing.Size(114, 22);
            this.ButtonColorEnemy.TabIndex = 6;
            this.ButtonColorEnemy.Text = "Цвет противника";
            this.ButtonColorEnemy.UseVisualStyleBackColor = true;
            this.ButtonColorEnemy.Click += new System.EventHandler(this.ButtonColorEnemy_Click);
            // 
            // LoadComboBox
            // 
            this.LoadComboBox.DropDownWidth = 200;
            this.LoadComboBox.FormattingEnabled = true;
            this.LoadComboBox.IntegralHeight = false;
            this.LoadComboBox.ItemHeight = 20;
            this.LoadComboBox.Location = new System.Drawing.Point(6, 230);
            this.LoadComboBox.MaxDropDownItems = 5;
            this.LoadComboBox.Name = "LoadComboBox";
            this.LoadComboBox.Size = new System.Drawing.Size(114, 28);
            this.LoadComboBox.TabIndex = 5;
            this.LoadComboBox.Text = "Название";
            this.LoadComboBox.Enter += new System.EventHandler(this.LoadComboBox_Enter);
            // 
            // SaveGameTextBox
            // 
            this.SaveGameTextBox.Location = new System.Drawing.Point(6, 154);
            this.SaveGameTextBox.Name = "SaveGameTextBox";
            this.SaveGameTextBox.Size = new System.Drawing.Size(114, 26);
            this.SaveGameTextBox.TabIndex = 4;
            this.SaveGameTextBox.Text = "Название";
            this.SaveGameTextBox.Enter += new System.EventHandler(this.SaveGameTextBox_Enter);
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Location = new System.Drawing.Point(131, 226);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(103, 35);
            this.LoadGameButton.TabIndex = 3;
            this.LoadGameButton.Text = "Загрузить";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(6, 319);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(228, 35);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SaveGameButton
            // 
            this.SaveGameButton.Location = new System.Drawing.Point(130, 150);
            this.SaveGameButton.Name = "SaveGameButton";
            this.SaveGameButton.Size = new System.Drawing.Size(104, 35);
            this.SaveGameButton.TabIndex = 2;
            this.SaveGameButton.Text = "Сохранить";
            this.SaveGameButton.UseVisualStyleBackColor = true;
            this.SaveGameButton.Click += new System.EventHandler(this.SaveGameButton_Click);
            // 
            // StartNewGameButton
            // 
            this.StartNewGameButton.Location = new System.Drawing.Point(6, 87);
            this.StartNewGameButton.Name = "StartNewGameButton";
            this.StartNewGameButton.Size = new System.Drawing.Size(228, 35);
            this.StartNewGameButton.TabIndex = 1;
            this.StartNewGameButton.Text = "Начать новую";
            this.StartNewGameButton.UseVisualStyleBackColor = true;
            this.StartNewGameButton.Click += new System.EventHandler(this.StartNewGameButton_Click);
            // 
            // ContinueGameButton
            // 
            this.ContinueGameButton.Location = new System.Drawing.Point(6, 25);
            this.ContinueGameButton.Name = "ContinueGameButton";
            this.ContinueGameButton.Size = new System.Drawing.Size(228, 35);
            this.ContinueGameButton.TabIndex = 0;
            this.ContinueGameButton.Text = "Продолжить игру";
            this.ContinueGameButton.UseVisualStyleBackColor = true;
            this.ContinueGameButton.Click += new System.EventHandler(this.ContinueGameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esc";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(704, 682);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MenuGroupBox);
            this.MinimumSize = new System.Drawing.Size(540, 540);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Крестики-нолики";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MenuGroupBox.ResumeLayout(false);
            this.MenuGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MenuGroupBox;
        private System.Windows.Forms.Button StartNewGameButton;
        private System.Windows.Forms.Button ContinueGameButton;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveGameButton;
        private System.Windows.Forms.ComboBox LoadComboBox;
        private System.Windows.Forms.TextBox SaveGameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ButtonColorMe;
        private System.Windows.Forms.Button ButtonColorEnemy;
    }
}

