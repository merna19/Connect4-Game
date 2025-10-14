namespace Connect_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            restartBtn = new Button();
            quitBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            menuStrip1 = new MenuStrip();
            player1ToolStripMenuItem = new ToolStripMenuItem();
            coinsColorToolStripMenuItem = new ToolStripMenuItem();
            goldToolStripMenuItem = new ToolStripMenuItem();
            silverToolStripMenuItem = new ToolStripMenuItem();
            greenToolStripMenuItem = new ToolStripMenuItem();
            yellowToolStripMenuItem = new ToolStripMenuItem();
            player2ToolStripMenuItem = new ToolStripMenuItem();
            coinsColorToolStripMenuItem1 = new ToolStripMenuItem();
            goldToolStripMenuItem1 = new ToolStripMenuItem();
            silverToolStripMenuItem1 = new ToolStripMenuItem();
            greenToolStripMenuItem1 = new ToolStripMenuItem();
            yellowToolStripMenuItem1 = new ToolStripMenuItem();
            aIModeToolStripMenuItem = new ToolStripMenuItem();
            enableToolStripMenuItem = new ToolStripMenuItem();
            disableToolStripMenuItem = new ToolStripMenuItem();
            comboBox1 = new ComboBox();
            label3 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // restartBtn
            // 
            restartBtn.BackColor = SystemColors.Highlight;
            restartBtn.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            restartBtn.ForeColor = SystemColors.ControlLightLight;
            restartBtn.Location = new Point(20, 140);
            restartBtn.Name = "restartBtn";
            restartBtn.Size = new Size(159, 79);
            restartBtn.TabIndex = 0;
            restartBtn.Text = "Restart";
            restartBtn.UseVisualStyleBackColor = false;
            restartBtn.Click += restartBtn_Click;
            // 
            // quitBtn
            // 
            quitBtn.BackColor = Color.LightCoral;
            quitBtn.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            quitBtn.ForeColor = SystemColors.ControlLightLight;
            quitBtn.Location = new Point(20, 245);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(159, 74);
            quitBtn.TabIndex = 2;
            quitBtn.Text = "Quit";
            quitBtn.UseVisualStyleBackColor = false;
            quitBtn.Click += quitBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Ravie", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(830, 250);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.MinimumSize = new Size(513, 200);
            label1.Name = "label1";
            label1.Size = new Size(513, 200);
            label1.TabIndex = 3;
            label1.Text = "PLayer 1 Wins ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT Condensed", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Tomato;
            label2.Location = new Point(0, 36);
            label2.MinimumSize = new Size(1000, 0);
            label2.Name = "label2";
            label2.Size = new Size(1000, 56);
            label2.TabIndex = 4;
            label2.Text = "Connect 4";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { player1ToolStripMenuItem, player2ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1022, 36);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // player1ToolStripMenuItem
            // 
            player1ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { coinsColorToolStripMenuItem });
            player1ToolStripMenuItem.Font = new Font("Sitka Display", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            player1ToolStripMenuItem.ForeColor = SystemColors.ActiveCaption;
            player1ToolStripMenuItem.Name = "player1ToolStripMenuItem";
            player1ToolStripMenuItem.Size = new Size(87, 32);
            player1ToolStripMenuItem.Text = "Player 1";
            // 
            // coinsColorToolStripMenuItem
            // 
            coinsColorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { goldToolStripMenuItem, silverToolStripMenuItem, greenToolStripMenuItem, yellowToolStripMenuItem });
            coinsColorToolStripMenuItem.Font = new Font("Snap ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            coinsColorToolStripMenuItem.ForeColor = SystemColors.ActiveCaption;
            coinsColorToolStripMenuItem.Name = "coinsColorToolStripMenuItem";
            coinsColorToolStripMenuItem.Size = new Size(198, 26);
            coinsColorToolStripMenuItem.Text = "Coins Color";
            // 
            // goldToolStripMenuItem
            // 
            goldToolStripMenuItem.ForeColor = Color.Gold;
            goldToolStripMenuItem.Name = "goldToolStripMenuItem";
            goldToolStripMenuItem.Size = new Size(148, 26);
            goldToolStripMenuItem.Text = "Gold";
            goldToolStripMenuItem.Click += P1Gold;
            // 
            // silverToolStripMenuItem
            // 
            silverToolStripMenuItem.ForeColor = Color.Silver;
            silverToolStripMenuItem.Name = "silverToolStripMenuItem";
            silverToolStripMenuItem.Size = new Size(148, 26);
            silverToolStripMenuItem.Text = "Silver";
            silverToolStripMenuItem.Click += P1Silver;
            // 
            // greenToolStripMenuItem
            // 
            greenToolStripMenuItem.ForeColor = Color.PaleGreen;
            greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            greenToolStripMenuItem.Size = new Size(148, 26);
            greenToolStripMenuItem.Text = "Green";
            greenToolStripMenuItem.Click += P1Green;
            // 
            // yellowToolStripMenuItem
            // 
            yellowToolStripMenuItem.ForeColor = Color.Yellow;
            yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            yellowToolStripMenuItem.Size = new Size(148, 26);
            yellowToolStripMenuItem.Text = "Yellow";
            yellowToolStripMenuItem.Click += P1Yellow;
            // 
            // player2ToolStripMenuItem
            // 
            player2ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { coinsColorToolStripMenuItem1, aIModeToolStripMenuItem });
            player2ToolStripMenuItem.Font = new Font("Sitka Display", 14.2499981F, FontStyle.Bold | FontStyle.Italic);
            player2ToolStripMenuItem.ForeColor = Color.RosyBrown;
            player2ToolStripMenuItem.Name = "player2ToolStripMenuItem";
            player2ToolStripMenuItem.Size = new Size(89, 32);
            player2ToolStripMenuItem.Text = "Player 2";
            // 
            // coinsColorToolStripMenuItem1
            // 
            coinsColorToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { goldToolStripMenuItem1, silverToolStripMenuItem1, greenToolStripMenuItem1, yellowToolStripMenuItem1 });
            coinsColorToolStripMenuItem1.Font = new Font("Snap ITC", 12F, FontStyle.Bold);
            coinsColorToolStripMenuItem1.ForeColor = Color.IndianRed;
            coinsColorToolStripMenuItem1.Name = "coinsColorToolStripMenuItem1";
            coinsColorToolStripMenuItem1.Size = new Size(198, 26);
            coinsColorToolStripMenuItem1.Text = "Coins Color";
            // 
            // goldToolStripMenuItem1
            // 
            goldToolStripMenuItem1.ForeColor = Color.Gold;
            goldToolStripMenuItem1.Name = "goldToolStripMenuItem1";
            goldToolStripMenuItem1.Size = new Size(148, 26);
            goldToolStripMenuItem1.Text = "Gold";
            goldToolStripMenuItem1.Click += goldToolStripMenuItem1_Click;
            // 
            // silverToolStripMenuItem1
            // 
            silverToolStripMenuItem1.ForeColor = Color.Silver;
            silverToolStripMenuItem1.Name = "silverToolStripMenuItem1";
            silverToolStripMenuItem1.Size = new Size(148, 26);
            silverToolStripMenuItem1.Text = "Silver";
            silverToolStripMenuItem1.Click += silverToolStripMenuItem1_Click;
            // 
            // greenToolStripMenuItem1
            // 
            greenToolStripMenuItem1.ForeColor = Color.PaleGreen;
            greenToolStripMenuItem1.Name = "greenToolStripMenuItem1";
            greenToolStripMenuItem1.Size = new Size(148, 26);
            greenToolStripMenuItem1.Text = "Green";
            greenToolStripMenuItem1.Click += greenToolStripMenuItem1_Click;
            // 
            // yellowToolStripMenuItem1
            // 
            yellowToolStripMenuItem1.ForeColor = Color.Yellow;
            yellowToolStripMenuItem1.Name = "yellowToolStripMenuItem1";
            yellowToolStripMenuItem1.Size = new Size(148, 26);
            yellowToolStripMenuItem1.Text = "Yellow";
            yellowToolStripMenuItem1.Click += yellowToolStripMenuItem1_Click;
            // 
            // aIModeToolStripMenuItem
            // 
            aIModeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enableToolStripMenuItem, disableToolStripMenuItem });
            aIModeToolStripMenuItem.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            aIModeToolStripMenuItem.ForeColor = Color.RoyalBlue;
            aIModeToolStripMenuItem.Name = "aIModeToolStripMenuItem";
            aIModeToolStripMenuItem.Size = new Size(198, 26);
            aIModeToolStripMenuItem.Text = "AI Mode ";
            // 
            // enableToolStripMenuItem
            // 
            enableToolStripMenuItem.ForeColor = Color.LawnGreen;
            enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            enableToolStripMenuItem.Size = new Size(145, 26);
            enableToolStripMenuItem.Text = "Enable";
            enableToolStripMenuItem.Click += enableToolStripMenuItem_Click;
            // 
            // disableToolStripMenuItem
            // 
            disableToolStripMenuItem.ForeColor = Color.Red;
            disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            disableToolStripMenuItem.Size = new Size(145, 26);
            disableToolStripMenuItem.Text = "Disable";
            disableToolStripMenuItem.Click += disableToolStripMenuItem_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.DarkSlateBlue;
            comboBox1.Cursor = Cursors.PanNE;
            comboBox1.DropDownHeight = 100;
            comboBox1.DropDownWidth = 100;
            comboBox1.FlatStyle = FlatStyle.Popup;
            comboBox1.Font = new Font("Viner Hand ITC", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.ForeColor = SystemColors.Info;
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.Items.AddRange(new object[] { "Easy", "Normal", "Hard" });
            comboBox1.Location = new Point(915, 62);
            comboBox1.MaxDropDownItems = 3;
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(144, 32);
            comboBox1.TabIndex = 6;
            comboBox1.Text = "Difficulty";
            comboBox1.Visible = false;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Stencil", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(793, 70);
            label3.Name = "label3";
            label3.Size = new Size(116, 22);
            label3.TabIndex = 7;
            label3.Text = "Difficulty";
            label3.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 500);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(quitBtn);
            Controls.Add(restartBtn);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.Control;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(550, 100);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button restartBtn;
        private Button quitBtn;
        private Label label1;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem player1ToolStripMenuItem;
        private ToolStripMenuItem coinsColorToolStripMenuItem;
        private ToolStripMenuItem goldToolStripMenuItem;
        private ToolStripMenuItem silverToolStripMenuItem;
        private ToolStripMenuItem greenToolStripMenuItem;
        private ToolStripMenuItem yellowToolStripMenuItem;
        private ToolStripMenuItem player2ToolStripMenuItem;
        private ToolStripMenuItem coinsColorToolStripMenuItem1;
        private ToolStripMenuItem goldToolStripMenuItem1;
        private ToolStripMenuItem silverToolStripMenuItem1;
        private ToolStripMenuItem greenToolStripMenuItem1;
        private ToolStripMenuItem yellowToolStripMenuItem1;
        private ToolStripMenuItem aIModeToolStripMenuItem;
        private ToolStripMenuItem enableToolStripMenuItem;
        private ToolStripMenuItem disableToolStripMenuItem;
        private ComboBox comboBox1;
        private Label label3;
    }
}
