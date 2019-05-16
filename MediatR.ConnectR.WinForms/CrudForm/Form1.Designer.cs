namespace CrudForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpHumanResources = new System.Windows.Forms.TabPage();
            this.tpFacilities = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpHumanResources);
            this.tabControl1.Controls.Add(this.tpFacilities);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tpHumanResources
            // 
            this.tpHumanResources.Location = new System.Drawing.Point(4, 22);
            this.tpHumanResources.Name = "tpHumanResources";
            this.tpHumanResources.Padding = new System.Windows.Forms.Padding(3);
            this.tpHumanResources.Size = new System.Drawing.Size(792, 424);
            this.tpHumanResources.TabIndex = 0;
            this.tpHumanResources.Text = "Human Resources";
            this.tpHumanResources.UseVisualStyleBackColor = true;
            // 
            // tpFacilities
            // 
            this.tpFacilities.Location = new System.Drawing.Point(4, 22);
            this.tpFacilities.Name = "tpFacilities";
            this.tpFacilities.Padding = new System.Windows.Forms.Padding(3);
            this.tpFacilities.Size = new System.Drawing.Size(792, 424);
            this.tpFacilities.TabIndex = 1;
            this.tpFacilities.Text = "Facilities";
            this.tpFacilities.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpHumanResources;
        private System.Windows.Forms.TabPage tpFacilities;
    }
}

