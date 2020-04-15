namespace CoffeeShakes
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
            this.nudMinimum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMaximum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximum)).BeginInit();
            // 
            // nudMinimum
            // 
            this.nudMinimum.Location = new System.Drawing.Point(111, 42);
            this.nudMinimum.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudMinimum.Name = "nudMinimum";
            this.nudMinimum.Size = new System.Drawing.Size(116, 23);
            this.nudMinimum.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minimum Step";
            // 
            // nudMaximum
            // 
            this.nudMaximum.Location = new System.Drawing.Point(111, 85);
            this.nudMaximum.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudMaximum.Name = "nudMaximum";
            this.nudMaximum.Size = new System.Drawing.Size(116, 23);
            this.nudMaximum.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maximum Step";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 390);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMinimum);
            this.Controls.Add(this.nudMaximum);
            this.Controls.Add(this.label2);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximum)).EndInit();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMinimum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMaximum;
        private System.Windows.Forms.Label label2;
    }
}