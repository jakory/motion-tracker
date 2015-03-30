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
    partial class InternalParametersForm
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
           this._cancelButton = new System.Windows.Forms.Button();
           this._okButton = new System.Windows.Forms.Button();
           this._mhiDurationLabel = new System.Windows.Forms.Label();
           this._binaryThresholdLabel = new System.Windows.Forms.Label();
           this._mhiDurationUpDown = new System.Windows.Forms.NumericUpDown();
           this._binaryThreshUpDown = new System.Windows.Forms.NumericUpDown();
           this._haarScaleUpDown = new System.Windows.Forms.NumericUpDown();
           this._haarMinNeighborsUpDown = new System.Windows.Forms.NumericUpDown();
           this._haarMinHeightUpDown = new System.Windows.Forms.NumericUpDown();
           this._haarMinWidthUpDown = new System.Windows.Forms.NumericUpDown();
           this._haarScaleLabel = new System.Windows.Forms.Label();
           this._haarMinNeighborLabel = new System.Windows.Forms.Label();
           this._haarMinWidthLabel = new System.Windows.Forms.Label();
           this._haarMinHeightLabel = new System.Windows.Forms.Label();
           this._motionTrackingSettingsGroupBox = new System.Windows.Forms.GroupBox();
           this._haarSettingsGroupBox = new System.Windows.Forms.GroupBox();
           this._haarXMLFileComboBox = new System.Windows.Forms.ComboBox();
           this.label1 = new System.Windows.Forms.Label();
           ((System.ComponentModel.ISupportInitialize)(this._mhiDurationUpDown)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._binaryThreshUpDown)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._haarScaleUpDown)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._haarMinNeighborsUpDown)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._haarMinHeightUpDown)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._haarMinWidthUpDown)).BeginInit();
           this._motionTrackingSettingsGroupBox.SuspendLayout();
           this._haarSettingsGroupBox.SuspendLayout();
           this.SuspendLayout();
           // 
           // _cancelButton
           // 
           this._cancelButton.Location = new System.Drawing.Point(12, 334);
           this._cancelButton.Name = "_cancelButton";
           this._cancelButton.Size = new System.Drawing.Size(75, 23);
           this._cancelButton.TabIndex = 7;
           this._cancelButton.Text = "C&ancel";
           this._cancelButton.UseVisualStyleBackColor = true;
           this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
           // 
           // _okButton
           // 
           this._okButton.Location = new System.Drawing.Point(232, 334);
           this._okButton.Name = "_okButton";
           this._okButton.Size = new System.Drawing.Size(75, 23);
           this._okButton.TabIndex = 8;
           this._okButton.Text = "&OK";
           this._okButton.UseVisualStyleBackColor = true;
           this._okButton.Click += new System.EventHandler(this._okButton_Click);
           // 
           // _mhiDurationLabel
           // 
           this._mhiDurationLabel.AutoSize = true;
           this._mhiDurationLabel.Location = new System.Drawing.Point(61, 22);
           this._mhiDurationLabel.Name = "_mhiDurationLabel";
           this._mhiDurationLabel.Size = new System.Drawing.Size(209, 13);
           this._mhiDurationLabel.TabIndex = 9;
           this._mhiDurationLabel.Text = "Motion history image duration (milliseconds)";
           // 
           // _binaryThresholdLabel
           // 
           this._binaryThresholdLabel.AutoSize = true;
           this._binaryThresholdLabel.Location = new System.Drawing.Point(61, 48);
           this._binaryThresholdLabel.Name = "_binaryThresholdLabel";
           this._binaryThresholdLabel.Size = new System.Drawing.Size(82, 13);
           this._binaryThresholdLabel.TabIndex = 11;
           this._binaryThresholdLabel.Text = "Binary threshold";
           // 
           // _mhiDurationUpDown
           // 
           this._mhiDurationUpDown.DecimalPlaces = 2;
           this._mhiDurationUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
           this._mhiDurationUpDown.Location = new System.Drawing.Point(6, 19);
           this._mhiDurationUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
           this._mhiDurationUpDown.Name = "_mhiDurationUpDown";
           this._mhiDurationUpDown.Size = new System.Drawing.Size(49, 20);
           this._mhiDurationUpDown.TabIndex = 12;
           // 
           // _binaryThreshUpDown
           // 
           this._binaryThreshUpDown.Location = new System.Drawing.Point(6, 45);
           this._binaryThreshUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
           this._binaryThreshUpDown.Name = "_binaryThreshUpDown";
           this._binaryThreshUpDown.Size = new System.Drawing.Size(49, 20);
           this._binaryThreshUpDown.TabIndex = 14;
           // 
           // _haarScaleUpDown
           // 
           this._haarScaleUpDown.DecimalPlaces = 2;
           this._haarScaleUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
           this._haarScaleUpDown.Location = new System.Drawing.Point(6, 19);
           this._haarScaleUpDown.Name = "_haarScaleUpDown";
           this._haarScaleUpDown.Size = new System.Drawing.Size(49, 20);
           this._haarScaleUpDown.TabIndex = 15;
           // 
           // _haarMinNeighborsUpDown
           // 
           this._haarMinNeighborsUpDown.Location = new System.Drawing.Point(6, 45);
           this._haarMinNeighborsUpDown.Name = "_haarMinNeighborsUpDown";
           this._haarMinNeighborsUpDown.Size = new System.Drawing.Size(49, 20);
           this._haarMinNeighborsUpDown.TabIndex = 16;
           // 
           // _haarMinHeightUpDown
           // 
           this._haarMinHeightUpDown.Location = new System.Drawing.Point(6, 97);
           this._haarMinHeightUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
           this._haarMinHeightUpDown.Name = "_haarMinHeightUpDown";
           this._haarMinHeightUpDown.Size = new System.Drawing.Size(49, 20);
           this._haarMinHeightUpDown.TabIndex = 17;
           // 
           // _haarMinWidthUpDown
           // 
           this._haarMinWidthUpDown.Location = new System.Drawing.Point(6, 71);
           this._haarMinWidthUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
           this._haarMinWidthUpDown.Name = "_haarMinWidthUpDown";
           this._haarMinWidthUpDown.Size = new System.Drawing.Size(49, 20);
           this._haarMinWidthUpDown.TabIndex = 18;
           // 
           // _haarScaleLabel
           // 
           this._haarScaleLabel.AutoSize = true;
           this._haarScaleLabel.Location = new System.Drawing.Point(61, 21);
           this._haarScaleLabel.Name = "_haarScaleLabel";
           this._haarScaleLabel.Size = new System.Drawing.Size(64, 13);
           this._haarScaleLabel.TabIndex = 19;
           this._haarScaleLabel.Text = "Scale factor";
           // 
           // _haarMinNeighborLabel
           // 
           this._haarMinNeighborLabel.AutoSize = true;
           this._haarMinNeighborLabel.Location = new System.Drawing.Point(61, 47);
           this._haarMinNeighborLabel.Name = "_haarMinNeighborLabel";
           this._haarMinNeighborLabel.Size = new System.Drawing.Size(97, 13);
           this._haarMinNeighborLabel.TabIndex = 20;
           this._haarMinNeighborLabel.Text = "Minimum neighbors";
           // 
           // _haarMinWidthLabel
           // 
           this._haarMinWidthLabel.AutoSize = true;
           this._haarMinWidthLabel.Location = new System.Drawing.Point(61, 73);
           this._haarMinWidthLabel.Name = "_haarMinWidthLabel";
           this._haarMinWidthLabel.Size = new System.Drawing.Size(111, 13);
           this._haarMinWidthLabel.TabIndex = 21;
           this._haarMinWidthLabel.Text = "Minimum width (pixels)";
           // 
           // _haarMinHeightLabel
           // 
           this._haarMinHeightLabel.AutoSize = true;
           this._haarMinHeightLabel.Location = new System.Drawing.Point(61, 99);
           this._haarMinHeightLabel.Name = "_haarMinHeightLabel";
           this._haarMinHeightLabel.Size = new System.Drawing.Size(115, 13);
           this._haarMinHeightLabel.TabIndex = 22;
           this._haarMinHeightLabel.Text = "Minimum height (pixels)";
           // 
           // _motionTrackingSettingsGroupBox
           // 
           this._motionTrackingSettingsGroupBox.Controls.Add(this._mhiDurationUpDown);
           this._motionTrackingSettingsGroupBox.Controls.Add(this._binaryThreshUpDown);
           this._motionTrackingSettingsGroupBox.Controls.Add(this._mhiDurationLabel);
           this._motionTrackingSettingsGroupBox.Controls.Add(this._binaryThresholdLabel);
           this._motionTrackingSettingsGroupBox.Location = new System.Drawing.Point(12, 12);
           this._motionTrackingSettingsGroupBox.Name = "_motionTrackingSettingsGroupBox";
           this._motionTrackingSettingsGroupBox.Size = new System.Drawing.Size(295, 80);
           this._motionTrackingSettingsGroupBox.TabIndex = 23;
           this._motionTrackingSettingsGroupBox.TabStop = false;
           this._motionTrackingSettingsGroupBox.Text = "Motion Tracking algorithm settings";
           // 
           // _haarSettingsGroupBox
           // 
           this._haarSettingsGroupBox.Controls.Add(this.label1);
           this._haarSettingsGroupBox.Controls.Add(this._haarXMLFileComboBox);
           this._haarSettingsGroupBox.Controls.Add(this._haarScaleUpDown);
           this._haarSettingsGroupBox.Controls.Add(this._haarScaleLabel);
           this._haarSettingsGroupBox.Controls.Add(this._haarMinHeightLabel);
           this._haarSettingsGroupBox.Controls.Add(this._haarMinNeighborsUpDown);
           this._haarSettingsGroupBox.Controls.Add(this._haarMinHeightUpDown);
           this._haarSettingsGroupBox.Controls.Add(this._haarMinWidthLabel);
           this._haarSettingsGroupBox.Controls.Add(this._haarMinNeighborLabel);
           this._haarSettingsGroupBox.Controls.Add(this._haarMinWidthUpDown);
           this._haarSettingsGroupBox.Location = new System.Drawing.Point(12, 98);
           this._haarSettingsGroupBox.Name = "_haarSettingsGroupBox";
           this._haarSettingsGroupBox.Size = new System.Drawing.Size(295, 189);
           this._haarSettingsGroupBox.TabIndex = 24;
           this._haarSettingsGroupBox.TabStop = false;
           this._haarSettingsGroupBox.Text = "Haar classifier cascade settings";
           // 
           // _haarXMLFileComboBox
           // 
           this._haarXMLFileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this._haarXMLFileComboBox.FormattingEnabled = true;
           this._haarXMLFileComboBox.Location = new System.Drawing.Point(6, 145);
           this._haarXMLFileComboBox.Name = "_haarXMLFileComboBox";
           this._haarXMLFileComboBox.Size = new System.Drawing.Size(264, 21);
           this._haarXMLFileComboBox.TabIndex = 23;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(10, 129);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(118, 13);
           this.label1.TabIndex = 24;
           this.label1.Text = "Haar cascade XML file:";
           // 
           // InternalParametersForm
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(319, 369);
           this.Controls.Add(this._haarSettingsGroupBox);
           this.Controls.Add(this._motionTrackingSettingsGroupBox);
           this.Controls.Add(this._okButton);
           this.Controls.Add(this._cancelButton);
           this.Name = "InternalParametersForm";
           this.Text = "Internal Parameters";
           this.Load += new System.EventHandler(this.InternalParametersForm_Load);
           ((System.ComponentModel.ISupportInitialize)(this._mhiDurationUpDown)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._binaryThreshUpDown)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._haarScaleUpDown)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._haarMinNeighborsUpDown)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._haarMinHeightUpDown)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._haarMinWidthUpDown)).EndInit();
           this._motionTrackingSettingsGroupBox.ResumeLayout(false);
           this._motionTrackingSettingsGroupBox.PerformLayout();
           this._haarSettingsGroupBox.ResumeLayout(false);
           this._haarSettingsGroupBox.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Label _mhiDurationLabel;
        private System.Windows.Forms.Label _binaryThresholdLabel;
        private System.Windows.Forms.NumericUpDown _mhiDurationUpDown;
        private System.Windows.Forms.NumericUpDown _binaryThreshUpDown;
        private System.Windows.Forms.NumericUpDown _haarScaleUpDown;
        private System.Windows.Forms.NumericUpDown _haarMinNeighborsUpDown;
        private System.Windows.Forms.NumericUpDown _haarMinHeightUpDown;
        private System.Windows.Forms.NumericUpDown _haarMinWidthUpDown;
        private System.Windows.Forms.Label _haarScaleLabel;
        private System.Windows.Forms.Label _haarMinNeighborLabel;
        private System.Windows.Forms.Label _haarMinWidthLabel;
        private System.Windows.Forms.Label _haarMinHeightLabel;
        private System.Windows.Forms.GroupBox _motionTrackingSettingsGroupBox;
        private System.Windows.Forms.GroupBox _haarSettingsGroupBox;
        private System.Windows.Forms.ComboBox _haarXMLFileComboBox;
        private System.Windows.Forms.Label label1;
    }
}