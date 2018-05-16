namespace WindowsFormsApplication1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lAddress = new System.Windows.Forms.Label();
            this.lPort = new System.Windows.Forms.Label();
            this.lbSerwer = new System.Windows.Forms.ListBox();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.wB1 = new System.Windows.Forms.WebBrowser();
            this.cMSWeb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tB1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tBNick = new System.Windows.Forms.TextBox();
            this.Nick = new System.Windows.Forms.Label();
            this.btBold = new System.Windows.Forms.Button();
            this.btItalic = new System.Windows.Forms.Button();
            this.cBAddress = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lAddress
            // 
            this.lAddress.AutoSize = true;
            this.lAddress.Location = new System.Drawing.Point(9, 69);
            this.lAddress.Name = "lAddress";
            this.lAddress.Size = new System.Drawing.Size(45, 13);
            this.lAddress.TabIndex = 0;
            this.lAddress.Text = "Address";
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Location = new System.Drawing.Point(204, 69);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(26, 13);
            this.lPort.TabIndex = 1;
            this.lPort.Text = "Port";
            // 
            // lbSerwer
            // 
            this.lbSerwer.FormattingEnabled = true;
            this.lbSerwer.Location = new System.Drawing.Point(12, 12);
            this.lbSerwer.Name = "lbSerwer";
            this.lbSerwer.Size = new System.Drawing.Size(510, 43);
            this.lbSerwer.TabIndex = 2;
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(382, 64);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(140, 22);
            this.bStart.TabIndex = 3;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Enabled = false;
            this.bStop.Location = new System.Drawing.Point(383, 498);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(140, 23);
            this.bStop.TabIndex = 4;
            this.bStop.Text = "Wyślij";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(237, 67);
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(140, 20);
            this.numPort.TabIndex = 5;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // wB1
            // 
            this.wB1.ContextMenuStrip = this.cMSWeb;
            this.wB1.Location = new System.Drawing.Point(11, 124);
            this.wB1.MinimumSize = new System.Drawing.Size(20, 20);
            this.wB1.Name = "wB1";
            this.wB1.Size = new System.Drawing.Size(511, 335);
            this.wB1.TabIndex = 7;
            // 
            // cMSWeb
            // 
            this.cMSWeb.Name = "cMSWeb";
            this.cMSWeb.Size = new System.Drawing.Size(61, 4);
            // 
            // tB1
            // 
            this.tB1.Location = new System.Drawing.Point(12, 500);
            this.tB1.Name = "tB1";
            this.tB1.Size = new System.Drawing.Size(365, 20);
            this.tB1.TabIndex = 8;
            this.tB1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB1_KeyDown);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // tBNick
            // 
            this.tBNick.Location = new System.Drawing.Point(60, 98);
            this.tBNick.Name = "tBNick";
            this.tBNick.Size = new System.Drawing.Size(317, 20);
            this.tBNick.TabIndex = 9;
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.Location = new System.Drawing.Point(25, 101);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(29, 13);
            this.Nick.TabIndex = 10;
            this.Nick.Text = "Nick";
            // 
            // btBold
            // 
            this.btBold.Location = new System.Drawing.Point(11, 465);
            this.btBold.Name = "btBold";
            this.btBold.Size = new System.Drawing.Size(26, 23);
            this.btBold.TabIndex = 11;
            this.btBold.Text = "B";
            this.btBold.UseVisualStyleBackColor = true;
            this.btBold.Click += new System.EventHandler(this.btBold_Click);
            // 
            // btItalic
            // 
            this.btItalic.Location = new System.Drawing.Point(43, 465);
            this.btItalic.Name = "btItalic";
            this.btItalic.Size = new System.Drawing.Size(26, 23);
            this.btItalic.TabIndex = 12;
            this.btItalic.Text = "/";
            this.btItalic.UseVisualStyleBackColor = true;
            this.btItalic.Click += new System.EventHandler(this.btItalic_Click);
            // 
            // cBAddress
            // 
            this.cBAddress.FormattingEnabled = true;
            this.cBAddress.Location = new System.Drawing.Point(60, 66);
            this.cBAddress.Name = "cBAddress";
            this.cBAddress.Size = new System.Drawing.Size(140, 21);
            this.cBAddress.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 562);
            this.Controls.Add(this.cBAddress);
            this.Controls.Add(this.btItalic);
            this.Controls.Add(this.btBold);
            this.Controls.Add(this.Nick);
            this.Controls.Add(this.tBNick);
            this.Controls.Add(this.tB1);
            this.Controls.Add(this.wB1);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.lbSerwer);
            this.Controls.Add(this.lPort);
            this.Controls.Add(this.lAddress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lAddress;
        private System.Windows.Forms.Label lPort;
        private System.Windows.Forms.ListBox lbSerwer;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.WebBrowser wB1;
        private System.Windows.Forms.TextBox tB1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox tBNick;
        private System.Windows.Forms.Label Nick;
        private System.Windows.Forms.Button btBold;
        private System.Windows.Forms.Button btItalic;
        private System.Windows.Forms.ComboBox cBAddress;
        private System.Windows.Forms.ContextMenuStrip cMSWeb;
    }
}

