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
    public partial class LiveCamSetupForm : Form
    {
        private CvCapture cap; // camera capture
        private String vidsaveloc = ""; // place to save video file
        private Thread _camThread; // camera thread
        private int camIndex = -1; // camera index
        private bool okflag = false; // ok flag

        /// <summary>
        /// constructor
        /// </summary>
        public LiveCamSetupForm()
        {
            InitializeComponent();

            ConfigureComponent();
        }

        /// <summary>
        /// Configure component
        /// </summary>
        private void ConfigureComponent()
        {
            try
            {
                this._testButton.Text = Constants.TEST_CAM_START;  
            }
            catch
            {
            }

            this.FormClosed += new FormClosedEventHandler(LiveCamSetupForm_FormClosed);
            this.FormClosing += new FormClosingEventHandler(LiveCamSetupForm_FormClosing);
        }

        /// <summary>
        /// form closing event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiveCamSetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this._camThread != null && this._camThread.IsAlive)
                {
                    this.cap.Dispose();
                    this._camThread.Abort();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// form close event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiveCamSetupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (this.okflag)
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Select save location button click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _selectLocButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = ".avi";
                sfd.ValidateNames = true;
                sfd.OverwritePrompt = true;
                sfd.Title = "Choose where to save video file";
                DialogResult res = sfd.ShowDialog();

                if (res == System.Windows.Forms.DialogResult.OK
                    && Directory.Exists(Path.GetDirectoryName(sfd.FileName)))
                {
                    this.vidsaveloc = Path.GetFileNameWithoutExtension(sfd.FileName) + ".avi";

                    this._selectLocButton.Text = Constants.SAVE_FILE_SELECTED;
                    this._selectLocButton.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Cancel button click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// cam index up down value changed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _camIndexUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.camIndex = (int)this._camIndexUpDown.Value;
            }
            catch
            {
            }
        }

        /// <summary>
        /// save settings for later on ok button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _okButton_Click(object sender, EventArgs e)
        {
            // save values for later (available through public property)
            // make sure camera in box is stopped (in onformclosing)
            this.okflag = true;

            // and close form
            this.Close();
        }

        /// <summary>
        /// test camera capture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _testButton_Click(object sender, EventArgs e)
        {
            if (this._testButton == null) return;

            if (this._testButton.Text.Equals(Constants.TEST_CAM_START))
            {
                // start camera in box
                CaptureFromCamera();
                this._testButton.Text = Constants.TEST_CAM_STOP;
            }
            else
            {
                this._pictureBox.Image = null;
                this.cap.Dispose();
                this._camThread.Abort();
                this._testButton.Text = Constants.TEST_CAM_START;
            }
            
        }

        /// <summary>
        /// capture from camera
        /// </summary>
        private void CaptureFromCamera()
        {
            _camThread = new Thread(new ThreadStart(CaptureCamCallback));
            _camThread.Start();
        }

        /// <summary>
        /// capture cam callback
        /// </summary>
        private void CaptureCamCallback()
        {
            try
            {
                this.cap = CvCapture.FromCamera(
                    CaptureDevice.Any,
                    this.camIndex);

                while (true)
                {
                    Bitmap imgb = BitmapConverter.ToBitmap(cap.QueryFrame());
                    imgb.SetResolution(this._pictureBox.Width, this._pictureBox.Height);

                    if (imgb.Size.Width > this._pictureBox.Size.Width
                        || imgb.Size.Height > this._pictureBox.Size.Height)
                        this._pictureBox.Image = MotionTrackerUI.resizeImage(
                            imgb, this._pictureBox.Size);
                    else
                        this._pictureBox.Image = imgb;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// get save video file location
        /// </summary>
        /// <returns></returns>
        public String GetSaveVideoFileLocation()
        {
            return this.vidsaveloc;
        }

        /// <summary>
        /// get camera index
        /// </summary>
        /// <returns></returns>
        public int GetCameraIndex()
        {
            return this.camIndex;
        }
       
    }
}
