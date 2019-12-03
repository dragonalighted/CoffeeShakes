using CoffeeShakes.Properties;

namespace CoffeeShakes
{
    partial class MainForm
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

            DisposeMore();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbEnable = new System.Windows.Forms.CheckBox();
            this.lblDeltaX = new System.Windows.Forms.Label();
            this.lblLastJittered = new System.Windows.Forms.Label();
            this.lblJitterPause = new System.Windows.Forms.Label();
            this.lblZen = new System.Windows.Forms.Label();
            this.btnJitter = new System.Windows.Forms.Button();
            this.lblNextJitter = new System.Windows.Forms.Label();
            // 
            // cbEnable
            // 
            this.cbEnable.AutoSize = true;
            this.cbEnable.Location = new System.Drawing.Point(220, 23);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(102, 19);
            this.cbEnable.TabIndex = 0;
            this.cbEnable.Text = "Get the Jitters?";
            this.cbEnable.UseVisualStyleBackColor = true;
            this.cbEnable.Visible = false;
            this.cbEnable.CheckedChanged += new System.EventHandler(this.cbEnableChanged);
            // 
            // lblDeltaX
            // 
            this.lblDeltaX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeltaX.AutoSize = true;
            this.lblDeltaX.Location = new System.Drawing.Point(220, 45);
            this.lblDeltaX.Name = "lblDeltaX";
            this.lblDeltaX.Size = new System.Drawing.Size(85, 15);
            this.lblDeltaX.TabIndex = 1;
            this.lblDeltaX.Tag = "Jitter Amount: ";
            this.lblDeltaX.Text = "Jitter Amount: ";
            // 
            // lblLastJittered
            // 
            this.lblLastJittered.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastJittered.Location = new System.Drawing.Point(21, 151);
            this.lblLastJittered.Name = "lblLastJittered";
            this.lblLastJittered.Size = new System.Drawing.Size(328, 15);
            this.lblLastJittered.TabIndex = 1;
            this.lblLastJittered.Tag = "Last Jittered: ";
            this.lblLastJittered.Text = "Last Jittered: ";
            // 
            // lblJitterPause
            // 
            this.lblJitterPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJitterPause.AutoSize = true;
            this.lblJitterPause.Location = new System.Drawing.Point(220, 69);
            this.lblJitterPause.Name = "lblJitterPause";
            this.lblJitterPause.Size = new System.Drawing.Size(72, 15);
            this.lblJitterPause.TabIndex = 1;
            this.lblJitterPause.Tag = "Jitter Pause: ";
            this.lblJitterPause.Text = "Jitter Pause: ";
            this.lblJitterPause.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblZen
            // 
            this.lblZen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZen.AutoSize = true;
            this.lblZen.Location = new System.Drawing.Point(220, 99);
            this.lblZen.Name = "lblZen";
            this.lblZen.Size = new System.Drawing.Size(37, 15);
            this.lblZen.TabIndex = 2;
            this.lblZen.Text = "lbZen";
            // 
            // btnJitter
            // 
            this.btnJitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJitter.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnJitter.Location = new System.Drawing.Point(9, 7);
            this.btnJitter.Name = "btnJitter";
            this.btnJitter.Size = new System.Drawing.Size(205, 144);
            this.btnJitter.TabIndex = 3;
            this.btnJitter.UseVisualStyleBackColor = false;
            this.btnJitter.Click += new System.EventHandler(this.btnJitter_Click);
            // 
            // lblNextJitter
            // 
            this.lblNextJitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextJitter.Location = new System.Drawing.Point(21, 170);
            this.lblNextJitter.Name = "lblNextJitter";
            this.lblNextJitter.Size = new System.Drawing.Size(328, 15);
            this.lblNextJitter.TabIndex = 1;
            this.lblNextJitter.Tag = "Next Jittered: ";
            this.lblNextJitter.Text = "Next Jittered: ";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(364, 192);
            this.Controls.Add(this.btnJitter);
            this.Controls.Add(this.lblZen);
            this.Controls.Add(this.lblDeltaX);
            this.Controls.Add(this.cbEnable);
            this.Controls.Add(this.lblLastJittered);
            this.Controls.Add(this.lblJitterPause);
            this.Controls.Add(this.lblNextJitter);
            this.MinimumSize = new System.Drawing.Size(380, 192);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coffee Shakes: Lets get the Jitters";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbEnable;
        private System.Windows.Forms.Label lblDeltaX;
        private System.Windows.Forms.Label lblLastJittered;
        private System.Windows.Forms.Label lblJitterPause;
        private System.Windows.Forms.Label lblZen;
        private System.Windows.Forms.Button btnJitter;
        private System.Windows.Forms.Label lblNextJitter;
    }
}

