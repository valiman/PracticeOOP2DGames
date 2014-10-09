namespace ProgrammingPractice
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFps = new System.Windows.Forms.Label();
            this.lblBulletCount = new System.Windows.Forms.Label();
            this.lblMouseX = new System.Windows.Forms.Label();
            this.lblMouseY = new System.Windows.Forms.Label();
            this.lblMouseAngleToObj = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(1, 508);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(35, 13);
            this.lblFps.TabIndex = 1;
            this.lblFps.Text = "label1";
            // 
            // lblBulletCount
            // 
            this.lblBulletCount.AutoSize = true;
            this.lblBulletCount.Location = new System.Drawing.Point(1, 521);
            this.lblBulletCount.Name = "lblBulletCount";
            this.lblBulletCount.Size = new System.Drawing.Size(35, 13);
            this.lblBulletCount.TabIndex = 2;
            this.lblBulletCount.Text = "label1";
            // 
            // lblMouseX
            // 
            this.lblMouseX.AutoSize = true;
            this.lblMouseX.Location = new System.Drawing.Point(157, 508);
            this.lblMouseX.Name = "lblMouseX";
            this.lblMouseX.Size = new System.Drawing.Size(35, 13);
            this.lblMouseX.TabIndex = 5;
            this.lblMouseX.Text = "label1";
            // 
            // lblMouseY
            // 
            this.lblMouseY.AutoSize = true;
            this.lblMouseY.Location = new System.Drawing.Point(157, 521);
            this.lblMouseY.Name = "lblMouseY";
            this.lblMouseY.Size = new System.Drawing.Size(35, 13);
            this.lblMouseY.TabIndex = 6;
            this.lblMouseY.Text = "label2";
            // 
            // lblMouseAngleToObj
            // 
            this.lblMouseAngleToObj.AutoSize = true;
            this.lblMouseAngleToObj.Location = new System.Drawing.Point(157, 538);
            this.lblMouseAngleToObj.Name = "lblMouseAngleToObj";
            this.lblMouseAngleToObj.Size = new System.Drawing.Size(35, 13);
            this.lblMouseAngleToObj.TabIndex = 7;
            this.lblMouseAngleToObj.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 562);
            this.Controls.Add(this.lblMouseAngleToObj);
            this.Controls.Add(this.lblMouseY);
            this.Controls.Add(this.lblMouseX);
            this.Controls.Add(this.lblBulletCount);
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.Label lblBulletCount;
        private System.Windows.Forms.Label lblMouseX;
        private System.Windows.Forms.Label lblMouseY;
        private System.Windows.Forms.Label lblMouseAngleToObj;
    }
}

