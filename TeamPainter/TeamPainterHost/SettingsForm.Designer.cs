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
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUpdInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMaxClients = new System.Windows.Forms.TextBox();
            this.tbPing = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveAndClose.Location = new System.Drawing.Point(10, 168);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(109, 23);
            this.btnSaveAndClose.TabIndex = 0;
            this.btnSaveAndClose.Text = "Save and close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(169, 28);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(86, 20);
            this.tbPort.TabIndex = 10;
            this.tbPort.Text = "22000";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(169, 9);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(86, 20);
            this.tbIP.TabIndex = 9;
            this.tbIP.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Default listen TCP port ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Default listen TCP IP";
            // 
            // tbUpdInterval
            // 
            this.tbUpdInterval.Location = new System.Drawing.Point(170, 62);
            this.tbUpdInterval.Name = "tbUpdInterval";
            this.tbUpdInterval.Size = new System.Drawing.Size(86, 20);
            this.tbUpdInterval.TabIndex = 12;
            this.tbUpdInterval.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Update picture interval (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Max clients";
            // 
            // tbMaxClients
            // 
            this.tbMaxClients.Location = new System.Drawing.Point(170, 82);
            this.tbMaxClients.Name = "tbMaxClients";
            this.tbMaxClients.Size = new System.Drawing.Size(86, 20);
            this.tbMaxClients.TabIndex = 14;
            this.tbMaxClients.Text = "10";
            // 
            // tbPing
            // 
            this.tbPing.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbPing.Location = new System.Drawing.Point(170, 102);
            this.tbPing.Name = "tbPing";
            this.tbPing.ReadOnly = true;
            this.tbPing.Size = new System.Drawing.Size(86, 20);
            this.tbPing.TabIndex = 15;
            this.tbPing.Text = "5000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(14, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Clients ping interval (ms)";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(269, 203);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPing);
            this.Controls.Add(this.tbMaxClients);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUpdInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveAndClose);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "HostSettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUpdInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMaxClients;
        private System.Windows.Forms.TextBox tbPing;
        private System.Windows.Forms.Label label5;
    }
}