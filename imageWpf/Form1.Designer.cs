
namespace imageWpf
{
    partial class Form1
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFile = new System.Windows.Forms.Button();
            this.bottomRightButton = new System.Windows.Forms.Button();
            this.bottomLeftButton = new System.Windows.Forms.Button();
            this.topRightButton = new System.Windows.Forms.Button();
            this.topLeftButton = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(12, 12);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(64, 20);
            this.openFile.TabIndex = 14;
            this.openFile.Text = "Open";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // bottomRightButton
            // 
            this.bottomRightButton.BackColor = System.Drawing.Color.Black;
            this.bottomRightButton.Location = new System.Drawing.Point(500, 500);
            this.bottomRightButton.Name = "bottomRightButton";
            this.bottomRightButton.Size = new System.Drawing.Size(9, 9);
            this.bottomRightButton.TabIndex = 13;
            this.bottomRightButton.UseVisualStyleBackColor = false;
            this.bottomRightButton.Visible = false;
            this.bottomRightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.corner_MouseDown);
            this.bottomRightButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.corner_MouseMove);
            this.bottomRightButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.corner_MouseUp);
            // 
            // bottomLeftButton
            // 
            this.bottomLeftButton.BackColor = System.Drawing.Color.Black;
            this.bottomLeftButton.Location = new System.Drawing.Point(0, 500);
            this.bottomLeftButton.Name = "bottomLeftButton";
            this.bottomLeftButton.Size = new System.Drawing.Size(9, 9);
            this.bottomLeftButton.TabIndex = 12;
            this.bottomLeftButton.UseVisualStyleBackColor = false;
            this.bottomLeftButton.Visible = false;
            this.bottomLeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.corner_MouseDown);
            this.bottomLeftButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.corner_MouseMove);
            this.bottomLeftButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.corner_MouseUp);
            // 
            // topRightButton
            // 
            this.topRightButton.BackColor = System.Drawing.Color.Black;
            this.topRightButton.Location = new System.Drawing.Point(500, 0);
            this.topRightButton.Name = "topRightButton";
            this.topRightButton.Size = new System.Drawing.Size(9, 9);
            this.topRightButton.TabIndex = 11;
            this.topRightButton.UseVisualStyleBackColor = false;
            this.topRightButton.Visible = false;
            this.topRightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.corner_MouseDown);
            this.topRightButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.corner_MouseMove);
            this.topRightButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.corner_MouseUp);
            // 
            // topLeftButton
            // 
            this.topLeftButton.BackColor = System.Drawing.Color.Black;
            this.topLeftButton.Location = new System.Drawing.Point(0, 0);
            this.topLeftButton.Name = "topLeftButton";
            this.topLeftButton.Size = new System.Drawing.Size(9, 9);
            this.topLeftButton.TabIndex = 10;
            this.topLeftButton.UseVisualStyleBackColor = false;
            this.topLeftButton.Visible = false;
            this.topLeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.corner_MouseDown);
            this.topLeftButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.corner_MouseMove);
            this.topLeftButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.corner_MouseUp);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(82, 12);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(64, 20);
            this.save_button.TabIndex = 15;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 663);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.bottomRightButton);
            this.Controls.Add(this.bottomLeftButton);
            this.Controls.Add(this.topRightButton);
            this.Controls.Add(this.topLeftButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button bottomRightButton;
        private System.Windows.Forms.Button bottomLeftButton;
        private System.Windows.Forms.Button topRightButton;
        private System.Windows.Forms.Button topLeftButton;
        private System.Windows.Forms.Button save_button;
    }
}

