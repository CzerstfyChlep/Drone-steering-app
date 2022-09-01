namespace RecieveStream
{
    partial class Form1
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
            this.picture = new System.Windows.Forms.PictureBox();
            this.OldControlsRadio = new System.Windows.Forms.RadioButton();
            this.NewControlsRadio = new System.Windows.Forms.RadioButton();
            this.RestartConnectionButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.OffOnDrone = new System.Windows.Forms.Label();
            this.LatencyDrone = new System.Windows.Forms.Label();
            this.LatencyInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(12, 11);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(753, 433);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 1;
            this.picture.TabStop = false;
            // 
            // OldControlsRadio
            // 
            this.OldControlsRadio.AutoSize = true;
            this.OldControlsRadio.BackColor = System.Drawing.Color.Transparent;
            this.OldControlsRadio.Checked = true;
            this.OldControlsRadio.ForeColor = System.Drawing.Color.Snow;
            this.OldControlsRadio.Location = new System.Drawing.Point(22, 453);
            this.OldControlsRadio.Name = "OldControlsRadio";
            this.OldControlsRadio.Size = new System.Drawing.Size(163, 17);
            this.OldControlsRadio.TabIndex = 2;
            this.OldControlsRadio.TabStop = true;
            this.OldControlsRadio.Text = "Old controls (W/S Up/Down)";
            this.OldControlsRadio.UseVisualStyleBackColor = false;
            this.OldControlsRadio.CheckedChanged += new System.EventHandler(this.ChangeControlScheme);
            // 
            // NewControlsRadio
            // 
            this.NewControlsRadio.AutoSize = true;
            this.NewControlsRadio.BackColor = System.Drawing.Color.Transparent;
            this.NewControlsRadio.ForeColor = System.Drawing.Color.Snow;
            this.NewControlsRadio.Location = new System.Drawing.Point(189, 453);
            this.NewControlsRadio.Name = "NewControlsRadio";
            this.NewControlsRadio.Size = new System.Drawing.Size(128, 17);
            this.NewControlsRadio.TabIndex = 3;
            this.NewControlsRadio.Text = "New controls (Arrows)";
            this.NewControlsRadio.UseVisualStyleBackColor = false;
            this.NewControlsRadio.CheckedChanged += new System.EventHandler(this.ChangeControlScheme);
            // 
            // RestartConnectionButton
            // 
            this.RestartConnectionButton.Location = new System.Drawing.Point(320, 450);
            this.RestartConnectionButton.Name = "RestartConnectionButton";
            this.RestartConnectionButton.Size = new System.Drawing.Size(184, 23);
            this.RestartConnectionButton.TabIndex = 0;
            this.RestartConnectionButton.Text = "Establish connection";
            this.RestartConnectionButton.UseVisualStyleBackColor = true;
            this.RestartConnectionButton.Click += new System.EventHandler(this.RestartConnectionButton_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.ForeColor = System.Drawing.Color.Snow;
            this.InfoLabel.Location = new System.Drawing.Point(518, 455);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(70, 13);
            this.InfoLabel.TabIndex = 5;
            this.InfoLabel.Text = "Drone status:";
            // 
            // OffOnDrone
            // 
            this.OffOnDrone.AutoSize = true;
            this.OffOnDrone.ForeColor = System.Drawing.Color.Lime;
            this.OffOnDrone.Location = new System.Drawing.Point(594, 455);
            this.OffOnDrone.Name = "OffOnDrone";
            this.OffOnDrone.Size = new System.Drawing.Size(37, 13);
            this.OffOnDrone.TabIndex = 6;
            this.OffOnDrone.Text = "Offline";
            // 
            // LatencyDrone
            // 
            this.LatencyDrone.AutoSize = true;
            this.LatencyDrone.ForeColor = System.Drawing.Color.Lime;
            this.LatencyDrone.Location = new System.Drawing.Point(713, 455);
            this.LatencyDrone.Name = "LatencyDrone";
            this.LatencyDrone.Size = new System.Drawing.Size(26, 13);
            this.LatencyDrone.TabIndex = 8;
            this.LatencyDrone.Text = "0ms";
            // 
            // LatencyInfoLabel
            // 
            this.LatencyInfoLabel.AutoSize = true;
            this.LatencyInfoLabel.ForeColor = System.Drawing.Color.Snow;
            this.LatencyInfoLabel.Location = new System.Drawing.Point(637, 455);
            this.LatencyInfoLabel.Name = "LatencyInfoLabel";
            this.LatencyInfoLabel.Size = new System.Drawing.Size(76, 13);
            this.LatencyInfoLabel.TabIndex = 7;
            this.LatencyInfoLabel.Text = "Drone latency:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(777, 492);
            this.Controls.Add(this.RestartConnectionButton);
            this.Controls.Add(this.OldControlsRadio);
            this.Controls.Add(this.LatencyDrone);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.NewControlsRadio);
            this.Controls.Add(this.LatencyInfoLabel);
            this.Controls.Add(this.OffOnDrone);
            this.Controls.Add(this.InfoLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Drone";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.RadioButton OldControlsRadio;
        private System.Windows.Forms.RadioButton NewControlsRadio;
        private System.Windows.Forms.Button RestartConnectionButton;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label OffOnDrone;
        private System.Windows.Forms.Label LatencyDrone;
        private System.Windows.Forms.Label LatencyInfoLabel;
    }
}

