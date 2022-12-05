
namespace ImagePerspective
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
            this.transformButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transformedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // transformedPictureBox
            // 
            this.transformedPictureBox.Location = new System.Drawing.Point(545, 67);
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
            // transformButton
            // 
            this.transformButton.Location = new System.Drawing.Point(12, 96);
            this.transformButton.Name = "transformButton";
            this.transformButton.Size = new System.Drawing.Size(64, 23);
            this.transformButton.TabIndex = 19;
            this.transformButton.Text = "Transform";
            this.transformButton.UseVisualStyleBackColor = true;
            this.transformButton.Click += new System.EventHandler(this.transformButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(12, 125);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(64, 23);
            this.resetButton.TabIndex = 20;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 663);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.transformButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.sourcePictureBox);
            this.Controls.Add(this.transformedPictureBox);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.openFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.transformedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox transformedPictureBox;
        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button transformButton;
        private System.Windows.Forms.Button resetButton;
    }
}

