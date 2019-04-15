namespace GoUR_FP
{
    partial class frmSurface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSurface));
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pnlDice = new System.Windows.Forms.Panel();
            this.pbCup = new System.Windows.Forms.PictureBox();
            this.pnlHud = new System.Windows.Forms.Panel();
            this.pbHudPlayer = new System.Windows.Forms.PictureBox();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblWhiteScore = new System.Windows.Forms.Label();
            this.pbWhiteScore = new System.Windows.Forms.PictureBox();
            this.pbBlackScore = new System.Windows.Forms.PictureBox();
            this.lblBlackScore = new System.Windows.Forms.Label();
            this.pnlStartUp = new System.Windows.Forms.Panel();
            this.pbStartDice1 = new System.Windows.Forms.PictureBox();
            this.pbStartDice2 = new System.Windows.Forms.PictureBox();
            this.pbStartDice3 = new System.Windows.Forms.PictureBox();
            this.pbStartDice4 = new System.Windows.Forms.PictureBox();
            this.pbStartupRoll = new System.Windows.Forms.PictureBox();
            this.lblBlink = new System.Windows.Forms.Label();
            this.pbPortrait = new System.Windows.Forms.PictureBox();
            this.pbBorder2 = new System.Windows.Forms.PictureBox();
            this.pbBorder1 = new System.Windows.Forms.PictureBox();
            this.pnlVictory = new System.Windows.Forms.Panel();
            this.pbVictoryFaction = new System.Windows.Forms.PictureBox();
            this.lblCredits = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCup)).BeginInit();
            this.pnlHud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHudPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWhiteScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlackScore)).BeginInit();
            this.pnlStartUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartDice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartDice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartDice3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartDice4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartupRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder1)).BeginInit();
            this.pnlVictory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVictoryFaction)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlBoard.Enabled = false;
            this.pnlBoard.Location = new System.Drawing.Point(48, 77);
            this.pnlBoard.MaximumSize = new System.Drawing.Size(592, 592);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(592, 592);
            this.pnlBoard.TabIndex = 0;
            // 
            // pnlDice
            // 
            this.pnlDice.BackColor = System.Drawing.Color.Transparent;
            this.pnlDice.Location = new System.Drawing.Point(691, 373);
            this.pnlDice.Name = "pnlDice";
            this.pnlDice.Size = new System.Drawing.Size(296, 74);
            this.pnlDice.TabIndex = 2;
            // 
            // pbCup
            // 
            this.pbCup.BackColor = System.Drawing.Color.Transparent;
            this.pbCup.BackgroundImage = global::GoUR_FP.Properties.Resources.Rolling_cup;
            this.pbCup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCup.Location = new System.Drawing.Point(691, 77);
            this.pbCup.Name = "pbCup";
            this.pbCup.Size = new System.Drawing.Size(296, 296);
            this.pbCup.TabIndex = 1;
            this.pbCup.TabStop = false;
            // 
            // pnlHud
            // 
            this.pnlHud.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHud.Controls.Add(this.pbHudPlayer);
            this.pnlHud.Controls.Add(this.lblPlayers);
            this.pnlHud.Controls.Add(this.pbPlayer);
            this.pnlHud.Controls.Add(this.lblTurn);
            this.pnlHud.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHud.Location = new System.Drawing.Point(0, 0);
            this.pnlHud.Name = "pnlHud";
            this.pnlHud.Size = new System.Drawing.Size(1006, 50);
            this.pnlHud.TabIndex = 3;
            this.pnlHud.Visible = false;
            // 
            // pbHudPlayer
            // 
            this.pbHudPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbHudPlayer.Location = new System.Drawing.Point(468, 3);
            this.pbHudPlayer.Name = "pbHudPlayer";
            this.pbHudPlayer.Size = new System.Drawing.Size(46, 44);
            this.pbHudPlayer.TabIndex = 7;
            this.pbHudPlayer.TabStop = false;
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPlayers.Font = new System.Drawing.Font("Orator Std", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayers.ForeColor = System.Drawing.Color.BurlyWood;
            this.lblPlayers.Location = new System.Drawing.Point(508, 4);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(139, 43);
            this.lblPlayers.TabIndex = 6;
            this.lblPlayers.Text = "Player";
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPlayer.Location = new System.Drawing.Point(236, 3);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(46, 44);
            this.pbPlayer.TabIndex = 5;
            this.pbPlayer.TabStop = false;
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.BackColor = System.Drawing.Color.Transparent;
            this.lblTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTurn.Font = new System.Drawing.Font("Orator Std", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTurn.Location = new System.Drawing.Point(275, 3);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(99, 43);
            this.lblTurn.TabIndex = 4;
            this.lblTurn.Text = "Turn";
            // 
            // lblWhiteScore
            // 
            this.lblWhiteScore.AutoSize = true;
            this.lblWhiteScore.BackColor = System.Drawing.Color.Transparent;
            this.lblWhiteScore.Font = new System.Drawing.Font("Orator Std", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteScore.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblWhiteScore.Location = new System.Drawing.Point(916, 476);
            this.lblWhiteScore.Name = "lblWhiteScore";
            this.lblWhiteScore.Size = new System.Drawing.Size(58, 64);
            this.lblWhiteScore.TabIndex = 4;
            this.lblWhiteScore.Text = "0";
            // 
            // pbWhiteScore
            // 
            this.pbWhiteScore.BackColor = System.Drawing.Color.Transparent;
            this.pbWhiteScore.Image = global::GoUR_FP.Properties.Resources.whitepiece;
            this.pbWhiteScore.Location = new System.Drawing.Point(844, 472);
            this.pbWhiteScore.Name = "pbWhiteScore";
            this.pbWhiteScore.Size = new System.Drawing.Size(74, 74);
            this.pbWhiteScore.TabIndex = 5;
            this.pbWhiteScore.TabStop = false;
            // 
            // pbBlackScore
            // 
            this.pbBlackScore.BackColor = System.Drawing.Color.Transparent;
            this.pbBlackScore.Image = global::GoUR_FP.Properties.Resources.blackpiece;
            this.pbBlackScore.Location = new System.Drawing.Point(844, 566);
            this.pbBlackScore.Name = "pbBlackScore";
            this.pbBlackScore.Size = new System.Drawing.Size(74, 74);
            this.pbBlackScore.TabIndex = 7;
            this.pbBlackScore.TabStop = false;
            // 
            // lblBlackScore
            // 
            this.lblBlackScore.AutoSize = true;
            this.lblBlackScore.BackColor = System.Drawing.Color.Transparent;
            this.lblBlackScore.Font = new System.Drawing.Font("Orator Std", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlackScore.ForeColor = System.Drawing.Color.Black;
            this.lblBlackScore.Location = new System.Drawing.Point(916, 570);
            this.lblBlackScore.Name = "lblBlackScore";
            this.lblBlackScore.Size = new System.Drawing.Size(58, 64);
            this.lblBlackScore.TabIndex = 6;
            this.lblBlackScore.Text = "0";
            // 
            // pnlStartUp
            // 
            this.pnlStartUp.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlStartUp.BackgroundImage = global::GoUR_FP.Properties.Resources.startup;
            this.pnlStartUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlStartUp.Controls.Add(this.pbStartDice1);
            this.pnlStartUp.Controls.Add(this.pbStartDice2);
            this.pnlStartUp.Controls.Add(this.pbStartDice3);
            this.pnlStartUp.Controls.Add(this.pbStartDice4);
            this.pnlStartUp.Controls.Add(this.pbStartupRoll);
            this.pnlStartUp.Controls.Add(this.lblBlink);
            this.pnlStartUp.Location = new System.Drawing.Point(0, 50);
            this.pnlStartUp.Name = "pnlStartUp";
            this.pnlStartUp.Size = new System.Drawing.Size(14, 641);
            this.pnlStartUp.TabIndex = 8;
            // 
            // pbStartDice1
            // 
            this.pbStartDice1.BackColor = System.Drawing.Color.Transparent;
            this.pbStartDice1.Image = global::GoUR_FP.Properties.Resources.dice_one;
            this.pbStartDice1.Location = new System.Drawing.Point(98, 428);
            this.pbStartDice1.Name = "pbStartDice1";
            this.pbStartDice1.Size = new System.Drawing.Size(74, 74);
            this.pbStartDice1.TabIndex = 5;
            this.pbStartDice1.TabStop = false;
            this.pbStartDice1.Visible = false;
            // 
            // pbStartDice2
            // 
            this.pbStartDice2.BackColor = System.Drawing.Color.Transparent;
            this.pbStartDice2.Image = global::GoUR_FP.Properties.Resources.dice_zero;
            this.pbStartDice2.Location = new System.Drawing.Point(194, 428);
            this.pbStartDice2.Name = "pbStartDice2";
            this.pbStartDice2.Size = new System.Drawing.Size(74, 74);
            this.pbStartDice2.TabIndex = 4;
            this.pbStartDice2.TabStop = false;
            this.pbStartDice2.Visible = false;
            // 
            // pbStartDice3
            // 
            this.pbStartDice3.BackColor = System.Drawing.Color.Transparent;
            this.pbStartDice3.Image = global::GoUR_FP.Properties.Resources.dice_zero;
            this.pbStartDice3.Location = new System.Drawing.Point(290, 428);
            this.pbStartDice3.Name = "pbStartDice3";
            this.pbStartDice3.Size = new System.Drawing.Size(74, 74);
            this.pbStartDice3.TabIndex = 3;
            this.pbStartDice3.TabStop = false;
            this.pbStartDice3.Visible = false;
            // 
            // pbStartDice4
            // 
            this.pbStartDice4.BackColor = System.Drawing.Color.Transparent;
            this.pbStartDice4.Image = global::GoUR_FP.Properties.Resources.dice_one;
            this.pbStartDice4.Location = new System.Drawing.Point(386, 428);
            this.pbStartDice4.Name = "pbStartDice4";
            this.pbStartDice4.Size = new System.Drawing.Size(74, 74);
            this.pbStartDice4.TabIndex = 2;
            this.pbStartDice4.TabStop = false;
            this.pbStartDice4.Visible = false;
            // 
            // pbStartupRoll
            // 
            this.pbStartupRoll.BackColor = System.Drawing.Color.Transparent;
            this.pbStartupRoll.BackgroundImage = global::GoUR_FP.Properties.Resources.Rolling_cup_start;
            this.pbStartupRoll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbStartupRoll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStartupRoll.Location = new System.Drawing.Point(264, 182);
            this.pbStartupRoll.Name = "pbStartupRoll";
            this.pbStartupRoll.Size = new System.Drawing.Size(223, 257);
            this.pbStartupRoll.TabIndex = 1;
            this.pbStartupRoll.TabStop = false;
            // 
            // lblBlink
            // 
            this.lblBlink.Font = new System.Drawing.Font("Orator Std", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlink.ForeColor = System.Drawing.Color.BurlyWood;
            this.lblBlink.Location = new System.Drawing.Point(0, 521);
            this.lblBlink.Name = "lblBlink";
            this.lblBlink.Size = new System.Drawing.Size(1006, 77);
            this.lblBlink.TabIndex = 0;
            this.lblBlink.Text = "Roll any dice to continue...";
            this.lblBlink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPortrait
            // 
            this.pbPortrait.BackColor = System.Drawing.Color.Transparent;
            this.pbPortrait.BackgroundImage = global::GoUR_FP.Properties.Resources.Prince__Fallen_King_;
            this.pbPortrait.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPortrait.Location = new System.Drawing.Point(691, 453);
            this.pbPortrait.Name = "pbPortrait";
            this.pbPortrait.Size = new System.Drawing.Size(135, 216);
            this.pbPortrait.TabIndex = 9;
            this.pbPortrait.TabStop = false;
            // 
            // pbBorder2
            // 
            this.pbBorder2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbBorder2.BackgroundImage")));
            this.pbBorder2.Location = new System.Drawing.Point(639, 227);
            this.pbBorder2.Name = "pbBorder2";
            this.pbBorder2.Size = new System.Drawing.Size(12, 221);
            this.pbBorder2.TabIndex = 10;
            this.pbBorder2.TabStop = false;
            // 
            // pbBorder1
            // 
            this.pbBorder1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbBorder1.BackgroundImage")));
            this.pbBorder1.Location = new System.Drawing.Point(38, 227);
            this.pbBorder1.Name = "pbBorder1";
            this.pbBorder1.Size = new System.Drawing.Size(12, 221);
            this.pbBorder1.TabIndex = 11;
            this.pbBorder1.TabStop = false;
            // 
            // pnlVictory
            // 
            this.pnlVictory.BackgroundImage = global::GoUR_FP.Properties.Resources.victory;
            this.pnlVictory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlVictory.Controls.Add(this.pbVictoryFaction);
            this.pnlVictory.Controls.Add(this.lblCredits);
            this.pnlVictory.Controls.Add(this.btnQuit);
            this.pnlVictory.Controls.Add(this.btnRetry);
            this.pnlVictory.Location = new System.Drawing.Point(691, 50);
            this.pnlVictory.Name = "pnlVictory";
            this.pnlVictory.Size = new System.Drawing.Size(32, 641);
            this.pnlVictory.TabIndex = 12;
            this.pnlVictory.Visible = false;
            // 
            // pbVictoryFaction
            // 
            this.pbVictoryFaction.BackColor = System.Drawing.Color.Transparent;
            this.pbVictoryFaction.BackgroundImage = global::GoUR_FP.Properties.Resources.whitepiece;
            this.pbVictoryFaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbVictoryFaction.Location = new System.Drawing.Point(371, 275);
            this.pbVictoryFaction.Name = "pbVictoryFaction";
            this.pbVictoryFaction.Size = new System.Drawing.Size(74, 74);
            this.pbVictoryFaction.TabIndex = 3;
            this.pbVictoryFaction.TabStop = false;
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.BackColor = System.Drawing.Color.Transparent;
            this.lblCredits.Font = new System.Drawing.Font("Orator Std", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredits.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.lblCredits.Location = new System.Drawing.Point(451, 275);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(467, 252);
            this.lblCredits.TabIndex = 2;
            this.lblCredits.Text = "Character art from the game:\r\nPrince of persia: The fallen king\r\n\r\nSoundtrack:\r\nP" +
    "rince of persia: The sands of time\r\n(2010)\r\nComposed by:\r\nHarry Gregson-Williams" +
    "\r\nWalt Disney Records";
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnQuit.FlatAppearance.BorderColor = System.Drawing.Color.BurlyWood;
            this.btnQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.btnQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Font = new System.Drawing.Font("Orator Std", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnQuit.Location = new System.Drawing.Point(733, 580);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(185, 46);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Exit game";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRetry.FlatAppearance.BorderColor = System.Drawing.Color.BurlyWood;
            this.btnRetry.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.btnRetry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.Font = new System.Drawing.Font("Orator Std", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetry.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.btnRetry.Location = new System.Drawing.Point(516, 580);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(185, 46);
            this.btnRetry.TabIndex = 0;
            this.btnRetry.Text = "Play again!";
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // frmSurface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.BackgroundImage = global::GoUR_FP.Properties.Resources.woodtile1;
            this.ClientSize = new System.Drawing.Size(1006, 691);
            this.Controls.Add(this.pnlVictory);
            this.Controls.Add(this.pnlStartUp);
            this.Controls.Add(this.pbBlackScore);
            this.Controls.Add(this.lblBlackScore);
            this.Controls.Add(this.pbWhiteScore);
            this.Controls.Add(this.lblWhiteScore);
            this.Controls.Add(this.pnlHud);
            this.Controls.Add(this.pnlDice);
            this.Controls.Add(this.pbCup);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.pbPortrait);
            this.Controls.Add(this.pbBorder2);
            this.Controls.Add(this.pbBorder1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Orator Std", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSurface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoUR-FP-Gameplay demo";
            ((System.ComponentModel.ISupportInitialize)(this.pbCup)).EndInit();
            this.pnlHud.ResumeLayout(false);
            this.pnlHud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHudPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWhiteScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlackScore)).EndInit();
            this.pnlStartUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStartDice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartDice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartDice3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartDice4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartupRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder1)).EndInit();
            this.pnlVictory.ResumeLayout(false);
            this.pnlVictory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVictoryFaction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.PictureBox pbCup;
        private System.Windows.Forms.Panel pnlDice;
        private System.Windows.Forms.Panel pnlHud;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.Label lblWhiteScore;
        private System.Windows.Forms.PictureBox pbWhiteScore;
        private System.Windows.Forms.PictureBox pbBlackScore;
        private System.Windows.Forms.Label lblBlackScore;
        private System.Windows.Forms.Panel pnlStartUp;
        private System.Windows.Forms.Label lblBlink;
        private System.Windows.Forms.PictureBox pbStartupRoll;
        private System.Windows.Forms.PictureBox pbStartDice4;
        private System.Windows.Forms.PictureBox pbStartDice1;
        private System.Windows.Forms.PictureBox pbStartDice2;
        private System.Windows.Forms.PictureBox pbStartDice3;
        private System.Windows.Forms.PictureBox pbPortrait;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.PictureBox pbHudPlayer;
        private System.Windows.Forms.PictureBox pbBorder2;
        private System.Windows.Forms.PictureBox pbBorder1;
        private System.Windows.Forms.Panel pnlVictory;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.PictureBox pbVictoryFaction;
    }
}

