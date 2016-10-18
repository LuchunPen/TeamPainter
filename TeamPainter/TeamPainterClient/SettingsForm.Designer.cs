namespace TeamPainter
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbUpdInterval = new System.Windows.Forms.TextBox();
            this.tbPacketSize = new System.Windows.Forms.TextBox();
            this.tbPacketInterval = new System.Windows.Forms.TextBox();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default IP to connect";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Default port to connect";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Update picture interval (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Min packet size to send (bytes)\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Min interval to send (ms)";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(168, 6);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(86, 20);
            this.tbIP.TabIndex = 5;
            this.tbIP.Text = "127.0.0.1";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(168, 25);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(86, 20);
            this.tbPort.TabIndex = 6;
            this.tbPort.Text = "22000";
            // 
            // tbUpdInterval
            // 
            this.tbUpdInterval.Location = new System.Drawing.Point(168, 44);
            this.tbUpdInterval.Name = "tbUpdInterval";
            this.tbUpdInterval.Size = new System.Drawing.Size(86, 20);
            this.tbUpdInterval.TabIndex = 7;
            this.tbUpdInterval.Text = "50";
            // 
            // tbPacketSize
            // 
            this.tbPacketSize.Location = new System.Drawing.Point(168, 79);
            this.tbPacketSize.Name = "tbPacketSize";
            this.tbPacketSize.Size = new System.Drawing.Size(86, 20);
            this.tbPacketSize.TabIndex = 8;
            this.tbPacketSize.Text = "1024";
            // 
            // tbPacketInterval
            // 
            this.tbPacketInterval.Location = new System.Drawing.Point(168, 98);
            this.tbPacketInterval.Name = "tbPacketInterval";
            this.tbPacketInterval.Size = new System.Drawing.Size(86, 20);
            this.tbPacketInterval.TabIndex = 9;
            this.tbPacketInterval.Text = "100";
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveAndClose.Location = new System.Drawing.Point(15, 133);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(97, 23);
            this.btnSaveAndClose.TabIndex = 10;
            this.btnSaveAndClose.Text = "Save and close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(269, 167);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.tbPacketInterval);
            this.Controls.Add(this.tbPacketSize);
            this.Controls.Add(this.tbUpdInterval);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(285, 205);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(285, 205);
            this.Name = "SettingsForm";
            this.Text = "ClientSettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbUpdInterval;
        private System.Windows.Forms.TextBox tbPacketSize;
        private System.Windows.Forms.TextBox tbPacketInterval;
        private System.Windows.Forms.Button btnSaveAndClose;
    }
}