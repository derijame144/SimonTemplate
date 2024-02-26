namespace SimonSays
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.yellowButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.redButton = new System.Windows.Forms.Button();
            this.greenButton = new System.Windows.Forms.Button();
            this.Game_Tick = new System.Windows.Forms.Timer(this.components);
            this.timerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yellowButton
            // 
            this.yellowButton.BackColor = System.Drawing.Color.Goldenrod;
            this.yellowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.yellowButton.Location = new System.Drawing.Point(80, 287);
            this.yellowButton.Margin = new System.Windows.Forms.Padding(6);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(220, 212);
            this.yellowButton.TabIndex = 3;
            this.yellowButton.UseVisualStyleBackColor = false;
            this.yellowButton.Click += new System.EventHandler(this.yellowButton_Click);
            // 
            // blueButton
            // 
            this.blueButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.blueButton.AutoEllipsis = true;
            this.blueButton.BackColor = System.Drawing.Color.DarkBlue;
            this.blueButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.blueButton.FlatAppearance.BorderSize = 0;
            this.blueButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.blueButton.ForeColor = System.Drawing.Color.Black;
            this.blueButton.Location = new System.Drawing.Point(304, 287);
            this.blueButton.Margin = new System.Windows.Forms.Padding(6);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(220, 212);
            this.blueButton.TabIndex = 2;
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // redButton
            // 
            this.redButton.BackColor = System.Drawing.Color.DarkRed;
            this.redButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.redButton.Location = new System.Drawing.Point(304, 71);
            this.redButton.Margin = new System.Windows.Forms.Padding(6);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(220, 212);
            this.redButton.TabIndex = 1;
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // greenButton
            // 
            this.greenButton.BackColor = System.Drawing.Color.ForestGreen;
            this.greenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LimeGreen;
            this.greenButton.Location = new System.Drawing.Point(80, 71);
            this.greenButton.Margin = new System.Windows.Forms.Padding(6);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(220, 212);
            this.greenButton.TabIndex = 0;
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
            // 
            // Game_Tick
            // 
            this.Game_Tick.Interval = 1000;
            this.Game_Tick.Tick += new System.EventHandler(this.Game_Tick_Tick);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.timerLabel.Location = new System.Drawing.Point(299, 21);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(24, 25);
            this.timerLabel.TabIndex = 4;
            this.timerLabel.Text = "5";
            this.timerLabel.Visible = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.yellowButton);
            this.Controls.Add(this.blueButton);
            this.Controls.Add(this.redButton);
            this.Controls.Add(this.greenButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(602, 577);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yellowButton;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Timer Game_Tick;
        private System.Windows.Forms.Label timerLabel;
    }
}
