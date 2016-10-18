namespace TeamPainter
{
    partial class ConnectionForm
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
            this.tbIP_TCP = new System.Windows.Forms.TextBox();
            this.tbport_TCP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbIP_TCP
            // 
            this.tbIP_TCP.Location = new System.Drawing.Point(91, 14);
            this.tbIP_TCP.Name = "tbIP_TCP";
            this.tbIP_TCP.Size = new System.Drawing.Size(100, 20);
            this.tbIP_TCP.TabIndex = 0;
            this.tbIP_TCP.Text = "127.0.0.1";
            this.tbIP_TCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbport_TCP
            // 
            this.tbport_TCP.Location = new System.Drawing.Point(197, 14);
            this.tbport_TCP.Name = "tbport_TCP";
            this.tbport_TCP.Size = new System.Drawing.Size(44, 20);
            this.tbport_TCP.TabIndex = 1;
            this.tbport_TCP.Text = "22000";
            this.tbport_TCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(251, 46);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbport_TCP);
            this.Controls.Add(this.tbIP_TCP);
            this.Name = "ConnectionForm";
            this.Text = "ConnectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIP_TCP;
        private System.Windows.Forms.TextBox tbport_TCP;
        private System.Windows.Forms.Button btnConnect;
    }
}