namespace Publisher
{
    partial class FrmCompare
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSource = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTarget = new System.Windows.Forms.Button();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSource);
            this.groupBox1.Controls.Add(this.txtSource);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorce";
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(316, 16);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(75, 23);
            this.btnSource.TabIndex = 1;
            this.btnSource.Text = "Select";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(6, 17);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(303, 20);
            this.txtSource.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTarget);
            this.groupBox2.Controls.Add(this.txtTarget);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 52);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target";
            // 
            // btnTarget
            // 
            this.btnTarget.Location = new System.Drawing.Point(316, 16);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(75, 23);
            this.btnTarget.TabIndex = 1;
            this.btnTarget.Text = "Select";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(6, 17);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(303, 20);
            this.txtTarget.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFind.Location = new System.Drawing.Point(298, 129);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(111, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find Changes";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // FrmCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 163);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCompare";
            this.Text = "Compare";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Button btnFind;
        public System.Windows.Forms.TextBox txtSource;
        public System.Windows.Forms.TextBox txtTarget;
    }
}