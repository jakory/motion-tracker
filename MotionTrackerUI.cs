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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using OpenCvSharp;

namespace MotionTracker
{
   /// <summary>
   /// Graphic user interface for running the motion detection algorithm
   /// on videos.
   /// 
   /// Allows user to select to process the motion from a single video 
   /// file, a directory of video files, or a live camera feed. User can
   /// opt to view the video frames during processing, as well as the 
   /// motion silhouette and a moving graph of the motion measure.  
   /// 
   /// Authors: Jacqueline Kory
   /// Last modified 04.17.2012.
   /// 
   /// Built and tested on a Windows 7 x64 machine. Run in x86 mode.
   /// Uses OpenCvSharp 
   /// </summary>
   public partial class MotionTrackerUI : Form
   {
      MotionTracking motionTracker; // motion tracker
      Thread _motionTrackerThread; // motion tracker thread

      // files and file paths
      private String inFile = ""; // input single file
      private String inDirectory = ""; // input directory of files
      private String outDirectory = ""; // output directory

      private String liveCamSaveLoc = ""; // live cam save location
      private int liveCamIndex = Constants.NO_LIVE_CAM; // camera index

      private bool visualization = false; // show visualizer flag
      private bool outputMotionSilh = false; // save motion silh movie to file
      private bool showGraph = false; // show graph flag
      private bool liveCamera = false; // true if processing from camera feed
      private bool outputFace = false; // calc motion only from face rect

      int dataCount = 0; // for moving graph


      #region constructor, configure, close

      /// <summary>
      /// Default constructor
      /// </summary>
      public MotionTrackerUI()
      {
         InitializeComponent();
         ConfigureComponent();
      }

      /// <summary>
      /// Configure component
      /// </summary>
      private void ConfigureComponent()
      {
         // make simulation button invisible?
         this._simulationButton.Visible = Constants.SHOW_SIM_BUTTON;

         // initialize motion tracker
         this.motionTracker = new MotionTracking();
         this.motionTracker.AbortedEvent += new MotionTracking.
             AbortMotionTracking(motionTracker_AbortedEvent);
         this.motionTracker.DoneEvent += new MotionTracking.
             DoneMotionTracking(motionTracker_DoneEvent);

         // configure moving time series
         SetTimeSeriesVisibility(false);
         if (this._movingMotionChart.Series.Count > 0)
         {
            this._movingMotionChart.Series[Constants.SERIES].Enabled = true;

            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisX.
                IntervalAutoMode = System.Windows.Forms.DataVisualization.
                Charting.IntervalAutoMode.FixedCount;

            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisX.
                Interval = Constants.DEFAULT_X_AXIS_MAX /
                Constants.LINES_X_AXIS;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisX.
                Maximum = Constants.DEFAULT_X_AXIS_MAX;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisX.
                Minimum = Constants.DEFAULT_X_AXIS_MIN;

            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisY.
                IntervalAutoMode = System.Windows.Forms.DataVisualization.
                Charting.IntervalAutoMode.FixedCount;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisY.
                Interval = Constants.DEFAULT_Y_AXIS_MAX /
                Constants.LINES_Y_AXIS;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisY.
                Maximum = Constants.DEFAULT_Y_AXIS_MAX;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisY.
                Minimum = Constants.DEFAULT_Y_AXIS_MIN;
         }

         // initially, no buttons enabled
         // (until after "input file" or "input directory" is selected)
         this._abortButton.Enabled = false;
         this._startButton.Enabled = true;
         this._runDemoButton.Enabled = true;
         this._selectInputFileButton.Enabled = true;
         this._selectInputDirectoryButton.Enabled = true;
         this._selectOutputDirectoryButton.Enabled = true;
         this._camLiveButton.Enabled = true;
      }

      /// <summary>
      /// Motion tracker UI form closing event handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void MotionTrackerUI_FormClosing(object sender,
          FormClosingEventArgs e)
      {
         // when the form closes, make sure the motion tracker thread
         // isn't running
         if (this._motionTrackerThread != null
             && _motionTrackerThread.IsAlive)
         {
            this._motionTrackerThread.Abort();
         }
      }

      #endregion

      #region UI buttons

      /// <summary>
      /// select input file button click handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _selectInputFileButton_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();
         ofd.CheckFileExists = true;
         ofd.CheckPathExists = true;
         ofd.Multiselect = false;
         ofd.DefaultExt = ".avi";
         ofd.FileName = "*.avi";
         ofd.Title = "Choose which file to process";
         DialogResult res = ofd.ShowDialog();

