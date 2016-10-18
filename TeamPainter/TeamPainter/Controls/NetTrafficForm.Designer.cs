namespace TeamPainter
{
    partial class NetTrafficForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOutBytes = new System.Windows.Forms.Label();
            this.lblOutPacket = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblInBytes = new System.Windows.Forms.Label();
            this.lblInPacket = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.graphIN = new GraphCounter.GraphPlotter();
            this.label2 = new System.Windows.Forms.Label();
            this.graphOut = new GraphCounter.GraphPlotter();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 23);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblOutBytes);
            this.panel2.Controls.Add(this.lblOutPacket);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblInBytes);
            this.panel2.Controls.Add(this.lblInPacket);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 42);
            this.panel2.TabIndex = 1;
            // 
            // lblOutBytes
            // 
            this.lblOutBytes.AutoSize = true;
            this.lblOutBytes.Location = new System.Drawing.Point(96, 22);
            this.lblOutBytes.Name = "lblOutBytes";
            this.lblOutBytes.Size = new System.Drawing.Size(13, 13);
            this.lblOutBytes.TabIndex = 7;
            this.lblOutBytes.Text = "0";
            // 
            // lblOutPacket
            // 
            this.lblOutPacket.AutoSize = true;
            this.lblOutPacket.Location = new System.Drawing.Point(252, 22);
            this.lblOutPacket.Name = "lblOutPacket";
            this.lblOutPacket.Size = new System.Drawing.Size(13, 13);
            this.lblOutPacket.TabIndex = 6;
            this.lblOutPacket.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Send bytes:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(192, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = ", packets:";
            // 
            // lblInBytes
            // 
            this.lblInBytes.AutoSize = true;
            this.lblInBytes.Location = new System.Drawing.Point(96, 9);
            this.lblInBytes.Name = "lblInBytes";
            this.lblInBytes.Size = new System.Drawing.Size(13, 13);
            this.lblInBytes.TabIndex = 3;
            this.lblInBytes.Text = "0";
            // 
            // lblInPacket
            // 
            this.lblInPacket.AutoSize = true;
            this.lblInPacket.Location = new System.Drawing.Point(252, 9);
            this.lblInPacket.Name = "lblInPacket";
            this.lblInPacket.Size = new System.Drawing.Size(13, 13);
            this.lblInPacket.TabIndex = 2;
            this.lblInPacket.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Receive bytes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(192, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = ", packets:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(409, 147);
            this.panel3.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.graphIN);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.graphOut);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Size = new System.Drawing.Size(409, 147);
            this.splitContainer1.SplitterDistance = 73;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(334, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Receive data";
            // 
            // graphIN
            // 
            this.graphIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphIN.Location = new System.Drawing.Point(0, 0);
            this.graphIN.Name = "graphIN";
            this.graphIN.Size = new System.Drawing.Size(405, 69);
            this.graphIN.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(349, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Send data";
            // 
            // graphOut
            // 
            this.graphOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphOut.Location = new System.Drawing.Point(0, 0);
            this.graphOut.Name = "graphOut";
            this.graphOut.Size = new System.Drawing.Size(405, 66);
            this.graphOut.TabIndex = 0;
            // 
            // NetTrafficForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(409, 212);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(420, 250);
            this.Name = "NetTrafficForm";
            this.Text = "NetTrafficForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetTrafficForm_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GraphCounter.GraphPlotter graphIN;
        private GraphCounter.GraphPlotter graphOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOutBytes;
        private System.Windows.Forms.Label lblOutPacket;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblInBytes;
        private System.Windows.Forms.Label lblInPacket;
    }
}