namespace Space_Invaders
{
    partial class Background
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
            this.components = new System.ComponentModel.Container();
            this.Player = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.Counter = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.White;
            this.Player.Location = new System.Drawing.Point(400, 615);
            this.Player.Margin = new System.Windows.Forms.Padding(0);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(67, 62);
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            this.Player.LocationChanged += new System.EventHandler(this.Player_LocationChanged);
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 33;
            this.GameTimer.Tick += new System.EventHandler(this.TimerEvent);
            // 
            // Counter
            // 
            this.Counter.AutoSize = true;
            this.Counter.BackColor = System.Drawing.Color.Transparent;
            this.Counter.Location = new System.Drawing.Point(667, 31);
            this.Counter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Counter.Name = "Counter";
            this.Counter.Size = new System.Drawing.Size(63, 17);
            this.Counter.TabIndex = 1;
            this.Counter.Text = "Points: 0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 30;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(779, 690);
            this.Controls.Add(this.Counter);
            this.Controls.Add(this.Player);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Background";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Space Invaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Background_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label Counter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