         // if the user selected "OK" (not "cancel"), and if the file
         // exists (which it should, since the dialog box is set to
         // check that, but we'll check here anyway)
         if (res == System.Windows.Forms.DialogResult.OK
             && Directory.Exists(Path.GetDirectoryName(ofd.FileName)))
         {
            // check file extensions so we get video files only
            if (!Path.GetExtension(ofd.FileName).Equals(".avi"))
            {
               MessageBox.Show("Error: " + ofd.FileName + " is not a "
                   + "valid AVI file.", "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
               return;
            }

            // great! set the filename and change button appearance
            this.inFile = ofd.FileName;
            this.inDirectory = "";

            changeButtonTextOnSelection(Constants.Buttons.InFile);
         }
      }

      /// <summary>
      /// select input directory button click handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _selectInputDirectoryButton_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog fbd = new FolderBrowserDialog();
         fbd.Tag = "Choose a directory";
         DialogResult res = fbd.ShowDialog();

         // if user clicked "OK" and not "Cancel"
         if (res == System.Windows.Forms.DialogResult.OK
             && Directory.Exists(fbd.SelectedPath))
         {
            // save directory, change button appearance
            this.inDirectory = fbd.SelectedPath;
            this.inFile = "";

            changeButtonTextOnSelection(Constants.Buttons.InDir);
         }
      }

      /// <summary>
      /// select output directory button click handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _selectOutputDirectoryButton_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog fbd = new FolderBrowserDialog();
         fbd.Tag = "Choose a directory";
         DialogResult res = fbd.ShowDialog();

         // if user selected "OK" and not "cancel"
         if (res == System.Windows.Forms.DialogResult.OK
             && Directory.Exists(fbd.SelectedPath))
         {
            this.outDirectory = fbd.SelectedPath + "\\";

            this._selectOutputDirectoryButton.Text =
                Constants.OUT_DIR_SELECTED;
            this._selectOutputDirectoryButton.ForeColor = Color.Red;
         }

      }

      /// <summary>
      /// output motion check box checked changed handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _outputMotionCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         this.outputMotionSilh = this._outputMotionCheckBox.Checked;
      }

      /// <summary>
      /// visualization check box checked changed handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _visualizationCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         this.visualization = _visualizationCheckBox.Checked;
      }

      /// <summary>
      /// display graph check box checked changed handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _displayGraphCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         this.showGraph = this._displayGraphCheckBox.Checked;
      }

      /// <summary>
      /// Capture live from camera button click handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _camLiveButton_Click(object sender, EventArgs e)
      {
         this.liveCamera = true;
         this.inDirectory = "";
         this.inFile = "";

         // set up live camera
         LiveCamSetupForm camform = new LiveCamSetupForm();
         DialogResult res = camform.ShowDialog();

         // only change text if successful... 
         if (res == System.Windows.Forms.DialogResult.OK)
         {
            changeButtonTextOnSelection(Constants.Buttons.LiveCam);
            this.liveCamIndex = camform.GetCameraIndex();
            this.liveCamSaveLoc = camform.GetSaveVideoFileLocation();

         }

         camform.Dispose();
      }

      /// <summary>
      /// set internal parameters
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _setInternalParamsButton_Click(object sender, EventArgs e)
      {
         // collect internal settings
         InternalParametersForm ipf = new InternalParametersForm();
         DialogResult res = ipf.ShowDialog();

         // only change text if successful... 
         if (res == System.Windows.Forms.DialogResult.OK)
         {
            this.motionTracker.SetInternalParameters(ipf.MHIDuration,
                ipf.BinaryThreshold, ipf.haarScaleFactor,
                ipf.haarMinNeighbors, ipf.haarMinWidth,
                ipf.haarMinHeight, ipf.haarXMLFile);
            this._setInternalParamsButton.ForeColor = Color.Red;
         }
         else
         {
            this._setInternalParamsButton.ForeColor = Color.Black;
         }

         ipf.Dispose();
      }

      /// <summary>
      /// face only check box check changed handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _faceOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         this.outputFace = this._faceCheckBox.Checked;
      }

      /// <summary>
      /// run simulation button click event handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _simulationButton_Click(object sender, EventArgs e)
      {
         // if no output directory has been selected...
         if (this.outDirectory.Equals(""))
         {
            MessageBox.Show("Error: Please verify that you have selected"
               + " where to save results.",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
         }

         // enable/disable relevant buttons
         FlipUIEnabled();

         try
         {
            if (this.visualization)
            {
               this._motionTrackerPictureBox.Visible = true;
               this._videoFramePictureBox.Visible = true;
            }

            if (this.showGraph)
            {
               SetTimeSeriesVisibility(true);
            }
            RunSimulation(); // and run demo
         }
         catch (Exception ex) // oops, some error...
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
            MessageBox.Show("Error: Could not process file.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      #endregion

      #region start, demo, abort buttons
      /// <summary>
      /// start button click handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _startButton_Click(object sender, EventArgs e)
      {
         // verify that input/output files/directories have been selected...

         // if no input file or directory has been selected...
         if (this.inFile.Equals("") && !this.liveCamera &&
             this.inDirectory.Equals(""))
         {
            MessageBox.Show("Error: Please verify that you have selected "
               + "an AVI file or a directory of AVI files to process, or"
               + " elected to process live video from a camera.",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
         }
         // if no output directory has been selected...
         if (this.outDirectory.Equals(""))
         {
            MessageBox.Show("Error: Please verify that you have selected"
               + " where to save results.",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
         }

         // files/directories have been selected.
         // ask user to verify that these files/directories are correct
         //DialogResult dr = MessageBox.Show("Process " + 
         //    (this.liveCamera ? "from live camera feed" :                 
         //    (!this.inFile.Equals("") ? "file \"" + this.inFile
         //    : "directory \"" + this.inDirectory))
         //    + " and save results to \"" + this.outDirectory + "\"?",
         //    "Please verify", MessageBoxButtons.OKCancel, MessageBoxIcon.None);

         // if user decides not to continue, return
         //if (dr == DialogResult.Cancel)
         //    return;

         // otherwise, continue on and run motion tracker...
         // enable/disable relevant buttons
         FlipUIEnabled();

         // start motion tracker
         // if process file, run; otherwise, process directory of files
         try
         {
            if (this.visualization)
            {
               this._motionTrackerPictureBox.Visible = true;
               this._videoFramePictureBox.Visible = true;
            }

            if (this.showGraph)
            {
               SetTimeSeriesVisibility(true);
               this._xaxisLabel.Visible = true;
            }
            // run... (threaded)
            RunMotionTracker();
         }
         catch (Exception ex) // oops, some error...
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
            MessageBox.Show("Error: Could not process file.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      /// <summary>
      /// run demo button click handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _runDemoButton_Click(object sender, EventArgs e)
      {
         // enable/disable relevant buttons
         FlipUIEnabled();

         // run demonstration with sample video
         //MessageBox.Show("Sample results will be saved to files in this "
         //    + "program's root directory",
         //   "Information",
         //   MessageBoxButtons.OK, MessageBoxIcon.Information);
         try
         {
            if (this.visualization)
            {
               this._motionTrackerPictureBox.Visible = true;
               this._videoFramePictureBox.Visible = true;
            }

            if (this.showGraph)
            {
               SetTimeSeriesVisibility(true);
            }
            RunDemo(); // and run demo
         }
         catch (Exception ex) // oops, some error...
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
            MessageBox.Show("Error: Could not process file.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

      /// <summary>
      /// abort button click handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _abortButton_Click(object sender, EventArgs e)
      {
         // stop motion tracker
         motionTracker.StopProcessing();
      }

      #endregion

      #region run, demo, reset, done processing

      /// <summary>
      /// reset callback - to be threadsafe
      /// </summary>
      private delegate void ResetCallback();

      /// <summary>
      /// Reset
      /// </summary>
      private void Reset()
      {
         if (this.InvokeRequired)
         {
            ResetCallback c = new ResetCallback(Reset);
            this.Invoke(c, new object[] { });
         }
         else
         {
            // re-initialize motion tracker
            this.motionTracker = new MotionTracking();
            this.motionTracker.AbortedEvent += new MotionTracking.AbortMotionTracking(
            motionTracker_AbortedEvent);
            this.motionTracker.DoneEvent += new MotionTracking.DoneMotionTracking(
                motionTracker_DoneEvent);

            // renable all buttons
            FlipUIEnabled();

            // button text
            this._selectInputDirectoryButton.ForeColor = Color.Black;
            this._selectInputFileButton.ForeColor = Color.Black;
            this._camLiveButton.ForeColor = Color.Black;
            this._selectOutputDirectoryButton.ForeColor = Color.Black;
            this._selectInputDirectoryButton.Text = Constants.IN_DIR_SELECT;
            this._selectInputFileButton.Text = Constants.IN_FILE_SELECT;
            this._camLiveButton.Text = Constants.LIVE_CAM_SELECT;
            this._selectOutputDirectoryButton.Text = Constants.OUT_DIR_SELECT;
            this._setInternalParamsButton.ForeColor = Color.Black;

            // set picture box images to null
            this._motionTrackerPictureBox.Image = null;
            this._videoFramePictureBox.Image = null;
            this._motionTrackerPictureBox.Visible = false;
            this._videoFramePictureBox.Visible = false;

            // reset moving time series
            SetTimeSeriesVisibility(false);
            if (this._movingMotionChart.Series.Count > 0)
            {
               this._movingMotionChart.Series[Constants.SERIES].Points.Clear();
            }

            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisX.Interval =
               Constants.DEFAULT_X_AXIS_MAX / Constants.LINES_X_AXIS;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisX.Maximum =
                Constants.DEFAULT_X_AXIS_MAX;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisX.Minimum =
                Constants.DEFAULT_X_AXIS_MIN;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisY.Interval =
                Constants.DEFAULT_Y_AXIS_MAX / Constants.LINES_Y_AXIS;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisY.Maximum =
                Constants.DEFAULT_Y_AXIS_MAX;
            this._movingMotionChart.ChartAreas[Constants.SERIES].AxisY.Minimum =
                Constants.DEFAULT_Y_AXIS_MIN;

            this._xScaleNumericUpDown.Value = (decimal)Constants.DEFAULT_X_AXIS_MAX;
            this._yScaleNumericUpDown.Value = (decimal)Constants.DEFAULT_Y_AXIS_MAX;


            // stop motion tracker thread
            if (this._motionTrackerThread != null && _motionTrackerThread.IsAlive)
            {
               this._motionTrackerThread.Abort();
               this._motionTrackerThread.Join();
            }
         }
      }

      /// <summary>
      /// run motion tracker - starts run motion tracker thread
      /// </summary>
      private void RunMotionTracker()
      {
         this._motionTrackerThread = new Thread(new ThreadStart(RunMotionTrackerCallback));
         this._motionTrackerThread.Start();
      }

      /// <summary>
      /// run motion tracker callback
      /// </summary>
      private void RunMotionTrackerCallback()
      {
         // run from live cam
         if (this.liveCamera && Directory.Exists(this.outDirectory))
            this.motionTracker.RunFile(null,
                this.outDirectory, this.visualization, this.showGraph,
                this.outputMotionSilh, this.liveCamIndex,
                this.liveCamSaveLoc, this.outputFace);

         // run a single file
         else if (!this.inFile.Equals("") &&
             this.inDirectory.Equals("") &&
             Directory.Exists(Path.GetDirectoryName(this.inFile)) &&
             Directory.Exists(this.outDirectory))
            this.motionTracker.RunFile(this.inFile, this.outDirectory,
                this.visualization, this.showGraph, this.outputMotionSilh,
                Constants.NO_LIVE_CAM, null, this.outputFace);

         // run directory of files
         else if (Directory.Exists(this.inDirectory) &&
             Directory.Exists(this.outDirectory))
         {
            this.motionTracker.RunDirectory(this.inDirectory, this.outDirectory,
                this.visualization, this.showGraph, this.outputMotionSilh,
                this.outputFace);
         }
      }

      /// <summary>
      /// Run demo - starts run demo thread
      /// </summary>
      private void RunDemo()
      {
         this._motionTrackerThread = new Thread(new ThreadStart(RunDemoCallback));
         this._motionTrackerThread.Start();
      }

      /// <summary>
      /// Run demo callback
      /// </summary>
      private void RunDemoCallback()
      {
         motionTracker.RunDemo(this.visualization, this.showGraph, 
            this.outputMotionSilh, this.outputFace);
      }

      /// <summary>
      /// Run demo - starts run demo thread
      /// </summary>
      private void RunSimulation()
      {
         this._motionTrackerThread = new Thread(new ThreadStart(
            RunSimulationCallback));
         this._motionTrackerThread.Start();
      }

      /// <summary>
      /// Run demo callback
      /// </summary>
      private void RunSimulationCallback()
      {
         motionTracker.RunSimulation(this.visualization, this.showGraph,
            this.outputMotionSilh, this.outputFace, this.outDirectory);
      }

      /// <summary>
      /// Aborted event handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void motionTracker_AbortedEvent(object sender, EventArgs e)
      {
         // motion tracker successfully aborted
         Reset();
      }

      /// <summary>
      /// done event handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void motionTracker_DoneEvent(object sender, EventArgs e)
      {
         // show done message
         MessageBox.Show("Finished processing!", "Done!",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

         Reset();
      }

      #endregion

      #region video frame + motion silhouette display

      /// <summary>
      /// set video frame callback - for threadsafe set video frame
      /// </summary>
      /// <param name="img"></param>
      private delegate void SetVideoFrameCallback(IplImage img);

      /// <summary>
      /// Set video frame
      /// </summary>
      /// <param name="img"></param>
      public void SetVideoFrame(IplImage img)
      {
         if (this.InvokeRequired)
         {
            SetVideoFrameCallback c = new SetVideoFrameCallback(SetVideoFrame);
            this.Invoke(c, new object[] { img });
         }
         else
         {
            Bitmap imgb = OpenCvSharp.BitmapConverter.ToBitmap(img);
            if (imgb.Size.Width > this._videoFramePictureBox.Size.Width
                || imgb.Size.Height > this._videoFramePictureBox.Size.Height)
               this._videoFramePictureBox.Image = resizeImage(imgb, this._motionTrackerPictureBox.Size);
            else
               this._videoFramePictureBox.Image = imgb;
         }
      }

      /// <summary>
      /// set motion silh callback - for threadsafe set motion silh
      /// </summary>
      /// <param name="img"></param>
      private delegate void SetMotionSilhCallback(IplImage img);

      /// <summary>
      /// Set motion silhouette
      /// </summary>
      /// <param name="img"></param>
      public void SetMotionSilh(IplImage img)
      {
         if (this.InvokeRequired)
         {
            SetMotionSilhCallback c = new SetMotionSilhCallback(SetMotionSilh);
            this.Invoke(c, new object[] { img });
         }
         else
         {
            Bitmap imgb = OpenCvSharp.BitmapConverter.ToBitmap(img);

            if (imgb.Size.Width > this._motionTrackerPictureBox.Size.Width
                || imgb.Size.Height > this._motionTrackerPictureBox.Size.Height)
               this._motionTrackerPictureBox.Image = resizeImage(imgb, this._motionTrackerPictureBox.Size);
            else
               this._motionTrackerPictureBox.Image = imgb;

         }
      }

      /// <summary>
      /// resize image
      /// </summary>
      /// <param name="imgToResize"></param>
      /// <param name="size"></param>
      /// <returns></returns>
      public static Image resizeImage(Image imgToResize, Size size)
      {
         int sourceWidth = imgToResize.Width;
         int sourceHeight = imgToResize.Height;

         float nPercent = 0;
         float nPercentW = 0;
         float nPercentH = 0;

         nPercentW = ((float)size.Width / (float)sourceWidth);
         nPercentH = ((float)size.Height / (float)sourceHeight);

         if (nPercentH < nPercentW)
            nPercent = nPercentH;
         else
            nPercent = nPercentW;

         int destWidth = (int)(sourceWidth * nPercent);
         int destHeight = (int)(sourceHeight * nPercent);

         Bitmap b = new Bitmap(destWidth, destHeight);
         Graphics g = Graphics.FromImage((Image)b);
         g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

         g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
         g.Dispose();

         return (Image)b;
      }

      #endregion

      #region moving time series

      /// <summary>
      /// update moving time series callback - for threadsafe
      /// </summary>
      /// <param name="data"></param>
      private delegate void UpdateMovingTimeSeriesCallback(double data);

      /// <summary>
      /// Update moving time series
      /// </summary>
      public void UpdateMovingTimeSeries(double newData)
      {
         if (this.InvokeRequired)
         {
            UpdateMovingTimeSeriesCallback c = new UpdateMovingTimeSeriesCallback(
                UpdateMovingTimeSeries);
            this.Invoke(c, new object[] { newData });
         }
         else
         {

            this.dataCount++; // got another sample

            if (this._movingMotionChart.Series.Count < 1)
               return;

            try
            {
               // if at max steps, remove first item
               if (this._movingMotionChart.Series[Constants.SERIES].Points.Count >=
                   this._xScaleNumericUpDown.Value)
                  this._movingMotionChart.Series[Constants.SERIES].Points.RemoveAt(0);

               // and add new data to end of series
               this._movingMotionChart.Series[Constants.SERIES].Points.Add(newData);
            }
            catch (Exception e)
            {
               System.Diagnostics.Trace.WriteLine(e.ToString());
            }
         }
      }

      /// <summary>
      /// y scale numeric up down value changed handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _yScaleNumericUpDown_ValueChanged(object sender, EventArgs e)
      {
         this._movingMotionChart.ChartAreas[Constants.SERIES].AxisY.Maximum =
             (double)this._yScaleNumericUpDown.Value;
         this._movingMotionChart.ChartAreas[Constants.SERIES].AxisY.Interval =
             (double)this._yScaleNumericUpDown.Value / Constants.LINES_Y_AXIS;
      }

      /// <summary>
      /// x scale numeric up down value changed handler
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void _xScaleNumericUpDown_ValueChanged(object sender, EventArgs e)
      {
         this._movingMotionChart.ChartAreas[Constants.SERIES].AxisX.Maximum =
             (double)this._xScaleNumericUpDown.Value;
         this._movingMotionChart.ChartAreas[Constants.SERIES].AxisX.Interval =
             (double)this._xScaleNumericUpDown.Value / Constants.LINES_X_AXIS;

      }

      #endregion

      #region misc

      /// <summary>
      /// change button text on selection
      /// </summary>
      /// <param name="button"></param>
      private void changeButtonTextOnSelection(Constants.Buttons button)
      {
         this._selectInputDirectoryButton.ForeColor = Color.Black;
         this._selectInputFileButton.ForeColor = Color.Black;
         this._camLiveButton.ForeColor = Color.Black;

         switch (button)
         {
            case Constants.Buttons.InDir:
               this._selectInputDirectoryButton.Text =
                   Constants.IN_DIR_SELECTED;
               this._selectInputDirectoryButton.ForeColor = Color.Red;
               this._selectInputFileButton.Text =
                   Constants.IN_FILE_SELECT;
               this._camLiveButton.Text = Constants.LIVE_CAM_SELECT;
               this.liveCamera = false;
               break;
            case Constants.Buttons.InFile:
               this._selectInputDirectoryButton.Text =
                   Constants.IN_DIR_SELECT;
               this._selectInputFileButton.Text =
                   Constants.IN_FILE_SELECTED;
               this._selectInputFileButton.ForeColor = Color.Red;
               this._camLiveButton.Text = Constants.LIVE_CAM_SELECT;
               this.liveCamera = false;
               break;
            case Constants.Buttons.LiveCam:
               this._selectInputDirectoryButton.Text =
                   Constants.IN_DIR_SELECT;
               this._selectInputFileButton.Text =
                   Constants.IN_FILE_SELECT;
               this._camLiveButton.Text = Constants.LIVE_CAM_SELECTED;
               this._camLiveButton.ForeColor = Color.Red;
               break;
         }

      }


      /// <summary>
      /// Time series visibility - flips to all visibile or all invisible
      /// </summary>
      /// <param name="visible"></param>
      private void SetTimeSeriesVisibility(bool visible)
      {
         this._movingMotionChart.Visible = visible;
         this._xScaleNumericUpDown.Visible = visible;
         this._yScaleNumericUpDown.Visible = visible;
         this._yaxisLabel.Visible = visible;
         this._xaxisLabel.Visible = visible;
      }

      /// <summary>
      /// flip whether buttons/check boxes are enabled on start/stop
      /// </summary>
      private void FlipUIEnabled()
      {
         this._startButton.Enabled = !this._startButton.Enabled;;
         this._runDemoButton.Enabled = !this._runDemoButton.Enabled;
         this._selectInputFileButton.Enabled = !this._selectInputFileButton.Enabled;
         this._selectInputDirectoryButton.Enabled = !this._selectInputDirectoryButton.Enabled;
         this._selectOutputDirectoryButton.Enabled = !this._selectOutputDirectoryButton.Enabled;
         this._camLiveButton.Enabled = !this._camLiveButton.Enabled;
         this._displayGraphCheckBox.Enabled = !this._displayGraphCheckBox.Enabled;
         this._visualizationCheckBox.Enabled = !this._visualizationCheckBox.Enabled;
         this._outputMotionCheckBox.Enabled = !this._outputMotionCheckBox.Enabled;
         this._setInternalParamsButton.Enabled = !this._setInternalParamsButton.Enabled;
         this._faceCheckBox.Enabled = !this._faceCheckBox.Enabled;
         this._simulationButton.Enabled = !this._simulationButton.Enabled;

         this._abortButton.Enabled = !this._abortButton.Enabled;

      }

      #endregion




   }
}
