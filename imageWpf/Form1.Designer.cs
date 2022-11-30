
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
            this.transformedPictureBox = new System.Windows.Forms.PictureBox();
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.bottomRightButton = new System.Windows.Forms.Button();
            this.bottomLeftButton = new System.Windows.Forms.Button();
            this.topRightButton = new System.Windows.Forms.Button();
            this.topLeftButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transformedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // transformedPictureBox
            // 
            this.transformedPictureBox.Location = new System.Drawing.Point(545, 44);
            this.transformedPictureBox.Name = "transformedPictureBox";
            this.transformedPictureBox.Size = new System.Drawing.Size(80, 143);
            this.transformedPictureBox.TabIndex = 16;
            this.transformedPictureBox.TabStop = false;
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(545, 245);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(80, 143);
            this.sourcePictureBox.TabIndex = 17;
            this.sourcePictureBox.TabStop = false;
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(12, 15);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(64, 20);
            this.openFileButton.TabIndex = 14;
            this.openFileButton.Text = "Open";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFile_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(12, 41);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(64, 20);
            this.saveFileButton.TabIndex = 15;
            this.saveFileButton.Text = "Save";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.save_button_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 67);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(64, 23);
            this.closeButton.TabIndex = 18;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.closeButton_MouseClick);
            // 
            // bottomRightButton
            // 
            this.bottomRightButton.BackColor = System.Drawing.Color.Black;
            this.bottomRightButton.Location = new System.Drawing.Point(500, 500);
            this.bottomRightButton.Name = "bottomRightButton";
            this.bottomRightButton.Size = new System.Drawing.Size(15, 15);
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
            this.bottomLeftButton.Size = new System.Drawing.Size(15, 15);
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
            this.topRightButton.Size = new System.Drawing.Size(15, 15);
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
            this.topLeftButton.Size = new System.Drawing.Size(15, 15);
            this.topLeftButton.TabIndex = 10;
            this.topLeftButton.UseVisualStyleBackColor = false;
            this.topLeftButton.Visible = false;
            this.topLeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.corner_MouseDown);
            this.topLeftButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.corner_MouseMove);
            this.topLeftButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.corner_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 663);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.sourcePictureBox);
            this.Controls.Add(this.transformedPictureBox);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.bottomRightButton);
            this.Controls.Add(this.bottomLeftButton);
            this.Controls.Add(this.topRightButton);
            this.Controls.Add(this.topLeftButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transformedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox transformedPictureBox;
        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button bottomRightButton;
        private System.Windows.Forms.Button bottomLeftButton;
        private System.Windows.Forms.Button topRightButton;
        private System.Windows.Forms.Button topLeftButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button closeButton;
    }
}

