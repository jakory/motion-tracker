/**
 *   MOTION TRACKER: Video-based software for tracking motion over time.
 *   Copyright (C) 2012. Jacqueline Kory. Sidney D'Mello. Andrew Olney.
 *   Contact: jacqueline.kory@gmail.com
 *   
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>
 * 
 */

namespace MotionTracker
{
    partial class LiveCamSetupForm
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
            this._camlabel = new System.Windows.Forms.Label();
            this._testButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._selectLocButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._camIndexUpDown = new System.Windows.Forms.NumericUpDown();
            this._liveCamGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._camIndexUpDown)).BeginInit();
            this._liveCamGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _camlabel
            // 
            this._camlabel.AutoSize = true;
            this._camlabel.Location = new System.Drawing.Point(12, 15);
            this._camlabel.Name = "_camlabel";
            this._camlabel.Size = new System.Drawing.Size(106, 13);
            this._camlabel.TabIndex = 1;
            this._camlabel.Text = "Select camera index:";
            // 
            // _testButton
            // 
            this._testButton.Location = new System.Drawing.Point(15, 255);
            this._testButton.Name = "_testButton";
            this._testButton.Size = new System.Drawing.Size(118, 23);
            this._testButton.TabIndex = 2;
            this._testButton.Text = "Test c&amera";
            this._testButton.UseVisualStyleBackColor = true;
            this._testButton.Click += new System.EventHandler(this._testButton_Click);
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(220, 255);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 3;
            this._okButton.Text = "&OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(6, 19);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(266, 153);
            this._pictureBox.TabIndex = 4;
            this._pictureBox.TabStop = false;
            // 
            // _selectLocButton
            // 
            this._selectLocButton.Location = new System.Drawing.Point(15, 42);
            this._selectLocButton.Name = "_selectLocButton";
            this._selectLocButton.Size = new System.Drawing.Size(202, 23);
            this._selectLocButton.TabIndex = 5;
            this._selectLocButton.Text = "Select location to save video (optional)";
            this._selectLocButton.UseVisualStyleBackColor = true;
            this._selectLocButton.Click += new System.EventHandler(this._selectLocButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(139, 255);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 6;
            this._cancelButton.Text = "C&ancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _camIndexUpDown
            // 
            this._camIndexUpDown.Location = new System.Drawing.Point(124, 13);
            this._camIndexUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this._camIndexUpDown.Name = "_camIndexUpDown";
            this._camIndexUpDown.Size = new System.Drawing.Size(49, 20);
            this._camIndexUpDown.TabIndex = 7;
            this._camIndexUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this._camIndexUpDown.ValueChanged += new System.EventHandler(this._camIndexUpDown_ValueChanged);
            // 
            // _liveCamGroupBox
            // 
            this._liveCamGroupBox.Controls.Add(this._pictureBox);
            this._liveCamGroupBox.Location = new System.Drawing.Point(15, 71);
            this._liveCamGroupBox.Name = "_liveCamGroupBox";
            this._liveCamGroupBox.Size = new System.Drawing.Size(280, 178);
            this._liveCamGroupBox.TabIndex = 8;
            this._liveCamGroupBox.TabStop = false;
            this._liveCamGroupBox.Text = "Live camera feed";
            // 
            // LiveCamSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 290);
            this.Controls.Add(this._liveCamGroupBox);
            this.Controls.Add(this._camIndexUpDown);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._selectLocButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._testButton);
            this.Controls.Add(this._camlabel);
            this.Name = "LiveCamSetupForm";
            this.Text = "LiveCamSetupForm";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._camIndexUpDown)).EndInit();
            this._liveCamGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _camlabel;
        private System.Windows.Forms.Button _testButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Button _selectLocButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.NumericUpDown _camIndexUpDown;
        private System.Windows.Forms.GroupBox _liveCamGroupBox;
    }
}