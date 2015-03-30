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
    partial class MotionTrackerUI
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
           System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
           System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
           System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
           this._videoFrameGroupBox = new System.Windows.Forms.GroupBox();
           this._videoFramePictureBox = new System.Windows.Forms.PictureBox();
           this._controlsGroupBox = new System.Windows.Forms.GroupBox();
           this._simulationButton = new System.Windows.Forms.Button();
           this._faceCheckBox = new System.Windows.Forms.CheckBox();
           this._setInternalParamsButton = new System.Windows.Forms.Button();
           this._orButton2 = new System.Windows.Forms.Label();
           this._camLiveButton = new System.Windows.Forms.Button();
           this._orLabel = new System.Windows.Forms.Label();
           this._displayGraphCheckBox = new System.Windows.Forms.CheckBox();
           this._selectOutputDirectoryButton = new System.Windows.Forms.Button();
           this._visualizationCheckBox = new System.Windows.Forms.CheckBox();
           this._selectInputDirectoryButton = new System.Windows.Forms.Button();
           this._selectInputFileButton = new System.Windows.Forms.Button();
           this._outputMotionCheckBox = new System.Windows.Forms.CheckBox();
           this._runDemoButton = new System.Windows.Forms.Button();
           this._abortButton = new System.Windows.Forms.Button();
           this._startButton = new System.Windows.Forms.Button();
           this._motionTrackerGroupBox = new System.Windows.Forms.GroupBox();
           this._motionTrackerPictureBox = new System.Windows.Forms.PictureBox();
           this._timeSeriesGroupBox = new System.Windows.Forms.GroupBox();
           this._yScaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
           this._yaxisLabel = new System.Windows.Forms.Label();
           this._xScaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
           this._xaxisLabel = new System.Windows.Forms.Label();
           this._movingMotionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
           this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
           this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
           this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
           this._videoFrameGroupBox.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._videoFramePictureBox)).BeginInit();
           this._controlsGroupBox.SuspendLayout();
           this._motionTrackerGroupBox.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._motionTrackerPictureBox)).BeginInit();
           this._timeSeriesGroupBox.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._yScaleNumericUpDown)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._xScaleNumericUpDown)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._movingMotionChart)).BeginInit();
           this.SuspendLayout();
           // 
           // _videoFrameGroupBox
           // 
           this._videoFrameGroupBox.Controls.Add(this._videoFramePictureBox);
           this._videoFrameGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._videoFrameGroupBox.Location = new System.Drawing.Point(7, 3);
           this._videoFrameGroupBox.Name = "_videoFrameGroupBox";
           this._videoFrameGroupBox.Size = new System.Drawing.Size(360, 270);
           this._videoFrameGroupBox.TabIndex = 0;
           this._videoFrameGroupBox.TabStop = false;
           this._videoFrameGroupBox.Text = "Actual video frame";
           // 
           // _videoFramePictureBox
           // 
           this._videoFramePictureBox.Location = new System.Drawing.Point(6, 20);
           this._videoFramePictureBox.Name = "_videoFramePictureBox";
           this._videoFramePictureBox.Size = new System.Drawing.Size(350, 240);
           this._videoFramePictureBox.TabIndex = 0;
           this._videoFramePictureBox.TabStop = false;
           // 
           // _controlsGroupBox
           // 
           this._controlsGroupBox.Controls.Add(this._simulationButton);
           this._controlsGroupBox.Controls.Add(this._faceCheckBox);
           this._controlsGroupBox.Controls.Add(this._setInternalParamsButton);
           this._controlsGroupBox.Controls.Add(this._orButton2);
           this._controlsGroupBox.Controls.Add(this._camLiveButton);
           this._controlsGroupBox.Controls.Add(this._orLabel);
           this._controlsGroupBox.Controls.Add(this._displayGraphCheckBox);
           this._controlsGroupBox.Controls.Add(this._selectOutputDirectoryButton);
           this._controlsGroupBox.Controls.Add(this._visualizationCheckBox);
           this._controlsGroupBox.Controls.Add(this._selectInputDirectoryButton);
           this._controlsGroupBox.Controls.Add(this._selectInputFileButton);
           this._controlsGroupBox.Controls.Add(this._outputMotionCheckBox);
           this._controlsGroupBox.Controls.Add(this._runDemoButton);
           this._controlsGroupBox.Controls.Add(this._abortButton);
           this._controlsGroupBox.Controls.Add(this._startButton);
           this._controlsGroupBox.Controls.Add(this.shapeContainer1);
           this._controlsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._controlsGroupBox.Location = new System.Drawing.Point(383, 279);
           this._controlsGroupBox.Name = "_controlsGroupBox";
           this._controlsGroupBox.Size = new System.Drawing.Size(360, 270);
           this._controlsGroupBox.TabIndex = 1;
           this._controlsGroupBox.TabStop = false;
           this._controlsGroupBox.Text = "Controls";
           // 
           // _simulationButton
           // 
           this._simulationButton.Location = new System.Drawing.Point(205, 77);
           this._simulationButton.Name = "_simulationButton";
           this._simulationButton.Size = new System.Drawing.Size(141, 24);
           this._simulationButton.TabIndex = 19;
           this._simulationButton.Text = "Run simulation";
           this._simulationButton.UseVisualStyleBackColor = true;
           this._simulationButton.Click += new System.EventHandler(this._simulationButton_Click);
           // 
           // _faceCheckBox
           // 
           this._faceCheckBox.AutoSize = true;
           this._faceCheckBox.Location = new System.Drawing.Point(20, 143);
           this._faceCheckBox.Name = "_faceCheckBox";
           this._faceCheckBox.Size = new System.Drawing.Size(225, 19);
           this._faceCheckBox.TabIndex = 18;
           this._faceCheckBox.Text = "Save time series of face region to file";
           this._faceCheckBox.UseVisualStyleBackColor = true;
           this._faceCheckBox.CheckedChanged += new System.EventHandler(this._faceOnlyCheckBox_CheckedChanged);
           // 
           // _setInternalParamsButton
           // 
           this._setInternalParamsButton.Location = new System.Drawing.Point(206, 48);
           this._setInternalParamsButton.Name = "_setInternalParamsButton";
           this._setInternalParamsButton.Size = new System.Drawing.Size(140, 23);
           this._setInternalParamsButton.TabIndex = 17;
           this._setInternalParamsButton.Text = "Algorithm settings";
           this._setInternalParamsButton.UseVisualStyleBackColor = true;
           this._setInternalParamsButton.Click += new System.EventHandler(this._setInternalParamsButton_Click);
           // 
           // _orButton2
           // 
           this._orButton2.AutoSize = true;
           this._orButton2.Location = new System.Drawing.Point(17, 83);
           this._orButton2.Name = "_orButton2";
           this._orButton2.Size = new System.Drawing.Size(25, 15);
           this._orButton2.TabIndex = 16;
           this._orButton2.Text = "OR";
           // 
           // _camLiveButton
           // 
           this._camLiveButton.Location = new System.Drawing.Point(47, 78);
           this._camLiveButton.Name = "_camLiveButton";
           this._camLiveButton.Size = new System.Drawing.Size(141, 24);
           this._camLiveButton.TabIndex = 15;
           this._camLiveButton.Text = "Capture from camera";
           this._camLiveButton.UseVisualStyleBackColor = true;
           this._camLiveButton.Click += new System.EventHandler(this._camLiveButton_Click);
           // 
           // _orLabel
           // 
           this._orLabel.AutoSize = true;
           this._orLabel.Location = new System.Drawing.Point(17, 53);
           this._orLabel.Name = "_orLabel";
           this._orLabel.Size = new System.Drawing.Size(25, 15);
           this._orLabel.TabIndex = 14;
           this._orLabel.Text = "OR";
           // 
           // _displayGraphCheckBox
           // 
           this._displayGraphCheckBox.AutoSize = true;
           this._displayGraphCheckBox.Location = new System.Drawing.Point(20, 193);
           this._displayGraphCheckBox.Name = "_displayGraphCheckBox";
           this._displayGraphCheckBox.Size = new System.Drawing.Size(271, 19);
           this._displayGraphCheckBox.TabIndex = 13;
           this._displayGraphCheckBox.Text = "Display motion time series during processing";
           this._displayGraphCheckBox.UseVisualStyleBackColor = true;
           this._displayGraphCheckBox.CheckedChanged += new System.EventHandler(this._displayGraphCheckBox_CheckedChanged);
           // 
           // _selectOutputDirectoryButton
           // 
           this._selectOutputDirectoryButton.Location = new System.Drawing.Point(206, 19);
           this._selectOutputDirectoryButton.Name = "_selectOutputDirectoryButton";
           this._selectOutputDirectoryButton.Size = new System.Drawing.Size(140, 23);
           this._selectOutputDirectoryButton.TabIndex = 11;
           this._selectOutputDirectoryButton.Text = "Select output directory";
           this._selectOutputDirectoryButton.UseVisualStyleBackColor = true;
           this._selectOutputDirectoryButton.Click += new System.EventHandler(this._selectOutputDirectoryButton_Click);
           // 
           // _visualizationCheckBox
           // 
           this._visualizationCheckBox.AutoSize = true;
           this._visualizationCheckBox.Location = new System.Drawing.Point(20, 168);
           this._visualizationCheckBox.Name = "_visualizationCheckBox";
           this._visualizationCheckBox.Size = new System.Drawing.Size(237, 19);
           this._visualizationCheckBox.TabIndex = 7;
           this._visualizationCheckBox.Text = "Display visualization during processing";
           this._visualizationCheckBox.UseVisualStyleBackColor = true;
           this._visualizationCheckBox.CheckedChanged += new System.EventHandler(this._visualizationCheckBox_CheckedChanged);
           // 
           // _selectInputDirectoryButton
           // 
           this._selectInputDirectoryButton.Location = new System.Drawing.Point(48, 49);
           this._selectInputDirectoryButton.Name = "_selectInputDirectoryButton";
           this._selectInputDirectoryButton.Size = new System.Drawing.Size(140, 23);
           this._selectInputDirectoryButton.TabIndex = 5;
           this._selectInputDirectoryButton.Text = "Select input directory";
           this._selectInputDirectoryButton.UseVisualStyleBackColor = true;
           this._selectInputDirectoryButton.Click += new System.EventHandler(this._selectInputDirectoryButton_Click);
           // 
           // _selectInputFileButton
           // 
           this._selectInputFileButton.Location = new System.Drawing.Point(47, 20);
           this._selectInputFileButton.Name = "_selectInputFileButton";
           this._selectInputFileButton.Size = new System.Drawing.Size(141, 23);
           this._selectInputFileButton.TabIndex = 4;
           this._selectInputFileButton.Text = "Select input file";
           this._selectInputFileButton.UseVisualStyleBackColor = true;
           this._selectInputFileButton.Click += new System.EventHandler(this._selectInputFileButton_Click);
           // 
           // _outputMotionCheckBox
           // 
           this._outputMotionCheckBox.AutoSize = true;
           this._outputMotionCheckBox.Location = new System.Drawing.Point(20, 118);
           this._outputMotionCheckBox.Name = "_outputMotionCheckBox";
           this._outputMotionCheckBox.Size = new System.Drawing.Size(227, 19);
           this._outputMotionCheckBox.TabIndex = 3;
           this._outputMotionCheckBox.Text = "Save video of motion silhouette to file";
           this._outputMotionCheckBox.UseVisualStyleBackColor = true;
           this._outputMotionCheckBox.CheckedChanged += new System.EventHandler(this._outputMotionCheckBox_CheckedChanged);
           // 
           // _runDemoButton
           // 
           this._runDemoButton.Location = new System.Drawing.Point(138, 226);
           this._runDemoButton.Name = "_runDemoButton";
           this._runDemoButton.Size = new System.Drawing.Size(90, 23);
           this._runDemoButton.TabIndex = 2;
           this._runDemoButton.Text = "R&un Demo";
           this._runDemoButton.UseVisualStyleBackColor = true;
           this._runDemoButton.Click += new System.EventHandler(this._runDemoButton_Click);
           // 
           // _abortButton
           // 
           this._abortButton.Location = new System.Drawing.Point(256, 226);
           this._abortButton.Name = "_abortButton";
           this._abortButton.Size = new System.Drawing.Size(90, 23);
           this._abortButton.TabIndex = 1;
           this._abortButton.Text = "Ab&ort";
           this._abortButton.UseVisualStyleBackColor = true;
           this._abortButton.Click += new System.EventHandler(this._abortButton_Click);
           // 
           // _startButton
           // 
           this._startButton.Location = new System.Drawing.Point(20, 226);
           this._startButton.Name = "_startButton";
           this._startButton.Size = new System.Drawing.Size(90, 23);
           this._startButton.TabIndex = 0;
           this._startButton.Text = "&Start";
           this._startButton.UseVisualStyleBackColor = true;
           this._startButton.Click += new System.EventHandler(this._startButton_Click);
           // 
           // _motionTrackerGroupBox
           // 
           this._motionTrackerGroupBox.Controls.Add(this._motionTrackerPictureBox);
           this._motionTrackerGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._motionTrackerGroupBox.Location = new System.Drawing.Point(383, 3);
           this._motionTrackerGroupBox.Name = "_motionTrackerGroupBox";
           this._motionTrackerGroupBox.Size = new System.Drawing.Size(360, 270);
           this._motionTrackerGroupBox.TabIndex = 2;
           this._motionTrackerGroupBox.TabStop = false;
           this._motionTrackerGroupBox.Text = "Motion silhouette";
           // 
           // _motionTrackerPictureBox
           // 
           this._motionTrackerPictureBox.Location = new System.Drawing.Point(6, 20);
           this._motionTrackerPictureBox.Name = "_motionTrackerPictureBox";
           this._motionTrackerPictureBox.Size = new System.Drawing.Size(350, 240);
           this._motionTrackerPictureBox.TabIndex = 1;
           this._motionTrackerPictureBox.TabStop = false;
           // 
           // _timeSeriesGroupBox
           // 
           this._timeSeriesGroupBox.Controls.Add(this._yScaleNumericUpDown);
           this._timeSeriesGroupBox.Controls.Add(this._yaxisLabel);
           this._timeSeriesGroupBox.Controls.Add(this._xScaleNumericUpDown);
           this._timeSeriesGroupBox.Controls.Add(this._xaxisLabel);
           this._timeSeriesGroupBox.Controls.Add(this._movingMotionChart);
           this._timeSeriesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._timeSeriesGroupBox.Location = new System.Drawing.Point(7, 279);
           this._timeSeriesGroupBox.Name = "_timeSeriesGroupBox";
           this._timeSeriesGroupBox.Size = new System.Drawing.Size(360, 270);
           this._timeSeriesGroupBox.TabIndex = 3;
           this._timeSeriesGroupBox.TabStop = false;
           this._timeSeriesGroupBox.Text = "Motion time series";
           // 
           // _yScaleNumericUpDown
           // 
           this._yScaleNumericUpDown.DecimalPlaces = 1;
           this._yScaleNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
           this._yScaleNumericUpDown.Location = new System.Drawing.Point(80, 245);
           this._yScaleNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            65536});
           this._yScaleNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
           this._yScaleNumericUpDown.Name = "_yScaleNumericUpDown";
           this._yScaleNumericUpDown.Size = new System.Drawing.Size(61, 21);
           this._yScaleNumericUpDown.TabIndex = 20;
           this._yScaleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
           this._yScaleNumericUpDown.ValueChanged += new System.EventHandler(this._yScaleNumericUpDown_ValueChanged);
           // 
           // _yaxisLabel
           // 
           this._yaxisLabel.AutoSize = true;
           this._yaxisLabel.Location = new System.Drawing.Point(6, 247);
           this._yaxisLabel.Name = "_yaxisLabel";
           this._yaxisLabel.Size = new System.Drawing.Size(68, 15);
           this._yaxisLabel.TabIndex = 19;
           this._yaxisLabel.Text = "y-axis max:";
           // 
           // _xScaleNumericUpDown
           // 
           this._xScaleNumericUpDown.Location = new System.Drawing.Point(293, 245);
           this._xScaleNumericUpDown.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
           this._xScaleNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
           this._xScaleNumericUpDown.Name = "_xScaleNumericUpDown";
           this._xScaleNumericUpDown.Size = new System.Drawing.Size(61, 21);
           this._xScaleNumericUpDown.TabIndex = 17;
           this._xScaleNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
           this._xScaleNumericUpDown.ValueChanged += new System.EventHandler(this._xScaleNumericUpDown_ValueChanged);
           // 
           // _xaxisLabel
           // 
           this._xaxisLabel.AutoSize = true;
           this._xaxisLabel.Location = new System.Drawing.Point(213, 247);
           this._xaxisLabel.Name = "_xaxisLabel";
           this._xaxisLabel.Size = new System.Drawing.Size(69, 15);
           this._xaxisLabel.TabIndex = 18;
           this._xaxisLabel.Text = "x-axis max:";
           // 
           // _movingMotionChart
           // 
           chartArea2.AxisX.MajorGrid.IntervalOffset = 0D;
           chartArea2.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
           chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
           chartArea2.AxisX.ScaleView.Zoomable = false;
           chartArea2.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
           chartArea2.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
           chartArea2.AxisY.MajorGrid.Interval = 0D;
           chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
           chartArea2.Name = "ChartArea";
           this._movingMotionChart.ChartAreas.Add(chartArea2);
           legend2.Enabled = false;
           legend2.Name = "Legend1";
           this._movingMotionChart.Legends.Add(legend2);
           this._movingMotionChart.Location = new System.Drawing.Point(7, 19);
           this._movingMotionChart.Name = "_movingMotionChart";
           series2.ChartArea = "ChartArea";
           series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
           series2.IsVisibleInLegend = false;
           series2.Legend = "Legend1";
           series2.LegendText = "leg";
           series2.Name = "Series1";
           series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
           this._movingMotionChart.Series.Add(series2);
           this._movingMotionChart.Size = new System.Drawing.Size(347, 223);
           this._movingMotionChart.TabIndex = 0;
           // 
           // shapeContainer1
           // 
           this.shapeContainer1.Location = new System.Drawing.Point(3, 17);
           this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
           this.shapeContainer1.Name = "shapeContainer1";
           this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
           this.shapeContainer1.Size = new System.Drawing.Size(354, 250);
           this.shapeContainer1.TabIndex = 20;
           this.shapeContainer1.TabStop = false;
           // 
           // lineShape1
           // 
           this.lineShape1.BorderColor = System.Drawing.SystemColors.ControlLight;
           this.lineShape1.Name = "lineShape1";
           this.lineShape1.X1 = 193;
           this.lineShape1.X2 = 193;
           this.lineShape1.Y1 = 6;
           this.lineShape1.Y2 = 78;
           // 
           // lineShape2
           // 
           this.lineShape2.BorderColor = System.Drawing.SystemColors.ControlLightLight;
           this.lineShape2.Name = "lineShape2";
           this.lineShape2.X1 = 194;
           this.lineShape2.X2 = 194;
           this.lineShape2.Y1 = 6;
           this.lineShape2.Y2 = 78;
           // 
           // MotionTrackerUI
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(756, 556);
           this.Controls.Add(this._timeSeriesGroupBox);
           this.Controls.Add(this._motionTrackerGroupBox);
           this.Controls.Add(this._controlsGroupBox);
           this.Controls.Add(this._videoFrameGroupBox);
           this.Name = "MotionTrackerUI";
           this.Text = "MotionTrackerUI";
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MotionTrackerUI_FormClosing);
           this._videoFrameGroupBox.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._videoFramePictureBox)).EndInit();
           this._controlsGroupBox.ResumeLayout(false);
           this._controlsGroupBox.PerformLayout();
           this._motionTrackerGroupBox.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._motionTrackerPictureBox)).EndInit();
           this._timeSeriesGroupBox.ResumeLayout(false);
           this._timeSeriesGroupBox.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this._yScaleNumericUpDown)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._xScaleNumericUpDown)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._movingMotionChart)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _videoFrameGroupBox;
        private System.Windows.Forms.GroupBox _controlsGroupBox;
        private System.Windows.Forms.GroupBox _motionTrackerGroupBox;
        private System.Windows.Forms.PictureBox _videoFramePictureBox;
        private System.Windows.Forms.PictureBox _motionTrackerPictureBox;
        private System.Windows.Forms.CheckBox _visualizationCheckBox;
        private System.Windows.Forms.Button _selectInputDirectoryButton;
        private System.Windows.Forms.Button _selectInputFileButton;
        private System.Windows.Forms.CheckBox _outputMotionCheckBox;
        private System.Windows.Forms.Button _runDemoButton;
        private System.Windows.Forms.Button _abortButton;
        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.Button _selectOutputDirectoryButton;
        private System.Windows.Forms.GroupBox _timeSeriesGroupBox;
        private System.Windows.Forms.CheckBox _displayGraphCheckBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart _movingMotionChart;
        private System.Windows.Forms.Label _orButton2;
        private System.Windows.Forms.Button _camLiveButton;
        private System.Windows.Forms.Label _orLabel;
        private System.Windows.Forms.NumericUpDown _yScaleNumericUpDown;
        private System.Windows.Forms.Label _yaxisLabel;
        private System.Windows.Forms.NumericUpDown _xScaleNumericUpDown;
        private System.Windows.Forms.Label _xaxisLabel;
        private System.Windows.Forms.Button _setInternalParamsButton;
        private System.Windows.Forms.CheckBox _faceCheckBox;
        private System.Windows.Forms.Button _simulationButton;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
    }
}